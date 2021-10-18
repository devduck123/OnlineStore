<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Login.aspx.vb" Inherits="OnlineStore.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div role="main" class="main shop py-4" style="display:flex; flex-direction:row; flex-wrap:nowrap;">
        <div class="container py-4">
            <div class="row justify-content-center">
                <!-- LOGIN -->
                <div class="col-md-6 col-lg-5 mb-5 mb-lg-0">
                    <div class="form-group col">
                        <h2 class="font-weight-bold text-5 mb-0">Login</h2>
                        <span class="form-label text-color-dark text-3">Email:</span><br />
                        <asp:TextBox ID="tbEmail" Width="200" runat="server"></asp:TextBox><br />
                        <span class="form-label text-color-dark text-3">Password:</span><br />
                        <asp:TextBox ID="tbPassword" Width="200" runat="server"></asp:TextBox><br />
                        <br />
                        <asp:Button ID="btnLogin" runat="server" Text="SUBMIT" CssClass="btn btn-dark btn-modern font-weight-bold" /><br />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                    </div>
                </div>



                <!-- REGISTER -->
                <div class="col-md-6 col-lg-5" style="display:flex;">
                    <div style="margin-right:50%;"><h2>OR</h2></div>
                    <div class="form-group col">
                        <h2 class="font-weight-bold text-5 mb-0">Register</h2>
                        <span class="form-label text-color-dark text-3">Email:</span><br />
                        <asp:TextBox ID="TextBox1" Width="200" runat="server"></asp:TextBox><br />
                        <span class="form-label text-color-dark text-3">Password:</span><br />
                        <asp:TextBox ID="TextBox2" Width="200" runat="server"></asp:TextBox><br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="SUBMIT" CssClass="btn btn-dark btn-modern font-weight-bold" /><br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                    </div>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
