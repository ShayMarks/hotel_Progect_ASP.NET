<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationEdit.aspx.cs" Inherits="HotelManagementSystem.Pages.ReservationEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Reservation</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Edit Reservation</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblReservationID" runat="server" Text="Reservation ID: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="lblReservationIDValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblGuestID" runat="server" Text="Guest ID: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtGuestID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblRoomID" runat="server" Text="Room ID: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtRoomID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCheckInDate" runat="server" Text="Check-In Date: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCheckInDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCheckOutDate" runat="server" Text="Check-Out Date: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCheckOutDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount: " CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
