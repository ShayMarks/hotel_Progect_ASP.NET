<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="HotelManagementSystem.Pages.EmployeeManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h2>Employee Management</h2>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" OnRowEditing="gvEmployees_RowEditing"
                    OnRowUpdating="gvEmployees_RowUpdating" OnRowCancelingEdit="gvEmployees_RowCancelingEdit"
                    OnRowDeleting="gvEmployees_RowDeleting" DataKeyNames="UserID" CssClass="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Username">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUsernameEdit" runat="server" Text='<%# Bind("Username") %>' CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>' CssClass="form-control-plaintext"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPasswordEdit" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPasswordItem" runat="server" Text="********" CssClass="form-control-plaintext"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Role">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRoleEdit" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                    <asp:ListItem Value="TeamLeader">Team Leader</asp:ListItem>
                                    <asp:ListItem Value="Manager">Manager</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRoleItem" runat="server" Text='<%# Bind("Role") %>' CssClass="form-control-plaintext"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" CssClass="btn btn-primary mt-3" OnClick="btnAddEmployee_Click" />
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back to Default" CssClass="btn btn-secondary mt-3" OnClick="btnBackToDefault_Click" />
            </div>
        </div>

        <asp:Panel ID="pnlAddEditEmployee" runat="server" Visible="False" class="card mt-5">
            <div class="card-header">
                <h3><asp:Label ID="lblAddEditEmployee" runat="server" Text="Add/Edit Employee"></asp:Label></h3>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <asp:Label ID="lblUsernameNew" runat="server" Text="Username:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPasswordNew" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblRoleNew" runat="server" Text="Role:" CssClass="form-label"></asp:Label>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Employee">Employee</asp:ListItem>
                        <asp:ListItem Value="TeamLeader">Team Leader</asp:ListItem>
                        <asp:ListItem Value="Manager">Manager</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" />
            </div>
        </asp:Panel>
    </form>
    <script src="~/Content/bootstrap.min.js"></script>
</body>
</html>
