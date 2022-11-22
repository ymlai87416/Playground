Module Module1

    Sub Main()
        Dim service As New TestWS.WebService1()
        service.Credentials = System.Net.CredentialCache.DefaultCredentials
        service.Url = "http://192.168.0.182/TestAsmx/WebService1.asmx"
        Dim result As Integer

        service.Add2(10, 2, result)
        service.

        Console.WriteLine(result)

    End Sub

End Module
