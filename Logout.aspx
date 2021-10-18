<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Logout.aspx.vb" Inherits="OnlineStore.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div role="main" class="main shop py-4" style="display: flex; flex-direction: row; flex-wrap: nowrap;">
        <div class="container py-4">
            <div class="row justify-content-center">
                <!-- LOGOUT -->
                <div class="col-md-6 col-lg-5 mb-5 mb-lg-0">
                    <div class="form-group col">
                        <div style="margin-bottom:40px;"><h2 class="font-weight-bold text-5 mb-0" ID="lblWelcomeMember" runat="server"></h2></div>

                        <asp:Button ID="btnLogout" runat="server" Text="LOGOUT" CssClass="btn btn-dark btn-modern font-weight-bold" /><br />
                        <br />
                        <asp:Label ID="lblLogoutMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
