<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestList.aspx.cs" Inherits="HotelManagementSystem.Pages.GuestList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guest List</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="display-4">Guest List</h1>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GuestID" DataSourceID="SqlDataSource1" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="GuestID" HeaderText="GuestID" InsertVisible="False" ReadOnly="True" SortExpression="GuestID" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HotelManagementDB %>" 
                    SelectCommand="SELECT * FROM [Guests]" 
                    DeleteCommand="DELETE FROM [Guests] WHERE [GuestID] = @GuestID" 
                    UpdateCommand="UPDATE [Guests] SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email, [Phone] = @Phone, [Address] = @Address WHERE [GuestID] = @GuestID">
                    <DeleteParameters>
                        <asp:Parameter Name="GuestID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="GuestID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Guest" CssClass="btn btn-primary mt-3" OnClick="btnAddNew_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
