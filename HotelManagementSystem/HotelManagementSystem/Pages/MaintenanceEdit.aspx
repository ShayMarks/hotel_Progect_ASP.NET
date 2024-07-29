<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceEdit.aspx.cs" Inherits="HotelManagementSystem.Pages.MaintenanceEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Maintenance</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Edit Maintenance</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblMaintenanceID" runat="server" Text="Maintenance ID: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblMaintenanceIDValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblRoomID" runat="server" Text="Room ID: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtRoomID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDescription" runat="server" Text="Description: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMaintenanceDate" runat="server" Text="Maintenance Date: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtMaintenanceDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
