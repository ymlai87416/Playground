Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService

    Public header As New WSHeader

    <WebMethod()>
    <SoapHeader("header", Direction:=SoapHeaderDirection.In)>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function Add(a As Integer, b As Integer) As Integer
        Return a + b
    End Function

    <WebMethod()>
    <TraceExtension>
    Public Function Add2(a As Integer, b As Integer, ByRef result As Integer) As Boolean
        result = a + b
        Return True
    End Function

    <WebMethod()>
    Public Function GetRecord(input As String, ByRef output As DataTable) As Boolean
        output = New DataTable
        output.TableName = input
        ' Create four typed columns in the DataTable.
        output.Columns.Add("Dosage", GetType(Integer))
        output.Columns.Add("Drug", GetType(String))
        output.Columns.Add("Patient", GetType(String))
        output.Columns.Add("Date", GetType(DateTime))

        ' Add five rows with those columns filled in the DataTable.
        output.Rows.Add(25, "Indocin", "David", DateTime.Now)
        output.Rows.Add(50, "Enebrel", "Sam", DateTime.Now)
        output.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now)
        output.Rows.Add(21, "Combivent", "Janet", DateTime.Now)
        output.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now)
        Return True
    End Function

    <WebMethod()>
    Public Function GetRecord2(input As String) As DataTable
        Dim output As New DataTable
        output.TableName = input
        ' Create four typed columns in the DataTable.
        output.Columns.Add("Dosage", GetType(Integer))
        output.Columns.Add("Drug", GetType(String))
        output.Columns.Add("Patient", GetType(String))
        output.Columns.Add("Date", GetType(DateTime))

        ' Add five rows with those columns filled in the DataTable.
        output.Rows.Add(25, "Indocin", "David", DateTime.Now)
        output.Rows.Add(50, "Enebrel", "Sam", DateTime.Now)
        output.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now)
        output.Rows.Add(21, "Combivent", "Janet", DateTime.Now)
        output.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now)
        Return output
    End Function

    <WebMethod()>
    <SoapHeader("header", Direction:=SoapHeaderDirection.In)>
    Public Function SearchDocumentFromAllCM(ByVal fields() As String, ByVal values() As String, ByRef docs As DataSet, ByRef err As String) As Boolean

        Dim output As New DataTable
        output.TableName = "documents"
        ' Create four typed columns in the DataTable.
        output.Columns.Add("Index", GetType(Integer))
        output.Columns.Add("FileFullName", GetType(String))
        output.Columns.Add("PolicyNo", GetType(String))
        output.Columns.Add("DocumentType", GetType(String))
        output.Columns.Add("CreateDate", GetType(DateTime))
        output.Columns.Add("Source", GetType(String))

        ' Add five rows with those columns filled in the DataTable.
        output.Rows.Add(577293, "test1.pdf", 19991204, "Policy Schedule", DateTime.Now, "ECM")
        output.Rows.Add(580010, "test2.pdf", "19991204", "Policy Schedule", DateTime.Now, "ECM")

        docs.Tables.Add(output)
        err = Nothing

        Return True

    End Function

    <WebMethod()>
    <SoapHeader("header", Direction:=SoapHeaderDirection.In)>
    Public Function DownloadDocument(ByVal index As String, ByRef err As String, ByRef imgData() As Byte) As Boolean

        Dim filepath As String
        If index = "pdf" Then
            filepath = "C:\inetpub\wwwroot\TestAsmx\data\test.pdf"
        Else
            filepath = "C:\inetpub\wwwroot\TestAsmx\data\test.jpeg"
        End If

        err = "No error"
        Dim fInfo As New FileInfo(filepath)
        Dim numBytes As Long = fInfo.Length
        Dim fs As New FileStream(filepath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        Dim bytes As Byte() = br.ReadBytes(CInt(numBytes))
        imgData = bytes

        Return True
    End Function

End Class