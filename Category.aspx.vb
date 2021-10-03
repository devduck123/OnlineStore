Public Class Category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("MainCategoryID") <> "" Then
            lblMainCategoryName.Text = Request.QueryString("MainCategoryName")
            sqlDSSubCategory.SelectCommand = "SELECT * FROM [Category] Where Parent = " & CInt(Request.QueryString("MainCategoryID"))
        End If
    End Sub

End Class