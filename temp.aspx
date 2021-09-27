<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="temp.aspx.vb" Inherits="OnlineStore.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionStringOnlineStore %>' SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
    </form>
</body>
</html>
