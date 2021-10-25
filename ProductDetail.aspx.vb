﻿Imports System.Data
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

    Function discountIfMember(ByVal price As Double)
        If Session("Email") <> "" Then
            Return price - price * 0.2
        End If
        Return price
    End Function
End Class