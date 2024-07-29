<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="HotelManagementSystem.Pages.SupplierList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier List</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Supplier List</h1>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SupplierID" DataSourceID="SqlDataSource1" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" InsertVisible="False" ReadOnly="True" SortExpression="SupplierID" />
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" SortExpression="SupplierName" />
                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HotelManagementDB %>" 
                    SelectCommand="SELECT * FROM [Suppliers]" 
                    DeleteCommand="DELETE FROM [Suppliers] WHERE [SupplierID] = @SupplierID" 
                    UpdateCommand="UPDATE [Suppliers] SET [SupplierName] = @SupplierName, [ContactName] = @ContactName, [Email] = @Email, [Phone] = @Phone WHERE [SupplierID] = @SupplierID">
                    <DeleteParameters>
                        <asp:Parameter Name="SupplierID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SupplierName" Type="String" />
                        <asp:Parameter Name="ContactName" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="SupplierID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Supplier" CssClass="btn btn-primary mt-3" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
