<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="HotelManagementSystem.Pages.SupplierEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Supplier</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Edit Supplier</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblSupplierID" runat="server" Text="Supplier ID: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblSupplierIDValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblContactName" runat="server" Text="Contact Name: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPhone" runat="server" Text="Phone: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
