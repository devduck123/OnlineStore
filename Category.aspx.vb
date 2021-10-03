Public Class Category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("MainCategoryID") <> "" Then
            lblMainCategoryName.Text = Request.QueryString("MainCategoryName")
            sqlDSSubCategory.SelectCommand = "SELECT * FROM [Category] WHERE Parent = " & CInt(Request.QueryString("MainCategoryID"))
            lblProductListType.Text = "Featured Products for " + Request.QueryString("MainCategoryName")
            sqlDSProductList.SelectCommand = "SELECT * FROM [Product] WHERE MainCategoryID = " & CInt(Request.QueryString("MainCategoryID")) & " AND ProductFeatured = 'Y'"
            'DEBUGGING? Response.Write(sqlDSProductList.SelectCommand)
        End If
    End Sub

End Class