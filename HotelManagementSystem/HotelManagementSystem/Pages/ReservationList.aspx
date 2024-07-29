<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationList.aspx.cs" Inherits="HotelManagementSystem.Pages.ReservationList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservation List</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Reservation List</h1>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ReservationID" DataSourceID="SqlDataSource1" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="ReservationID" HeaderText="ReservationID" InsertVisible="False" ReadOnly="True" SortExpression="ReservationID" />
                        <asp:BoundField DataField="GuestID" HeaderText="GuestID" SortExpression="GuestID" />
                        <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" />
                        <asp:BoundField DataField="CheckInDate" HeaderText="CheckInDate" SortExpression="CheckInDate" />
                        <asp:BoundField DataField="CheckOutDate" HeaderText="CheckOutDate" SortExpression="CheckOutDate" />
                        <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HotelManagementDB %>" 
                    SelectCommand="SELECT * FROM [Reservations]" 
                    DeleteCommand="DELETE FROM [Reservations] WHERE [ReservationID] = @ReservationID" 
                    UpdateCommand="UPDATE [Reservations] SET [GuestID] = @GuestID, [RoomID] = @RoomID, [CheckInDate] = @CheckInDate, [CheckOutDate] = @CheckOutDate, [TotalAmount] = @TotalAmount WHERE [ReservationID] = @ReservationID">
                    <DeleteParameters>
                        <asp:Parameter Name="ReservationID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="GuestID" Type="Int32" />
                        <asp:Parameter Name="RoomID" Type="Int32" />
                        <asp:Parameter Name="CheckInDate" Type="DateTime" />
                        <asp:Parameter Name="CheckOutDate" Type="DateTime" />
                        <asp:Parameter Name="TotalAmount" Type="Decimal" />
                        <asp:Parameter Name="ReservationID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Reservation" CssClass="btn btn-primary mt-3" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
