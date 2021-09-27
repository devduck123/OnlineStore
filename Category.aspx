<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Category.aspx.vb" Inherits="OnlineStore.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- FIXME: HTML content being inherited from Template.Master?? -->
    <div class="col-sm-6 col-lg-4">
        <div class="product mb-0">
            <h2><asp:Label ID="lblMainCategoryName" runat="server" Text=""></asp:Label></h2>
            <asp:SqlDataSource ID="SqlDSSubCategory" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionStringOnlineStore %>' SelectCommand=""></asp:SqlDataSource>
            <asp:Repeater ID="rpSubCategory" DataSourceID="SqlDSSubCategory" runat="server">
                <ItemTemplate>
                    <h4 class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                        <a
                            href="shop-product-sidebar-right.html"
                            class="text-color-dark text-color-hover-primary"><%# Eval("CategoryName") %></a>
                    </h4>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <!-- products -->
    <div role="main" class="main shop pt-4">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="masonry-loader masonry-loader-showing">
                        <div
                            class="row products product-thumb-info-list"
                            data-plugin-masonry
                            data-plugin-options="{'layoutMode': 'fitRows'}">
                            <div class="col-sm-6 col-lg-4">
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

                                        <a
                                            href="ajax/shop-product-quick-view.html"
                                            class="
                            quick-view
                            text-uppercase
                            font-weight-semibold
                            text-2
                          ">QUICK VIEW
                                        </a>
                                        <a href="shop-product-sidebar-left.html">
                                            <div class="product-thumb-info-image">
                                                <img
                                                    alt=""
                                                    class="img-fluid"
                                                    src="img/products/product-grey-2.jpg" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <a
                                                href="#"
                                                class="
                              d-block
                              text-uppercase
                              text-decoration-none
                              text-color-default
                              text-color-hover-primary
                              line-height-1
                              text-0
                              mb-1
                            ">sports</a>
                                            <h3
                                                class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                <a
                                                    href="shop-product-sidebar-right.html"
                                                    class="text-color-dark text-color-hover-primary">Golf Bag</a>
                                            </h3>
                                        </div>
                                        <a
                                            href="#"
                                            class="
                            text-decoration-none
                            text-color-default
                            text-color-hover-dark
                            text-4
                          "><i class="far fa-heart"></i></a>
                                    </div>
                                    <div title="Rated 5 out of 5">
                                        <input
                                            type="text"
                                            class="d-none"
                                            value="5"
                                            title=""
                                            data-plugin-star-rating
                                            data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                    </div>
                                    <p class="price text-5 mb-3">
                                        <span class="sale text-color-dark font-weight-semi-bold">$29,00</span>
                                        <span class="amount">$19,00</span>
                                    </p>
                                </div>
                            </div>

                            <div class="col-sm-6 col-lg-4">
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

                                        <a
                                            href="ajax/shop-product-quick-view.html"
                                            class="
                            quick-view
                            text-uppercase
                            font-weight-semibold
                            text-2
                          ">QUICK VIEW
                                        </a>
                                        <a href="shop-product-sidebar-left.html">
                                            <div class="product-thumb-info-image">
                                                <img
                                                    alt=""
                                                    class="img-fluid"
                                                    src="img/products/product-grey-2.jpg" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <a
                                                href="#"
                                                class="
                              d-block
                              text-uppercase
                              text-decoration-none
                              text-color-default
                              text-color-hover-primary
                              line-height-1
                              text-0
                              mb-1
                            ">sports</a>
                                            <h3
                                                class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                <a
                                                    href="shop-product-sidebar-right.html"
                                                    class="text-color-dark text-color-hover-primary">Golf Bag</a>
                                            </h3>
                                        </div>
                                        <a
                                            href="#"
                                            class="
                            text-decoration-none
                            text-color-default
                            text-color-hover-dark
                            text-4
                          "><i class="far fa-heart"></i></a>
                                    </div>
                                    <div title="Rated 5 out of 5">
                                        <input
                                            type="text"
                                            class="d-none"
                                            value="5"
                                            title=""
                                            data-plugin-star-rating
                                            data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                    </div>
                                    <p class="price text-5 mb-3">
                                        <span class="sale text-color-dark font-weight-semi-bold">$29,00</span>
                                        <span class="amount">$19,00</span>
                                    </p>
                                </div>
                            </div>

                            <div class="col-sm-6 col-lg-4">
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

                                        <a
                                            href="ajax/shop-product-quick-view.html"
                                            class="
                            quick-view
                            text-uppercase
                            font-weight-semibold
                            text-2
                          ">QUICK VIEW
                                        </a>
                                        <a href="shop-product-sidebar-left.html">
                                            <div class="product-thumb-info-image">
                                                <img
                                                    alt=""
                                                    class="img-fluid"
                                                    src="img/products/product-grey-2.jpg" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <a
                                                href="#"
                                                class="
                              d-block
                              text-uppercase
                              text-decoration-none
                              text-color-default
                              text-color-hover-primary
                              line-height-1
                              text-0
                              mb-1
                            ">sports</a>
                                            <h3
                                                class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                <a
                                                    href="shop-product-sidebar-right.html"
                                                    class="text-color-dark text-color-hover-primary">Golf Bag</a>
                                            </h3>
                                        </div>
                                        <a
                                            href="#"
                                            class="
                            text-decoration-none
                            text-color-default
                            text-color-hover-dark
                            text-4
                          "><i class="far fa-heart"></i></a>
                                    </div>
                                    <div title="Rated 5 out of 5">
                                        <input
                                            type="text"
                                            class="d-none"
                                            value="5"
                                            title=""
                                            data-plugin-star-rating
                                            data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                    </div>
                                    <p class="price text-5 mb-3">
                                        <span class="sale text-color-dark font-weight-semi-bold">$29,00</span>
                                        <span class="amount">$19,00</span>
                                    </p>
                                </div>
                            </div>

                            <div class="col-sm-6 col-lg-4">
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

                                        <a
                                            href="ajax/shop-product-quick-view.html"
                                            class="
                            quick-view
                            text-uppercase
                            font-weight-semibold
                            text-2
                          ">QUICK VIEW
                                        </a>
                                        <a href="shop-product-sidebar-left.html">
                                            <div class="product-thumb-info-image">
                                                <img
                                                    alt=""
                                                    class="img-fluid"
                                                    src="img/products/product-grey-2.jpg" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <a
                                                href="#"
                                                class="
                              d-block
                              text-uppercase
                              text-decoration-none
                              text-color-default
                              text-color-hover-primary
                              line-height-1
                              text-0
                              mb-1
                            ">sports</a>
                                            <h3
                                                class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                <a
                                                    href="shop-product-sidebar-right.html"
                                                    class="text-color-dark text-color-hover-primary">Golf Bag</a>
                                            </h3>
                                        </div>
                                        <a
                                            href="#"
                                            class="
                            text-decoration-none
                            text-color-default
                            text-color-hover-dark
                            text-4
                          "><i class="far fa-heart"></i></a>
                                    </div>
                                    <div title="Rated 5 out of 5">
                                        <input
                                            type="text"
                                            class="d-none"
                                            value="5"
                                            title=""
                                            data-plugin-star-rating
                                            data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                    </div>
                                    <p class="price text-5 mb-3">
                                        <span class="sale text-color-dark font-weight-semi-bold">$29,00</span>
                                        <span class="amount">$19,00</span>
                                    </p>
                                </div>
                            </div>

                            <div class="col-sm-6 col-lg-4">
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

                                        <a
                                            href="ajax/shop-product-quick-view.html"
                                            class="
                            quick-view
                            text-uppercase
                            font-weight-semibold
                            text-2
                          ">QUICK VIEW
                                        </a>
                                        <a href="shop-product-sidebar-left.html">
                                            <div class="product-thumb-info-image">
                                                <img
                                                    alt=""
                                                    class="img-fluid"
                                                    src="img/products/product-grey-2.jpg" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <a
                                                href="#"
                                                class="
                              d-block
                              text-uppercase
                              text-decoration-none
                              text-color-default
                              text-color-hover-primary
                              line-height-1
                              text-0
                              mb-1
                            ">sports</a>
                                            <h3
                                                class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                <a
                                                    href="shop-product-sidebar-right.html"
                                                    class="text-color-dark text-color-hover-primary">Golf Bag</a>
                                            </h3>
                                        </div>
                                        <a
                                            href="#"
                                            class="
                            text-decoration-none
                            text-color-default
                            text-color-hover-dark
                            text-4
                          "><i class="far fa-heart"></i></a>
                                    </div>
                                    <div title="Rated 5 out of 5">
                                        <input
                                            type="text"
                                            class="d-none"
                                            value="5"
                                            title=""
                                            data-plugin-star-rating
                                            data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                    </div>
                                    <p class="price text-5 mb-3">
                                        <span class="sale text-color-dark font-weight-semi-bold">$29,00</span>
                                        <span class="amount">$19,00</span>
                                    </p>
                                </div>
                            </div>

                            <div class="col-sm-6 col-lg-4">
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

                                        <a
                                            href="ajax/shop-product-quick-view.html"
                                            class="
                            quick-view
                            text-uppercase
                            font-weight-semibold
                            text-2
                          ">QUICK VIEW
                                        </a>
                                        <a href="shop-product-sidebar-left.html">
                                            <div class="product-thumb-info-image">
                                                <img
                                                    alt=""
                                                    class="img-fluid"
                                                    src="img/products/product-grey-2.jpg" />
                                            </div>
                                        </a>
                                    </div>
                                    <div class="d-flex justify-content-between">
                                        <div>
                                            <a
                                                href="#"
                                                class="
                              d-block
                              text-uppercase
                              text-decoration-none
                              text-color-default
                              text-color-hover-primary
                              line-height-1
                              text-0
                              mb-1
                            ">sports</a>
                                            <h3
                                                class="
                              text-3-5
                              font-weight-medium font-alternative
                              text-transform-none
                              line-height-3
                              mb-0
                            ">
                                                <a
                                                    href="shop-product-sidebar-right.html"
                                                    class="text-color-dark text-color-hover-primary">Golf Bag</a>
                                            </h3>
                                        </div>
                                        <a
                                            href="#"
                                            class="
                            text-decoration-none
                            text-color-default
                            text-color-hover-dark
                            text-4
                          "><i class="far fa-heart"></i></a>
                                    </div>
                                    <div title="Rated 5 out of 5">
                                        <input
                                            type="text"
                                            class="d-none"
                                            value="5"
                                            title=""
                                            data-plugin-star-rating
                                            data-plugin-options="{'displayOnly': true, 'color': 'default', 'size':'xs'}" />
                                    </div>
                                    <p class="price text-5 mb-3">
                                        <span class="sale text-color-dark font-weight-semi-bold">$29,00</span>
                                        <span class="amount">$19,00</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
