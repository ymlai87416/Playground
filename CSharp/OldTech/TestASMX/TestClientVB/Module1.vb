Imports System.IO
Imports System.Net
Imports System.Text

Module Module1

    Sub Main()

        'Console.WriteLine("Testing Hello world")

        ''callHelloWorld()

        'Console.WriteLine()
        'Console.WriteLine()
        'Console.WriteLine("Testing Add")

        ''callAdd()

        'Console.WriteLine()
        'Console.WriteLine()
        'Console.WriteLine("Testing DataSet")

        ''callGetRecord()

        Console.WriteLine("Testing Search Document from all CM")

        callSearchDocumentFromAllCM()

        Console.WriteLine()
        Console.WriteLine("Testing Download Document")

        callDownloadDocument()

        'Console.Write("Press enter to continue...")
        'Console.ReadLine()

    End Sub

    Private Function callSearchDocumentFromAllCM()
        Dim postUrl = "https://localhost:44304/WebService1.asmx"
        Dim s As HttpWebRequest
        s = HttpWebRequest.Create(postUrl)
        Dim postdata = "<?xml version=""1.0"" encoding=""utf-8""?>
<soap12:Envelope xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
  <soap12:Header>
    <WSHeader xmlns=""http//tempuri.org/"">
      <UserId>tom</UserId>
      <UserPassword>shit</UserPassword>
      <Server>gate.hell</Server>
      <Timeout>100</Timeout>
      <CompanyInUse>mars</CompanyInUse>
      <EnvironmentInUse>citidel</EnvironmentInUse>
      <Project>D001</Project>
      <UserType>admin</UserType>
    </WSHeader>
  </soap12:Header>
  <soap12:Body>
    <SearchDocumentFromAllCM xmlns=""http://tempuri.org/"">
      <fields>
        <string>PolicyNo</string>
      </fields>
      <values>
        <string>19991204</string>
      </values>
      <docs xsi:nil=""true"" />
      <err xsi:nil=""true"" />
    </SearchDocumentFromAllCM>
  </soap12:Body>
</soap12:Envelope>"
        Console.WriteLine("SearchDocumentFromAllCM = Request: ")
        Console.WriteLine(postdata)

        Dim enc = New System.Text.UTF8Encoding()
        Dim postdatabytes = enc.GetBytes(postdata)

        s.ContentType = "application/soap+xml; charset=utf-8"
        s.ContentLength = postdatabytes.Length
        s.Method = "POST"
        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim result = s.GetResponse()
        Dim responseReader As New StreamReader(result.GetResponseStream(), Encoding.UTF8)
        Dim responseString = responseReader.ReadToEnd()

        'Console.WriteLine(responseString)

        'Read the shit to recordSet
        Dim doc As New MSXML2.DOMDocument()
        doc.loadXml(responseString)
        Dim resultNode As MSXML2.IXMLDOMNode = doc.selectSingleNode("//SearchDocumentFromAllCMResult")
        Dim docNodeList As MSXML2.IXMLDOMNodeList = doc.selectNodes("//documents")  'really depends on others

        Console.WriteLine("Result: ")
        Console.Write("SearchDocumentFromAllCMResult: ")
        Console.WriteLine(resultNode.text)
        For i As Integer = 0 To docNodeList.length - 1
            Dim currDoc As MSXML2.IXMLDOMNode = docNodeList.item(i)
            Dim index As String = currDoc.selectSingleNode("//Index").text
            Dim fullName As String = currDoc.selectSingleNode("//FileFullName").text
            Dim policyNo As String = currDoc.selectSingleNode("//PolicyNo").text
            Dim documentType As String = currDoc.selectSingleNode("//DocumentType").text
            Dim createDate As String = currDoc.selectSingleNode("//CreateDate").text
            Dim source As String = currDoc.selectSingleNode("//Source").text
            Console.WriteLine("Record " & i & ": " & index & " " & fullName & " " & policyNo & " " & documentType & " " & createDate & " " & source)

        Next i
    End Function


    Private Function callDownloadDocument()
        Dim postUrl = "https://localhost:44304/WebService1.asmx"
        Dim s As HttpWebRequest
        s = HttpWebRequest.Create(postUrl)
        Dim postdata = "<?xml version=""1.0"" encoding=""utf-8""?>
<soap12:Envelope xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
  <soap12:Header>
    <WSHeader xmlns=""http//tempuri.org/"">
      <UserId>tom</UserId>
      <UserPassword>shit</UserPassword>
      <Server>gate.hell</Server>
      <Timeout>100</Timeout>
      <CompanyInUse>mars</CompanyInUse>
      <EnvironmentInUse>citidel</EnvironmentInUse>
      <Project>D001</Project>
      <UserType>admin</UserType>
    </WSHeader>
  </soap12:Header>
  <soap12:Body>
    <DownloadDocument xmlns=""http://tempuri.org/"">
      <index>123456</index>
      <err></err>
      <imgData xsi:nil=""true"" />
    </DownloadDocument>
  </soap12:Body>
</soap12:Envelope>"
        Console.WriteLine("Download document = Request: ")
        Console.WriteLine(postdata)

        Dim enc = New System.Text.UTF8Encoding()
        Dim postdatabytes = enc.GetBytes(postdata)

        s.ContentType = "application/soap+xml; charset=utf-8"
        s.ContentLength = postdatabytes.Length
        s.Method = "POST"
        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim result = s.GetResponse()
        Dim responseReader As New StreamReader(result.GetResponseStream(), Encoding.UTF8)
        Dim responseString = responseReader.ReadToEnd()

        'Console.WriteLine(responseString)

        'Read the shit to recordSet
        Dim doc As New MSXML2.DOMDocument()
        doc.loadXML(responseString)
        Dim resultNode As MSXML2.IXMLDOMNode = doc.selectSingleNode("//DownloadDocumentResult")
        Dim errNode As MSXML2.IXMLDOMNode = doc.selectSingleNode("//err")
        Dim imgDataNode As MSXML2.IXMLDOMNode = doc.selectSingleNode("//imgData")
        doc.


        Console.WriteLine("Result: ")
        Console.Write("DownloadDocumentResult: ")
        Console.WriteLine(resultNode.text)
        Console.Write("err: ")
        Console.WriteLine(errNode.text)
        Console.Write("imgData: ")
        Console.WriteLine(imgDataNode.text.Substring(0, 20))
    End Function


    Private Sub callGetRecord()
        Dim postUrl = "https://localhost:44304/WebService1.asmx"
        Dim s As HttpWebRequest
        s = HttpWebRequest.Create(postUrl)
        Dim postdata = GetRecordSoap()
        Console.WriteLine("GetRecord = Request: ")
        Console.WriteLine(postdata)

        Dim enc = New System.Text.UTF8Encoding()
        Dim postdatabytes = enc.GetBytes(postdata)

        s.ContentType = "application/soap+xml; charset=utf-8"
        s.ContentLength = postdatabytes.Length
        s.Method = "POST"
        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim result = s.GetResponse()
        Dim responseReader As New StreamReader(result.GetResponseStream(), Encoding.UTF8)
        Dim responseString = responseReader.ReadToEnd()

        Console.WriteLine(responseString)
    End Sub


    Private Sub callGetRecord2()
        Dim postUrl = "https://localhost:44304/WebService1.asmx"
        Dim s As HttpWebRequest
        s = HttpWebRequest.Create(postUrl)
        Dim postdata = "<?xml version=""1.0"" encoding=""utf-8""?>
<soap12:Envelope xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
  <soap12:Body>
    <GetRecord2 xmlns=""http://tempuri.org/"">
      <input>tom</input>
    </GetRecord2>
  </soap12:Body>
</soap12:Envelope>"
        Dim enc = New System.Text.UTF8Encoding()
        Dim postdatabytes = enc.GetBytes(postdata)

        s.ContentType = "application/soap+xml; charset=utf-8"
        s.ContentLength = postdatabytes.Length
        s.Method = "POST"
        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim result = s.GetResponse()
        Dim responseReader As New StreamReader(result.GetResponseStream(), Encoding.UTF8)
        Dim responseString = responseReader.ReadToEnd()

        Console.WriteLine(responseString)
    End Sub

    Private Sub callAdd()
        Dim postUrl As String = "https://localhost:44304/WebService1.asmx"
        Dim s As HttpWebRequest
        s = HttpWebRequest.Create(postUrl)

        Dim postdata = "<?xml version=""1.0"" encoding=""utf-8""?>
<soap12:Envelope xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
  <soap12:Body>
    <Add xmlns=""http://tempuri.org/"">
      <a>10</a>
      <b>2</b>
    </Add>
  </soap12:Body>
</soap12:Envelope>"

        Dim enc = New System.Text.UTF8Encoding()
        Dim postdatabytes = enc.GetBytes(postdata)

        s.ContentType = "application/soap+xml"
        s.ContentLength = postdatabytes.Length
        s.Method = "POST"
        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim result = s.GetResponse()
        Dim responseReader As New StreamReader(result.GetResponseStream(), Encoding.UTF8)
        Dim responseString = responseReader.ReadToEnd()

        Console.WriteLine(responseString)
    End Sub

    Private Sub callHelloWorld()
        Dim postUrl As String = "https://localhost:44304/WebService1.asmx"
        Dim s As HttpWebRequest
        s = HttpWebRequest.Create(postUrl)

        Dim postdata = GetHelloWorldSoap()
        Console.WriteLine(postdata)
        Dim enc = New System.Text.UTF8Encoding()
        Dim postdatabytes = enc.GetBytes(postdata)

        s.ContentType = "application/soap+xml; charset=utf-8"
        s.ContentLength = postdatabytes.Length
        s.Method = "POST"
        Using stream = s.GetRequestStream()
            stream.Write(postdatabytes, 0, postdatabytes.Length)
        End Using

        Dim result = s.GetResponse()
        Dim responseReader As New StreamReader(result.GetResponseStream(), Encoding.UTF8)
        Dim responseString = responseReader.ReadToEnd()

        Console.WriteLine(responseString)
    End Sub

    Private Function GetHelloWorldSoap() As String
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
        <soap12:Envelope xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envlope"">
          <soap12:Body>
            <HelloWorld xmlns=""http://tempuri.org/"" />
          </soap12:Body>
        </soap12:Envelope>"

        '        Return "<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
        '  <s:Header>
        '    <Action s:mustUnderstand=""1"" xmlns=""http//schemas.microsoft.com/ws/2005/05/addressing/none"">http://tempuri.org/HelloWorld</Action>
        '  </s:Header>
        '  <s:Body xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
        '    <HelloWorld xmlns=""http//tempuri.org/"" />
        '  </s:Body>
        '</s:Envelope>"
    End Function

    Private Function GetRecordSoap() As String

        Dim msg As String = "<?xml version=""1.0"" encoding=""utf-8""?>
<soap12:Envelope xmlns:xsi=""http//www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
  <soap12:Body>
    <GetRecord xmlns=""http://tempuri.org/"">
      <input>%0%</input>
      <output>%1%</output>
    </GetRecord>
  </soap12:Body>
</soap12:Envelope>"

        msg = msg.Replace("%0%", "tom")

        Dim empty As New DataTable
        empty.TableName = "empty"
        Dim Stream As New MemoryStream
        empty.WriteXml(Stream)
        Stream.Seek(0, SeekOrigin.Begin)
        Dim tableStr = New StreamReader(Stream).ReadToEnd()

        Stream = New MemoryStream
        empty.WriteXmlSchema(Stream)
        Stream.Seek(0, SeekOrigin.Begin)
        Dim tableStr2 = New StreamReader(Stream).ReadToEnd()
        tableStr2 = "<xs:schema id=""NewDataSet"" xmlns="""" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">" & vbCrLf & "  <xs:element name=""NewDataSet"" msdata:IsDataSet=""true"" msdata:MainDataTable=""empty"" msdata:UseCurrentLocale=""true"">" & vbCrLf & "    <xs:complexType>" & vbCrLf & "      <xs:choice minOccurs=""0"" maxOccurs=""unbounded"">" & vbCrLf & "        <xs:element name=""empty"">" & vbCrLf & "          <xs:complexType>" & vbCrLf & "          </xs:complexType>" & vbCrLf & "        </xs:element>" & vbCrLf & "      </xs:choice>" & vbCrLf & "    </xs:complexType>" & vbCrLf & "  </xs:element>" & vbCrLf & "</xs:schema>"

        msg = msg.Replace("%1%", tableStr2 + tableStr)

        Return msg
    End Function

End Module
