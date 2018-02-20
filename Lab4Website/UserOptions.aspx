<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserOptions.aspx.cs" Inherits="UserOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Style/desktop.css" rel="stylesheet" />
    <script src="Scripts/Sidebar.js"></script>
    <div id ="sidebar">
        <div class="toggle-btn" onclick="toggleSidebar();">
            <span></span>
            <span></span>
            <span></span>
        </div>
        <ul>
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><a href="AdminPage.aspx">Home</a></li>
            <li> <a href ="/UserOptions.aspx">User Options</a></li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
            <li><a href="LoginPage.aspx">Logout</a></li>
        </ul>
    </div>
    <div>

        <table style="width: 100%">
            <tr>
                <td style="width: 151px">First Name</td>
                <td>
                    <asp:TextBox ID="txtFName" runat="server" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFName" ControlToValidate="txtFName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">MI</td>
                <td>
                    <asp:TextBox ID="txtMI" runat="server" MaxLength="1" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqMI" ControlToValidate="txtMI" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Last Name</td>
                <td>
                    <asp:TextBox ID="txtLName" runat="server" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqLName" ControlToValidate="txtLName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 20px">Username</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUsername" ControlToValidate="txtUsername" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Account Type</td>
                <td>
                    <asp:DropDownList ID="ddlAccountType" runat="server">
                        <asp:ListItem Value="0">User</asp:ListItem>
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Company</td>
                <td>
                    <%--                    <asp:TextBox ID="txtCompany" runat="server" TextMode="Number" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCompany" ControlToValidate="txtCompany" Text="(Required)" runat="server"></asp:RequiredFieldValidator>--%>
                    <asp:DropDownList ID="CompanyDropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="CompanyName" DataValueField="CompanyName">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lab4ConnectionString %>" SelectCommand="SELECT [CompanyName] FROM [Employer]"></asp:SqlDataSource>
                </td>
            </tr>
            
            </table>
            <div>

                <asp:Button ID="btnInsertUser" runat="server" OnClick="btnInsertUser_Click" Text="Insert User" ValidationGroup="ValidEmp" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="AutoFillUser" runat="server" OnClick="Button1_Click" Text="AutoFill User" />

            </div>
        <div>
            <asp:Label ID="lblError" runat="server" Text="No Error"></asp:Label>
        </div>

    </div>
    <br />
    <br />
    <asp:GridView ID="grdUsers" ValidationGroup="validNewEmp" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowCancelingEdit="grdUsers_RowCancelingEdit" OnRowDeleting="grdUsers_RowDeleting" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtFName" runat="server" Text='<%# Eval("FName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtLName" runat="server" Text='<%# Eval("LName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MI">
                <EditItemTemplate>
                    <asp:TextBox ID="txtMI" runat="server" Text='<%# Eval("MI") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblMI" runat="server" Text='<%# Eval("MI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Username">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUsername" runat="server" Text='<%# Eval("Username") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Admin">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblEmptly" runat="server" Text="No Records Available"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

