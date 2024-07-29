<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelManagementSystem.Pages.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h2>Login</h2>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Username: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                <asp:Button ID="btnBackToHome" runat="server" Text="Back to Home" CssClass="btn btn-secondary ml-2" OnClick="btnBackToHome_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
