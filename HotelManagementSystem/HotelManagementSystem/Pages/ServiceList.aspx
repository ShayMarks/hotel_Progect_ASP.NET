<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="HotelManagementSystem.Pages.ServiceList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service List</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Service List</h1>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ServiceID" DataSourceID="SqlDataSource1" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="ServiceID" HeaderText="Service ID" InsertVisible="False" ReadOnly="True" SortExpression="ServiceID" />
                        <asp:BoundField DataField="ServiceName" HeaderText="Service Name" SortExpression="ServiceName" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HotelManagementDB %>" 
                    SelectCommand="SELECT * FROM [Services]" 
                    DeleteCommand="DELETE FROM [Services] WHERE [ServiceID] = @ServiceID" 
                    UpdateCommand="UPDATE [Services] SET [ServiceName] = @ServiceName, [Description] = @Description, [Price] = @Price WHERE [ServiceID] = @ServiceID">
                    <DeleteParameters>
                        <asp:Parameter Name="ServiceID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ServiceName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="ServiceID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Service" CssClass="btn btn-primary mt-3" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
