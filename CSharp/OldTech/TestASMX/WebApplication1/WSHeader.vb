Imports System.Web.Services.Protocols

Public Class WSHeader
    Inherits SoapHeader

    Public UserId As String
    Public UserPassword As String
    Public Server As String
    Public Timeout As Integer
    Public CompanyInUse As String = ""
    Public EnvironmentInUse As String = ""
    Public Project As String = ""
    Public UserType As String = ""
End Class
