Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Email") <> "" Then
            lblWelcomeMember.InnerText = "Hello " & Session("Email")
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session("Email") = ""
        Response.Redirect("Category.aspx")
    End Sub

End Class