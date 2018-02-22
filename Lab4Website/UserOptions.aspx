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
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFName" ControlToValidate="txtFName" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">MI</td>
                <td>
                    <asp:TextBox ID="txtMI" runat="server" MaxLength="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Last Name</td>
                <td>
                    <asp:TextBox ID="txtLName" runat="server" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqLName" ControlToValidate="txtLName" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 20px">Username</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtUsername" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUsername" ControlToValidate="txtUsername" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
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

                <asp:Button ID="btnInsertUser" runat="server" OnClick="btnInsertUser_Click" Text="Insert User" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAutoFillUser" runat="server" OnClick="btnAutoFillUser_Click" Text="AutoFill User" CausesValidation="False" />

            </div>
        <div>
            <asp:Label ID="lblError" runat="server" Text="No Error"></asp:Label>
        </div>

    </div>
    <br />
    <br />
    <asp:GridView ID="grdUsers" ValidationGroup="validNewEmp" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowCancelingEdit="grdUsers_RowCancelingEdit" OnRowDeleting="grdUsers_RowDeleting" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating">
        <Columns>
            <asp:CommandField ShowEditButton="true" CausesValidation="true" ValidationGroup="validNewEmp"/>
            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtgvFName" runat="server" MaxLength="30" Text='<%# Eval("FName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqgvFName" ControlToValidate="txtgvFName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtgvLName" runat="server" MaxLength="30" Text='<%# Eval("LName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqgvLName" ControlToValidate="txtgvLName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MI">
                <EditItemTemplate>
                    <asp:TextBox ID="txtgvMI" runat="server" MaxLength="1" Text='<%# Eval("MI") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblMI" runat="server" Text='<%# Eval("MI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <EditItemTemplate>
                    <asp:TextBox ID="txtgvEmail" runat="server" MaxLength="50" Text='<%# Eval("Email") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqgvEmail" ControlToValidate="txtgvEmail" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Username">
                <EditItemTemplate>
                    <asp:TextBox ID="txtgvUsername" runat="server" MaxLength="50" Text='<%# Eval("Username") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqgvUsername" ControlToValidate="txtgvUsername" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Admin">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlgvAdmin" runat="server" SelectedValue='<%# Bind("Admin") %>'>
                        <asp:ListItem Value="0">User</asp:ListItem>
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqgvAdmin" ControlToValidate="ddlgvAdmin" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblEmpty" runat="server" Text="No Records Available"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

