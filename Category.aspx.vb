Imports System.Data
Imports System.Data.SqlClient

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

        If Request.QueryString("SubCategoryID") <> "" Then
            lblProductListType.Text = "All Products for " + Request.QueryString("SubCategoryName")
            sqlDSProductList.SelectCommand = "SELECT * FROM [Product] WHERE SubCategoryID = " & CInt(Request.QueryString("SubCategoryID"))
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

    Function discountIfMember(ByVal price As Double)
        If Session("Email") <> "" Then
            Return price - price * 0.2
        End If
        Return price
    End Function

End Class