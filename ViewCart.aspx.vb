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
            'TODO: validate input to be an Integer
            If Not Integer.TryParse(tbQuantity.Text, vbNull) Then
                Response.Write("<script language=""javascript"">alert('Please Enter a Number Value');</script>")
            ElseIf CInt(tbQuantity.Text) < 0 Then
                Response.Write("<script language=""javascript"">alert('Negative Values Are Not Allowed');</script>")
            Else
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
            End If
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

    Protected Sub DataPager1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataPager1.PreRender
        Dim total_pages As Integer
        Dim current_page As Integer
        lvCart.DataBind()
        total_pages = DataPager1.TotalRowCount / DataPager1.PageSize
        current_page = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        If DataPager1.TotalRowCount Mod DataPager1.PageSize <> 0 Then
            total_pages = total_pages + 1
        End If
        If CInt(lvCart.Items.Count) <> 0 Then
            Dim lbl As Label = lvCart.FindControl("lblPage")
            lbl.Text = "Page " + CStr(current_page) + " of " + CStr(total_pages) + " (Total items: " + CStr(DataPager1.TotalRowCount) + ")"
        End If
        If CInt(lvCart.Items.Count) = 0 Then
            DataPager1.Visible = False
            show_next.Visible = False
            show_prev.Visible = False
        End If
    End Sub

    Protected Sub show_prev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_prev.Click
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Dim last As Integer = total_pages \ 3
        last = last * 3
        Do While current_page < last
            last = last - 3
        Loop
        If last < 3 Then
            last = 0
        Else
            last = last - 3
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub

    Protected Sub show_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_next.Click
        Dim last As Integer = 3
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Do While current_page > last
            last = last + 3
        Loop
        If last > total_pages Then
            last = total_pages
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
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