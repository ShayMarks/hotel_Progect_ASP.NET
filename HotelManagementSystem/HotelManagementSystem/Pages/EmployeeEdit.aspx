<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="HotelManagementSystem.Pages.EmployeeEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Employee</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Edit Employee</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblEmployeeID" runat="server" Text="Employee ID: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblEmployeeIDValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPosition" runat="server" Text="Position: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
