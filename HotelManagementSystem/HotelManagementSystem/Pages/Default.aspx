<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelManagementSystem.Pages.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Management System</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger float-right" OnClick="btnLogout_Click" />
                <h1 class="display-4">Welcome to Hotel Management System</h1>
            </div>
            <div class="card-body">
                <asp:Panel ID="ManagerPanel" runat="server" Visible="false" CssClass="section">
                    <h2>Manager Functions</h2>
                    <ul class="list-group">
                        <li class="list-group-item"><a href="EmployeeManagement.aspx">Employee Management</a></li>
                    </ul>
                </asp:Panel>

                <asp:Panel ID="AdminPanel" runat="server" Visible="false" CssClass="section mt-4">
                    <h2>Admin Functions</h2>
                    <ul class="list-group">
                        <li class="list-group-item"><a href="RoomList.aspx">Manage Rooms</a></li>
                        <li class="list-group-item"><a href="MaintenanceList.aspx">Manage Maintenance</a></li>
                        <li class="list-group-item"><a href="SupplierList.aspx">Manage Suppliers</a></li>
                        <li class="list-group-item"><a href="EmployeeList.aspx">Manage Employee</a></li>
                    </ul>
                </asp:Panel>

                <asp:Panel ID="EmployeePanel" runat="server" Visible="false" CssClass="section mt-4">
                    <h2>Employee Functions</h2>
                    <ul class="list-group">
                        <li class="list-group-item"><a href="GuestList.aspx">Manage Guests</a></li>
                        <li class="list-group-item"><a href="ReservationList.aspx">Manage Reservations</a></li>
                        <li class="list-group-item"><a href="ServiceList.aspx">Manage Services</a></li>
                    </ul>
                </asp:Panel>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
