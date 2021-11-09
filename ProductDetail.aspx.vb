Imports System.Data
Imports System.Data.SqlClient
Public Class ProductDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ProductID") <> "" Then
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
            Dim connProduct As SqlConnection ' oleDBConnection for Access
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            Dim strSQL As String = "SELECT * FROM [Product] Where ProductID = " & CInt(Request.QueryString("ProductID"))
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblProductName.Text = drProduct.Item("ProductName")
                lblProductNo.Text = drProduct.Item("ProductNo")
                lblProductPrice.Text = drProduct.Item("ProductPrice")
                lblProductImage.Src = "img/" & Trim(drProduct.Item("ProductNo")) & ".jpg"
                lblProductDescription.InnerText = drProduct.Item("ProductDescription")
                lblProductDetail.InnerText = drProduct.Item("ProductDetail")

                'bonus: display rating images based on the rating value from the rating data field

                '20% off price if logged in
                If Session("Email") <> "" Then
                    Dim discPrice = CDbl(drProduct.Item("ProductPrice")) - (CDbl(drProduct.Item("ProductPrice")) * 0.2)
                    lblProductPrice.Text = Format(discPrice, "N2")
                End If

            Else

            End If
        End If

        If Request.QueryString("Search") <> "" Then
            If Request.QueryString("Search").Equals("NOTFOUND") Then
                lblSearch.InnerText = "Search results were not found"
                divider.Visible = True
            Else
                lblSearch.InnerText = "Search results for " & Request.QueryString("Search")
                sqlDSSearch.SelectCommand = "SELECT * FROM [Product] WHERE ProductNo LIKE '" & Request.QueryString("Search") & "%' OR ProductName LIKE '%" & Request.QueryString("Search") & "%'"
                divider.Visible = True
            End If
        End If

    End Sub

    Private Sub btnIncrease_Click(sender As Object, e As EventArgs) Handles btnIncrease.Click
        If tbQuantity.Text <> "" Then
            tbQuantity.Text = CStr(CInt(tbQuantity.Text) + 1)
        Else
            tbQuantity.Text = CStr(1)
        End If
    End Sub

    Private Sub btnDecrease_Click(sender As Object, e As EventArgs) Handles btnDecrease.Click
        If tbQuantity.Text <> "" Then
            If CInt(tbQuantity.Text) > 0 Then
                tbQuantity.Text = CStr(CInt(tbQuantity.Text) - 1)
            End If
        Else
            tbQuantity.Text = CStr(0)
        End If
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        '*** get CartNo
        Dim strCartNo As String
        If HttpContext.Current.Request.Cookies("CartNo") Is Nothing Then
            strCartNo = GetRandomCartNoUsingGUID(10)
            Dim CookieTo As New HttpCookie("CartNo", strCartNo)
            HttpContext.Current.Response.AppendCookie(CookieTo)
        Else
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartNo")
            strCartNo = CookieBack.Value
        End If
        ' set up ado objects and variables
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim drCheck As SqlDataReader
        Dim strSQLStatement As String
        Dim cmdSQL As SqlCommand
        ' get product price
        strSQLStatement = "SELECT * FROM [Product] Where ProductNo = '" & Trim(lblProductNo.Text) & "'"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        'Response.Write(strSQLStatement)
        conn.Open()
        drCheck = cmdSQL.ExecuteReader()
        Dim decPrice As Decimal
        If drCheck.Read() Then
            decPrice = drCheck.Item("ProductPrice")
        End If
        drCheck.Close()
        ' check if this product already exits in the cart
        strSQLStatement = "SELECT * FROM [Cart] WHERE CartNo = '" & strCartNo & "' AND ProductNo = '" & Trim(lblProductNo.Text) & "'"
        'Response.Write(strSQLStatement)
        cmdSQL.CommandText = strSQLStatement
        drCheck = cmdSQL.ExecuteReader()
        If Not Integer.TryParse(tbQuantity.Text, vbNull) Then
            Response.Write("<script language=""javascript"">alert('Please Enter a Number Value');</script>")
        ElseIf CInt(tbQuantity.Text) < 0 Then
            Response.Write("<script language=""javascript"">alert('Negative Values Are Not Allowed');</script>")
        Else
            If drCheck.Read() Then
                ' your work
                Dim updatedQuantity As Integer = CInt(drCheck.Item("Quantity")) + CInt(tbQuantity.Text)
                strSQLStatement = "UPDATE [Cart] SET Quantity = '" & updatedQuantity & "' where ProductNo = '" & lblProductNo.Text & "' and CartNo = '" & strCartNo & "'"
            Else
                strSQLStatement = "INSERT INTO [Cart] (CartNo, ProductNo, ProductName, Quantity, ProductPrice) VALUES ('" & strCartNo & "', '" & lblProductNo.Text & "', '" & lblProductName.Text & "', " & CInt(tbQuantity.Text) & ", " & decPrice & ")"
            End If
            'Response.Write(strSQLStatement)
            drCheck.Close() ' When a DataReader is open, its Connection is dedicated to the its associated SQLcommand.
            cmdSQL.CommandText = strSQLStatement
            Dim drCart As SqlDataReader
            drCart = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
            'COMMENT OUT TO TEST
            Response.Redirect("ViewCart.aspx")
        End If
    End Sub

    Function discountIfMember(ByVal price As Double)
        If Session("Email") <> "" Then
            Return price - price * 0.2
        End If
        Return price
    End Function

    Public Function GetRandomCartNoUsingGUID(ByVal length As Integer) As String
        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()
        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)
        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If
        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function
End Class