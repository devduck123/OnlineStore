Imports System.Data
Imports System.Data.SqlClient
Public Class Template
    Inherits System.Web.UI.MasterPage
    Public strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connMainCategory As SqlConnection
        Dim cmdMainCategory As SqlCommand
        Dim drMainCategory As SqlDataReader
        Dim strSQL As String = "Select * from Category Where Parent = 0"
        connMainCategory = New SqlConnection(strConn)
        cmdMainCategory = New SqlCommand(strSQL, connMainCategory)
        connMainCategory.Open()
        drMainCategory = cmdMainCategory.ExecuteReader(CommandBehavior.CloseConnection)
        Dim strMainCategory As String = ""
        Do While drMainCategory.Read()
            strMainCategory = strMainCategory + "<li><a class='dropdown-item' href=''>" + Trim(drMainCategory("CategoryName")) + "</a></li>"
        Loop
        lblMainCategory.Text = strMainCategory
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strSearchString As String
        If tbSearchString.Text <> "" Then
            ' We need to figure out if the searchstring is one word.
            '     Use an ASP.net function that check if the string has a space (trim the searchstring)
            strSearchString = Trim(tbSearchString.Text)

            ' If it is one word, search for productNo in the Product table
            '    write all the database code with database connectionstring and the three objects
            '    SQL statement: Select * from Product Where ProductNo = ...
            '    If yes, redirect to ProductDetail.aspx
            '       Get the ProductID from the datareader above
            '       Dim strRedirect As String
            '       strRedirect = "ProductDetail.aspx?ProductID=" + strSearchString
            '       Response.redirect(strRedirect)
            '    Else redirect to Category.aspx
            '       Dim strRedirect As String
            '       strRedirect = "Category.aspx?SearchString=" + strSearchString
            '       Response.redirect(strRedirect)
            '    End If
            ' Else (not one word)
            '    Dim strRedirect As String
            '    strRedirect = "Category.aspx?SearchString=" + strSearchString
            '    Response.redirect(strRedirect)
            ' End If
        End If
    End Sub
End Class