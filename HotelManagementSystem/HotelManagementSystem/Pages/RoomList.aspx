<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="HotelManagementSystem.Pages.RoomList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Room List</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Room List</h1>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomID" DataSourceID="SqlDataSource1" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="RoomID" HeaderText="Room ID" InsertVisible="False" ReadOnly="True" SortExpression="RoomID" />
                        <asp:BoundField DataField="RoomNumber" HeaderText="Room Number" SortExpression="RoomNumber" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HotelManagementDB %>" 
                    SelectCommand="SELECT * FROM [Rooms]" 
                    DeleteCommand="DELETE FROM [Rooms] WHERE [RoomID] = @RoomID" 
                    UpdateCommand="UPDATE [Rooms] SET [RoomNumber] = @RoomNumber, [Type] = @Type, [Price] = @Price, [Status] = @Status WHERE [RoomID] = @RoomID">
                    <DeleteParameters>
                        <asp:Parameter Name="RoomID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RoomNumber" Type="String" />
                        <asp:Parameter Name="Type" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="Status" Type="String" />
                        <asp:Parameter Name="RoomID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Room" CssClass="btn btn-primary mt-3" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
