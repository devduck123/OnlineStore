Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Text.RegularExpressions

Public Class Template
    Inherits System.Web.UI.MasterPage
    Public strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Email") <> "" Then
            hlLogin.Visible = False
            hlLogout.Visible = True
            hrefCustomer.Visible = True
            hrefCustomer.InnerHtml = Session("Email")
        End If

        Dim connMainCategory As SqlConnection
        Dim cmdMainCategory As SqlCommand
        Dim drMainCategory As SqlDataReader
        Dim strSQL As String = "SELECT * FROM [Category] WHERE Parent = 0"
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
            ' Response.Write("tbSearchString ACCESSED")

            ' We need to figure out if the searchstring is one word.
            '     Use an ASP.net function that check if the string has a space (trim the searchstring)

            strSearchString = Trim(tbSearchString.Text.ToUpper())

            'Response.Write("tbSearchString: " & strSearchString & "<br/>")
            Response.Write("Search Results for " & strSearchString & ": <br/> <br/>")

            ' If it is one word, search for productNo in the Product table
            '    write all the database code with database connectionstring and the three objects
            Dim connProduct As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            'Dim strSQL As String = "SELECT * FROM [Product]"
            Dim strSQL As String = "SELECT * FROM [Product] WHERE ProductNo LIKE '" & strSearchString & "%' OR ProductName LIKE '%" & strSearchString & "%'"
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)

            'loop through all Product elements (TESTING)
            'While drProduct.Read()
            '    Response.Write("ProductID: " + CStr(drProduct.Item("ProductID")) + "<br/>")
            '    Response.Write("ProductName: " + CStr(drProduct.Item("ProductName")) + "<br/>")
            '    Response.Write("ProductNo: " + CStr(drProduct.Item("ProductNo")) + "<br/>")
            'End While


            'PROFESSOR ADVICE:
            'compare user search string to every ProductNo in the Product table
            'if DIRECT match is found, then redirect user to corresponding ProductDetail page
            'else redirect user to Category.aspx

            'get the current url in order to check for '?' querystring
            Dim currUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
            'remove the &Search= AND the ?Search=, or else we'll have to overwrite it later 
            currUrl = Regex.Replace(currUrl, "(\&Search=.*)", "").Trim()
            currUrl = Regex.Replace(currUrl, "(\?Search=.*)", "").Trim()

            Dim strRedirect As String

            'IF SEARCH RESULTS ARE NOT FOUND, NOTHING TO READ
            If Not drProduct.HasRows() Then
                'TODO: REDIRECT TO CATEGORY.ASPX
                Response.Write("Not Found")
            End If
            'OTHERWISE READ ALL OF THE DATA FROM THE SELECT QUERY
            While drProduct.Read()
                Dim currProductNo = Trim(CStr(drProduct.Item("ProductNo")))

                'REDIRECT USER TO ProductDetail.aspx IF USER INPUTS EXACT ProductNo
                If strSearchString.Equals(currProductNo) Then
                    strRedirect = "ProductDetail.aspx?ProductID=" + CStr(drProduct.Item("ProductID"))
                    Response.Redirect(strRedirect)
                Else
                    'OTHERWISE LIST PRODUCTS RELEVANT TO SEARCHSTRING
                    'TODO: SEARCH DOES YIELD RESULTS => REDIRECT WITH SEARCHSTRING AS QUERYSTRING
                    'TODO: DISPLAY SEARCH RESULTS TO CATEGORY.ASPX?
                    Response.Write("ProductName: " + CStr(drProduct.Item("ProductName")) + "<br/>")
                    Response.Write("ProductNo: " + CStr(drProduct.Item("ProductNo")) + "<br/> <br/>")

                    'check if currUrl is already a querystring
                    If currUrl.Contains("?") Then
                        'if true, then add the Search parameter to the querystring link
                        strRedirect = currUrl + "&Search=" + CStr(strSearchString)
                    Else
                        'if false, then turn link into querystring and add the Search parameter
                        strRedirect = currUrl + "?Search=" + CStr(strSearchString)
                    End If
                    Response.Redirect(strRedirect)
                End If
            End While


            'PROFESSOR ADVICE:
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