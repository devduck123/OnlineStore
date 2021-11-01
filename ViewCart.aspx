﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="ViewCart.aspx.vb" Inherits="OnlineStore.ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- version1 (just for checking) -->
    <%--    <asp:SqlDataSource ID="SqlDSCart1" runat="server"
        DataSourceMode="DataSet"
        ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>"
        SelectCommand=""
        DeleteCommand="DELETE FROM [Cart] WHERE ([CartNo] = @CartNo AND [ProductNo] = @ProductNo)"
        UpdateCommand="UPDATE [Cart] SET [Quantity] = @Quantity WHERE ([CartNo] = @CartNo AND [ProductNo] = @ProductNo)"></asp:SqlDataSource>
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False"
        DataSourceID="SqlDSCart1" AllowPaging="True" PageSize="3" DataKeyNames="CartNo,ProductNo"
        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True"
        EmptyDataText="There are no products in the cart.">
        <Columns>
            <asp:BoundField DataField="ProductNo" HeaderText="Product No" InsertVisible="False" ReadOnly="true"
                SortExpression="Product No" />
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" InsertVisible="False" ReadOnly="true"
                SortExpression="Product Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity"
                SortExpression="Quantity" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="TotalLabel" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ProductPrice" HeaderText="Price" SortExpression="Price" InsertVisible="False" ReadOnly="true" />
        </Columns>
    </asp:GridView>--%>

    <!-- version2 (HTML template) -->
    <div style="float: right; margin: 0 30px 5px 0;">
        <asp:Button ID="btnEmptyCart" runat="server" Text="Empty the Cart" CssClass="btn btn-light btn-modern text-color-dark bg-color-light-scale-2 text-color-hover-light bg-color-hover-primary text-uppercase text-3 font-weight-bold border-0 border-radius-0 btn-px-4 py-3" />
    </div>
    <asp:SqlDataSource ID="sqlDSCart1" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>"></asp:SqlDataSource>
    <asp:ListView ID="lvCart" runat="server" DataSourceID="sqlDSCart1"
        OnItemCommand="lvCart_OnItemCommand" CellPadding="3" DataKeyField="CartNo"
        CellSpacing="0" RepeatColumns="1" DataKeyNames="CartID">
        <LayoutTemplate>
            <div style="float: right; margin: 0 30px 5px 0;">
                <asp:Label ID="lblPage" runat="server" Text="" Font-Size="14px"></asp:Label>
            </div>
            <br />
            <!-- CART -->
            <div class="table-responsive cart_info">
                <table class="shop_table cart">
                    <thead>
                        <tr class="cart_menu" style="background-color: orange;">
                            <td class="product-thumbnail">Item</td>
                            <td class="product-name">Description</td>
                            <td class="product-price">Price</td>
                            <td class="product-quantity">Quantity</td>
                            <td class="product-subtotal">Total</td>
                            <td></td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </tbody>
                </table>
            </div>

        </LayoutTemplate>
        <ItemTemplate>
            <tr class="cart_table_item">
                <td class="product-thumbnail">
                    <!-- TO LINK TO PRODUCTDETAIL PAGE, PRODUCTID MUST BE ADDED TO THE CART TABLE IN DB -->
                    <%--<a href="ProductDetail.aspx?ProductID=<%# Eval("ProductID") %>"><img src="img/<%# Trim(Eval("ProductNo")) %>.jpg" alt="" width="320" height="180"></a>--%>
                    <a href="">
                        <img src="img/<%# Trim(Eval("ProductNo")) %>.jpg" alt="" width="320" height="180"></a>
                </td>
                <td class="product-name">
                    <h4><a href=""><%# Trim(Eval("ProductName")) %></a></h4>
                    <p>Product Number: <%# Eval("ProductNo") %></p>
                </td>
                <td class="product-price">
                    <p>$<%# Eval("ProductPrice") %></p>
                </td>
                <td class="product-quantity">
                    <asp:TextBox ID="tbQuantity" Text='<%# Eval("Quantity")%>' Width="50px" CssClass="" runat="server"></asp:TextBox>
                    <asp:LinkButton runat="server" ID="lbUpdate" Text='Update'
                        CommandName="cmdUpdate" CommandArgument='<%# Eval("ProductNo")%>' CssClass="btn btn-light btn-modern text-color-dark bg-color-light-scale-2 text-color-hover-light bg-color-hover-primary text-uppercase text-3 font-weight-bold border-0 border-radius-0 btn-px-4 py-3" />
                    <asp:LinkButton runat="server" ID="lbDelete" Text='Delete'
                        CommandName="cmdDelete" CommandArgument='<%# Eval("ProductNo")%>' CssClass="btn btn-light btn-modern text-color-dark bg-color-light-scale-2 text-color-hover-light bg-color-hover-primary text-uppercase text-3 font-weight-bold border-0 border-radius-0 btn-px-4 py-3" />
                </td>
                <td class="product-subtotal">
                    <asp:Label ID="subtotal" runat="server" class="amount text-color-dark font-weight-bold text-4">$<%# Eval("Quantity") * Eval("ProductPrice") %></asp:Label>
                </td>
                <td class="product-thumbnail-remove"></td>
            </tr>
            <% counter = subtotal.InnerText %>
            <% Response.Write("counter: " + counter) %>
            
        </ItemTemplate>
    </asp:ListView>
    <!-- CART TOTAL -->
    <div class="table_responsive cart_info">
        <table class="shop_table cart-totals mb-4">
            <tbody>
                <tr class="total">
                    <td>
                        <strong class="text-color-dark text-3-5">Total</strong>
                    </td>
                    <td class="text-end">
                        <strong class="text-color-dark"><span ID="subtotal" runat="server" class="amount text-color-dark text-5">$<%# counter %> </span></strong>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
