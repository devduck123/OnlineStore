<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Category.aspx.vb" Inherits="OnlineStore.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- SEARCH RESULTS -->
    <div>
        <h1 id="lblSearch" runat="server"></h1>
        <!-- Products -->
        <div role="main" class="main shop pt-4">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="masonry-loader masonry-loader-showing">
                            <div
                                class="row products product-thumb-info-list"
                                data-plugin-masonry
                                data-plugin-options="{'layoutMode': 'fitRows'}">

                                <asp:SqlDataSource ID="sqlDSSearch" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
                                <asp:Repeater ID="rpSearch" runat="server" DataSourceID="sqlDSSearch">
                                    <ItemTemplate>
                                        <!-- ===== PRODUCT ===== -->
                                        <div class="col-sm-6 col-lg-4" style="margin-bottom: 8%;">
                                            <div class="product mb-0">
                                                <div class="product-thumb-info border-0 mb-3">
                                                    <div class="addtocart-btn-wrapper">
                                                        <a
                                                            href="shop-cart.html"
                                                            class="text-decoration-none addtocart-btn"
                                                            title="Add to Cart">
                                                            <i class="icons icon-bag"></i>
                                                        </a>
                                                    </div>

                                                    <!-- PRODUCT IMAGE -->
                                                    <a href="ProductDetail.aspx?ProductID=<%# Eval("ProductID") %>">
                                                        <div class="product-thumb-info-image">
                                                            <img
                                                                alt=""
                                                                class="img-fluid"
                                                                src="img/<%# Trim(Eval("ProductNo")) %>.jpg" />
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="d-flex justify-content-between">
                                                    <div>
                                                        <h3
                                                            class="
                              text-3-5
                              font-weight-bold font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                            <!-- PRODUCT TITLE -->
                                                            <a
                                                                href="ProductDetail.aspx?ProductID=<%# Eval("ProductID") %>"
                                                                class="text-color-dark text-color-hover-primary"><%# Eval("ProductName") %></a>
                                                        </h3>
                                                    </div>
                                                </div>
                                                <%--                                            <div title="Rated 5 out of 5">
                                                <input
                                                    type="text"
                                                    class="d-none"
                                                    value="5"
                                                    title=""
                                                    data-plugin-star-rating
                                                    data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                            </div>--%>

                                                <!-- PRODUCT PRICE -->
                                                <p class="price text-4 mb-0">
                                                    <span id="lblDiscountPrice" runat="server" class="amount text-color-dark">$<%# Format(discountIfMember(Eval("ProductPrice")), "N2") %></span>
                                                </p>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr ID="divider" runat="server" class="divider-dark" Visible="false"/>

    <!-- Products breadcrumb nav (MainCategory and SubCategory) -->
    <div>
        <h2 style="font-weight: bolder;">
            <asp:Label ID="lblMainCategoryName" runat="server" Text=""></asp:Label></h2>
        <div>
            <asp:SqlDataSource ID="sqlDSSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
            <asp:Repeater ID="rpSubCategory" runat="server" DataSourceID="sqlDSSubCategory">
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a href="Category.aspx?MainCategoryID=<%# Request.QueryString("MainCategoryID") %>&MainCategoryName=<%# Request.QueryString("MainCategoryName") %>&SubCategoryID=<%# CStr(Eval("CategoryID")) %>&SubCategoryName=<%# CStr(Eval("CategoryName")) %>"><%# Eval("CategoryName") %></a></h4>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <!-- Products -->
    <div role="main" class="main shop pt-4">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="masonry-loader masonry-loader-showing">
                        <div
                            class="row products product-thumb-info-list"
                            data-plugin-masonry
                            data-plugin-options="{'layoutMode': 'fitRows'}">

                            <h2>
                                <asp:Label ID="lblProductListType" runat="server" Text=""></asp:Label></h2>
                            <asp:SqlDataSource ID="sqlDSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand=""></asp:SqlDataSource>
                            <asp:Repeater ID="rpProductList" runat="server" DataSourceID="sqlDSProductList">
                                <ItemTemplate>
                                    <!-- ===== PRODUCT ===== -->
                                    <div class="col-sm-6 col-lg-4" style="margin-bottom: 8%;">
                                        <div class="product mb-0">
                                            <div class="product-thumb-info border-0 mb-3">
                                                <div class="addtocart-btn-wrapper">
                                                    <a
                                                        href="shop-cart.html"
                                                        class="text-decoration-none addtocart-btn"
                                                        title="Add to Cart">
                                                        <i class="icons icon-bag"></i>
                                                    </a>
                                                </div>

                                                <!-- PRODUCT IMAGE -->
                                                <a href="ProductDetail.aspx?ProductID=<%# Eval("ProductID") %>">
                                                    <div class="product-thumb-info-image">
                                                        <img
                                                            alt=""
                                                            class="img-fluid"
                                                            src="img/<%# Trim(Eval("ProductNo")) %>.jpg" />
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="d-flex justify-content-between">
                                                <div>
                                                    <h3
                                                        class="
                              text-3-5
                              font-weight-bold font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                        <!-- PRODUCT TITLE -->
                                                        <a
                                                            href="ProductDetail.aspx?ProductID=<%# Eval("ProductID") %>"
                                                            class="text-color-dark text-color-hover-primary"><%# Eval("ProductName") %></a>
                                                    </h3>
                                                </div>
                                            </div>
                                            <%--                                            <div title="Rated 5 out of 5">
                                                <input
                                                    type="text"
                                                    class="d-none"
                                                    value="5"
                                                    title=""
                                                    data-plugin-star-rating
                                                    data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                            </div>--%>

                                            <!-- PRODUCT PRICE -->
                                            <p class="price text-4 mb-0">
                                                <span id="lblDiscountPrice" runat="server" class="amount text-color-dark">$<%# Format(discountIfMember(Eval("ProductPrice")), "N2") %></span>
                                            </p>

                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <!-- ===== PAGINATION ===== -->
                        <div class="row mt-4">
                            <div class="col">
                                <ul class="pagination float-end">
                                    <li class="page-item">
                                        <a class="page-link" href="#"><i class="fas fa-angle-left"></i></a>
                                    </li>
                                    <li class="page-item active">
                                        <a class="page-link" href="#">1</a>
                                    </li>
                                    <li class="page-item">
                                        <a class="page-link" href="#">2</a>
                                    </li>
                                    <li class="page-item">
                                        <a class="page-link" href="#">3</a>
                                    </li>
                                    <li class="page-item">
                                        <a class="page-link" href="#"><i class="fas fa-angle-right"></i></a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
