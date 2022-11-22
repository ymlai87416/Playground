Using System;
Using System.Web.Services;
Using System.Web.Services.Protocols;
Using System.IO;
Using System.Net;

    // Define a SOAP Extension that traces the SOAP request And SOAP
    // response for the XML Web service method the SOAP extension Is
    // applied to.

    Public Class TraceExtension :  SoapExtension 
    {
        Stream oldStream;
        Stream newStream;
        String filename;

        // Save the Stream representing the SOAP request Or SOAP response into
        // a local memory buffer.
        Public override Stream ChainStream( Stream stream )
        {
            oldStream = stream;
            newStream = New MemoryStream();
            Return newStream;
        }

        // When the SOAP extension Is accessed for the first time, the XML Web
        // service method it Is applied to Is accessed to store the file
        // name passed in, using the corresponding SoapExtensionAttribute.	
        Public override Object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) 
        {
            Return ((TraceExtensionAttribute) attribute).Filename;
        }

        // The SOAP extension was configured to run using a configuration file
        // instead of an attribute applied to a specific XML Web service
        // method.
        Public override Object GetInitializer(Type WebServiceType) 
        {
            // Return a file name to log the trace information to, based on the
            // type.
            Return "C:\\" + WebServiceType.FullName + ".log";    
        }

        // Receive the file name stored by GetInitializer And store it in a
        // member variable for this specific instance.
        Public override void Initialize(Object initializer) 
        {
            filename = (string) initializer;
        }

        //  If the SoapMessageStage Is such that the SoapRequest Or
        //  SoapResponse Is still in the SOAP format to be sent Or received,
        //  save it out to a file.
        Public override void ProcessMessage(SoapMessage message) 
        {
            switch (message.Stage) 
            {
                Case SoapMessageStage.BeforeSerialize : 
                    break;
                Case SoapMessageStage.AfterSerialize : 
                    WriteOutput(message);
                    break;
                Case SoapMessageStage.BeforeDeserialize : 
                    WriteInput(message);
                    break;
                Case SoapMessageStage.AfterDeserialize : 
                    break;
            }
        }

        Public void WriteOutput(SoapMessage message)
        {
            newStream.Position = 0;
            FileStream fs = New FileStream(filename, FileMode.Append,
                FileAccess.Write);
            StreamWriter w = New StreamWriter(fs);

            String soapString = (message Is SoapServerMessage) ? "SoapResponse" : "SoapRequest";
            w.WriteLine("-----" + soapString + " at " + DateTime.Now);
            w.Flush();
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
            Copy(newStream, oldStream);
        }

        Public void WriteInput(SoapMessage message)
        {
            Copy(oldStream, newStream);
            FileStream fs = New FileStream(filename, FileMode.Append,
                FileAccess.Write);
            StreamWriter w = New StreamWriter(fs);

            String soapString = (message Is SoapServerMessage) ?
                "SoapRequest" : "SoapResponse";
            w.WriteLine("-----" + soapString + 
                " at " + DateTime.Now);
            w.Flush();
            newStream.Position = 0;
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
        }

        void Copy(Stream from, Stream To) 
        {
            TextReader reader = New StreamReader(from);
            TextWriter writer = New StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
    }

    // Create a SoapExtensionAttribute for the SOAP Extension that can be
    // applied to an XML Web service method.
    [AttributeUsage(AttributeTargets.Method)]
    Public Class TraceExtensionAttribute :  SoapExtensionAttribute 
    {

        Private String filename = "c:\\log.txt";
        Private int priority;

        Public override Type ExtensionType 
        {
            Get { Return TypeOf(TraceExtension); }
        }

        Public override int Priority 
        {
            Get { Return priority; }
            Set { priority = value; }
        }

        Public String Filename 
        {
            Get
            {
                Return filename;
            }
            Set
            {
                filename = value;
            }
        }
    }