<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceList.aspx.cs" Inherits="HotelManagementSystem.Pages.MaintenanceList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maintenance List</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Maintenance List</h1>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MaintenanceID" DataSourceID="SqlDataSource1" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="MaintenanceID" HeaderText="Maintenance ID" InsertVisible="False" ReadOnly="True" SortExpression="MaintenanceID" />
                        <asp:BoundField DataField="RoomID" HeaderText="Room ID" SortExpression="RoomID" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="MaintenanceDate" HeaderText="Maintenance Date" SortExpression="MaintenanceDate" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HotelManagementDB %>" 
                    SelectCommand="SELECT * FROM [Maintenance]" 
                    DeleteCommand="DELETE FROM [Maintenance] WHERE [MaintenanceID] = @MaintenanceID" 
                    UpdateCommand="UPDATE [Maintenance] SET [RoomID] = @RoomID, [Description] = @Description, [MaintenanceDate] = @MaintenanceDate WHERE [MaintenanceID] = @MaintenanceID">
                    <DeleteParameters>
                        <asp:Parameter Name="MaintenanceID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RoomID" Type="Int32" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="MaintenanceDate" Type="DateTime" />
                        <asp:Parameter Name="MaintenanceID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Maintenance" CssClass="btn btn-primary mt-3" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
