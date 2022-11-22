# Download from gmail and export it to csv
import sys
import zipfile
from lxml import etree
from datetime import datetime
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
import base64
import pandas as pd


def dump_tags(tree):
    print('----------')
    for tag in tree.getchildren():
        print(tag)


def load_attachment(zip, name):
    fh = zip.open(name)
    return fh


def get_id(email):
    tag_id = email.find('.//OPFMessageCopyMessageID')
    if tag_id is None:
        tag_id = email.find('.//OPFMessageCopyExchangeConversationId')
    return tag_id.text.strip()


def get_date(email):
    tag = email.find('.//OPFMessageCopySentTime')
    if tag is None:
        tag = email.find('.//OPFMessageCopyReceivedTime')
    date = datetime.strptime(tag.text.strip(), '%Y-%m-%dT%H:%M:%S')
    return date.isoformat()


def get_body(email):
    has_html = email.find('.//OPFMessageGetHasHTML')
    # has_rich = email.find('.//OPFMessageGetHasRichText')
    tag_body = email.find('.//OPFMessageCopyBody')
    mime_type = 'text/plain'
    if has_html is not None:
        html = has_html.text.replace('E0', '')
        if html == '1':
            tag_body = email.find('.//OPFMessageCopyHTMLBody')
            mime_type = 'text/html'

    body = tag_body.text
    if body is not None:
        # There might be no body if it's a calender reply or something.
        # Calendar replies still have subject lines and addressees and stuff
        # though so probably worth keeping.
        body = body.strip().encode('utf-8')

    return {mime_type: body}


def get_attachments(zip, email):
    attachments = []
    tag_attachments = email.find('.//OPFMessageCopyAttachmentList')
    if tag_attachments is not None:
        for attachment in tag_attachments.findall('.//messageAttachment'):
            name = attachment.get('OPFAttachmentName')
            mime_type = attachment.get('OPFAttachmentContentType')
            # extension = attachment.get('OPFAttachmentContentExtension')
            # id = attachment.get('OPFAttachmentContentID')
            file = {
                'file_name': name,
                'mime_type': mime_type
            }
            url = attachment.get('OPFAttachmentURL')
            if url is not None:
                fh = load_attachment(zip, url)
                file['file_path'] = url
                file['file_handle'] = fh
            attachments.append(file)
    return attachments


def get_addresses(email):
    tag_from = email.find('.//OPFMessageCopyFromAddresses')
    tag_sender = email.find('.//OPFMessageCopySenderAddress')
    tag_to = email.find('.//OPFMessageCopyToAddresses')
    tag_cc = email.find('.//OPFMessageCopyCCAddresses')
    tag_bcc = email.find('.//OPFMessageCopyBCCAddresses')

    from_names, from_emails = get_contacts(tag_from)
    sender_names, sender_emails = get_contacts(tag_sender)
    to_names, to_emails = get_contacts(tag_to)
    cc_names, cc_emails = get_contacts(tag_cc)
    bcc_names, bcc_emails = get_contacts(tag_bcc)

    names = to_names + from_names + cc_names + bcc_names + sender_names
    emails = to_emails + from_emails + cc_emails + bcc_emails + sender_emails

    frm = from_emails + sender_emails
    author = from_names + sender_names

    return names, emails, author, frm, to_emails, cc_emails, bcc_emails


def get_contacts(addresses):
    names = []
    emails = []
    if addresses is not None:
        for address in addresses.findall('.//emailAddress'):
            email = address.get('OPFContactEmailAddressAddress')
            if email is not None:
                emails.append(email)
            name = address.get('OPFContactEmailAddressName')
            if name is not None and name != email:
                names.append(name)

            # etype = address.get('OPFContactEmailAddressType')

    return names, emails

def decode_utf8(text):
    text  = text.strip()
    if text.startswith("=?utf-8?b?"):
        coded_string = text[10:len(text)-2]
        data = base64.b64decode(coded_string)
        return data.decode("utf-8") 
    else:
        return text

def parse_message(zip, name):
    headers = {
        'From': None,
        'To': None,
        'Subject': None,
        'Message-ID': None,
        'CC': None,
        'BCC': None,
        'Date': None,
    }
    body = None
    attachments = []
    names = []
    emails = []
    title = None
    author = None

    doc = None
    fh = zip.open(name)
    try:
        doc = etree.parse(fh)
    except etree.XMLSyntaxError:
        p = etree.XMLParser(huge_tree=True)
        try:
            doc = etree.parse(fh, p)
        except etree.XMLSyntaxError:
            # probably corrupt
            pass

    if doc is None:
        return

    for email in doc.findall('//email'):

        headers['Message-ID'] = get_id(email)
        headers['Date'] = get_date(email)

        tag_subject = email.find('.//OPFMessageCopySubject')
        # OPFMessageCopyThreadTopic
        if tag_subject is not None:
            title = tag_subject.text.strip()
            title = decode_utf8(title)
            headers['Subject'] = title

        names, emails, author, frm, to, cc, bcc = get_addresses(email)
        headers['To'] = to
        headers['From'] = frm
        headers['CC'] = cc
        headers['BCC'] = bcc

        body = get_body(email)
        attachments = get_attachments(zip, email)

        return {
            'headers': headers,
            'body': body,
            'attachments': attachments,
            'names': names,
            'emails': emails,
            'title': title,
            'author': author,
            'created_at': headers['Date']
        }

def remove_html_tags(text):
    """Remove html tags from a string"""
    import re
    clean = re.compile('<.*?>')
    result= re.sub(clean, '', text).replace("\n", "")

    print("DD" + text + "->" + result)
    return result;

def make_email(headers, body, attachments):
    msg = MIMEMultipart()
    for header in headers.keys():
        if isinstance(headers[header], str):
            msg[header] = headers[header]
        elif isinstance(headers[header], list):
            msg[header] = ', '.join(headers[header])

    if body is not None:
        email = None
        if 'text/html' in body.keys():
            strBody= body['text/html'].decode("utf-8") 
            email = MIMEText(strBody, 'html')
        elif 'text/plain' in body.keys() and body['text/plain'] is not None:
            strBody= body['text/plain'].decode("utf-8") 
            email = MIMEText(strBody, 'plain')

        if email is not None:
            msg.attach(email)
    if attachments is not []:
        # TODO
        pass

    return msg
    
def dump_body_text(body):
    if 'text/html' in body and body['text/html'] is not None :
        return remove_html_tags( body['text/html'].decode('utf-8') )
    elif 'text/plain' in body and body['text/plain'] is not None:
        return body['text/plain'].decode('utf-8')
    else:
        return ""

def dump_attachment_text(attachment):
    pass

def main():
    fn = sys.argv[1]

    dict_list = []
    email_dict = pd.DataFrame(columns = ['to', 'from', 'cc', 'bcc', 'names', 'title', 'author', 'date', 'body', 'attachments'])


    zf = zipfile.ZipFile(fn, 'r')
    for info in zf.namelist():
        if 'com.microsoft.__Attachments' in info:
            continue
        if 'message_' not in info:
            continue

        parsed = parse_message(zf, info)

        body_text=dump_body_text(parsed['body'])
        attachement_text=""

        obj = {
            'to': parsed['headers']['To'],
            'from': parsed['headers']['From'],
            'cc': parsed['headers']['CC'],
            'bcc': parsed['headers']['BCC'],
            'names': parsed['names'],
            'title': parsed['title'],
            'author': parsed['author'],
            'date': parsed['created_at'],
            'body': body_text,
            'attachments': parsed['attachments'],
        }
        dict_list.append(obj)


        #email = make_email(parsed['headers'], parsed[
        #                   'body'], parsed['attachments'])

        #print(email.as_string())

    email_dict = pd.DataFrame.from_dict(dict_list)

    email_dict.to_csv("/Users/yiuminglai/Documents/Playground/Python/mail/sample/test.csv")

if __name__ == '__main__':
    main()

    #test = "=?utf-8?b?SFNCQyBJbnZlc3RtZW50IFNlcnZpY2VzIGVTdGF0ZW1lbnQgLSAzMS8wNS8xOCAtIDAyMy0yMTQqKiotODMzLCAyNTYyMTQ3ODE0IOWMr+ixkOaKleizh+acjeWLmembu+WtkOe1kOWWrg==?="
    #print(decode_utf8(test))