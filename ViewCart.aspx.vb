Imports System.Data
Imports System.Data.SqlClient
Public Class ViewCart
    Inherits System.Web.UI.Page
    Public counter As String
    Public strCartNo As String = " "
    Dim CookieBack As HttpCookie = HttpContext.Current.Request.Cookies("CartNo")
    Public strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strCartNo As String = " "
        Dim CookieBack As HttpCookie = HttpContext.Current.Request.Cookies("CartNo")
        If Not CookieBack Is Nothing Then
            strCartNo = CookieBack.Value
            'Response.Write("CartNo: " + strCartNo + "<br />")
        End If
        sqlDSCart1.SelectCommand = "SELECT * FROM [Cart] Where CartNo = '" & strCartNo & "'"

    End Sub

    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        If Not CookieBack Is Nothing Then
            strCartNo = CookieBack.Value
            'Response.Write("CartNo: " + strCartNo + "<br />")
        End If
        If e.CommandName = "cmdUpdate" Then
            ' get productno and quantity
            Dim strProductNo As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "UPDATE [Cart] SET Quantity = '" & CInt(tbQuantity.Text) & "' where ProductNo = '" & strProductNo & "' and CartNo = '" & strCartNo & "'"
            'update
            'Response.Write(strSQL)
            'Response.Write("<br /> CartNo: " + strCartNo + "<br />")
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart1.DataBind()
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri)
        ElseIf e.CommandName = "cmdDelete" Then
            ' get productno and quantity
            Dim strProductNo As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "DELETE FROM [Cart] WHERE ProductNo = '" & strProductNo & "' and CartNo = '" & strCartNo & "'"
            'update
            'Response.Write(strSQL)
            'Response.Write("<br /> CartNo: " + strCartNo + "<br />")
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart1.DataBind()
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri)
        End If
    End Sub

    Private Sub btnEmptyCart_Click(sender As Object, e As EventArgs) Handles btnEmptyCart.Click
        'Response.Write("hello empty cart")
        If Not CookieBack Is Nothing Then
            strCartNo = CookieBack.Value
            'Response.Write("CartNo: " + strCartNo + "<br />")
        End If

        Dim strSQL As String = "DELETE FROM [Cart] WHERE CartNo = '" & strCartNo & "'"
        'update
        'Response.Write(strSQL)
        'Response.Write("<br /> CartNo: " + strCartNo + "<br />")
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim drCart As SqlDataReader
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
        sqlDSCart1.DataBind()
        Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri)
    End Sub

    Function calculateSubtotal()
        If Not CookieBack Is Nothing Then
            strCartNo = CookieBack.Value
            'Response.Write("CartNo: " + strCartNo + "<br />")
        End If

        Dim strSQL As String = "SELECT * FROM [Cart] WHERE CartNo = '" & strCartNo & "'"
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim drCart As SqlDataReader
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)

        Dim totalPrice As Decimal
        Dim currPrice As Decimal
        While drCart.Read()
            'Response.Write("Quantity: " + CStr(drCart.Item("Quantity")) + "<br />")
            currPrice = CDec(drCart.Item("Quantity")) * CDec(drCart.Item("ProductPrice"))
            totalPrice = totalPrice + currPrice
        End While
        Response.Write(CStr(totalPrice))
        Return CStr(totalPrice)
    End Function

End Class