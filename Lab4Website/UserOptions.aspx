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
                    <asp:TextBox ID="txtFName" runat="server" ValidationGroup="validEmp" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFName" ControlToValidate="txtFName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">MI</td>
                <td>
                    <asp:TextBox ID="txtMI" runat="server" MaxLength="1" ValidationGroup="validEmp"></asp:TextBox>
<<<<<<< HEAD
                    <asp:RequiredFieldValidator ID="reqMI" ControlToValidate="txtMI" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
=======
>>>>>>> master
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Last Name</td>
                <td>
                    <asp:TextBox ID="txtLName" runat="server" ValidationGroup="validEmp" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqLName" ControlToValidate="txtLName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" ValidationGroup="validEmp" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 20px">Username</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="validEmp" MaxLength="50"></asp:TextBox>
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
<<<<<<< HEAD
                    <asp:TextBox ID="txtCompany" runat="server" TextMode="Number" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCompany" ControlToValidate="txtCompany" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
=======
                    <%--                    <asp:TextBox ID="txtCompany" runat="server" TextMode="Number" ValidationGroup="validEmp"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCompany" ControlToValidate="txtCompany" Text="(Required)" runat="server"></asp:RequiredFieldValidator>--%>
                    <asp:DropDownList ID="CompanyDropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="CompanyName" DataValueField="CompanyName">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lab4ConnectionString %>" SelectCommand="SELECT [CompanyName] FROM [Employer]"></asp:SqlDataSource>
>>>>>>> master
                </td>
            </tr>
            
            </table>
            <div>

                <asp:Button ID="btnInsertUser" runat="server" OnClick="btnInsertUser_Click" Text="Insert User" ValidationGroup="ValidEmp" />

<<<<<<< HEAD
=======
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAutoFillUser" runat="server" OnClick="btnAutoFillUser_Click" Text="AutoFill User" CausesValidation="False" />

>>>>>>> master
            </div>
        <div>
            <asp:Label ID="lblError" runat="server" Text="No Error"></asp:Label>
        </div>

    </div>
    <br />
    <br />
<<<<<<< HEAD
    <asp:GridView ID="grdUsers" ValidationGroup="validNewEmp" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowCancelingEdit="grdUsers_RowCancelingEdit" OnRowDeleting="grdUsers_RowDeleting" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating">
        <Columns>
=======
    <asp:GridView ID="grdUsers" ValidationGroup="validNewEmp" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowCancelingEdit="grdUsers_RowCancelingEdit" OnRowDeleting="grdUsers_RowDeleting" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating">
        <Columns>
            <asp:CommandField ShowEditButton="true" CausesValidation="true" ValidationGroup="validNewEmp"/>
>>>>>>> master
            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
                <EditItemTemplate>
<<<<<<< HEAD
                    <asp:TextBox ID="txtFName" runat="server" Text='<%# Eval("FName") %>'></asp:TextBox>
=======
                    <asp:TextBox ID="txtgvFName" runat="server" Text='<%# Eval("FName") %>'></asp:TextBox>
<<<<<<< HEAD
                    <asp:RequiredFieldValidator ID="reqgvFName" ControlToValidate="txtgvFName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
=======
                    <asp:RequiredFieldValidator ID="reqgvFName" ControlToValidate="txtgvFName" MaxLength="30" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <EditItemTemplate>
<<<<<<< HEAD
                    <asp:TextBox ID="txtLName" runat="server" Text='<%# Eval("LName") %>'></asp:TextBox>
=======
                    <asp:TextBox ID="txtgvLName" runat="server" Text='<%# Eval("LName") %>'></asp:TextBox>
<<<<<<< HEAD
                    <asp:RequiredFieldValidator ID="reqgvLName" ControlToValidate="txtgvLName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
=======
                    <asp:RequiredFieldValidator ID="reqgvLName" ControlToValidate="txtgvLName" MaxLength="30" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLName" runat="server" Text='<%# Eval("LName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MI">
                <EditItemTemplate>
<<<<<<< HEAD
<<<<<<< HEAD
                    <asp:TextBox ID="txtMI" runat="server" Text='<%# Eval("MI") %>'></asp:TextBox>
=======
                    <asp:TextBox ID="txtgvMI" runat="server" Text='<%# Eval("MI") %>'></asp:TextBox>
>>>>>>> master
=======
                    <asp:TextBox ID="txtgvMI" runat="server" MaxLength="1" Text='<%# Eval("MI") %>'></asp:TextBox>
>>>>>>> master
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblMI" runat="server" Text='<%# Eval("MI") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <EditItemTemplate>
<<<<<<< HEAD
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
=======
                    <asp:TextBox ID="txtgvEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
<<<<<<< HEAD
                    <asp:RequiredFieldValidator ID="reqgvEmail" ControlToValidate="txtgvEmail" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
=======
                    <asp:RequiredFieldValidator ID="reqgvEmail" ControlToValidate="txtgvEmail" MaxLength="50" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Username">
                <EditItemTemplate>
<<<<<<< HEAD
                    <asp:TextBox ID="txtUsername" runat="server" Text='<%# Eval("Username") %>'></asp:TextBox>
=======
                    <asp:TextBox ID="txtgvUsername" runat="server" Text='<%# Eval("Username") %>'></asp:TextBox>
<<<<<<< HEAD
                    <asp:RequiredFieldValidator ID="reqgvUsername" ControlToValidate="txtgvUsername" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
=======
                    <asp:RequiredFieldValidator ID="reqgvUsername" ControlToValidate="txtgvUsername" MaxLength="50" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Admin">
                <EditItemTemplate>
<<<<<<< HEAD
<<<<<<< HEAD
                    <asp:TextBox ID="txtAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:TextBox>
=======
                    <asp:TextBox ID="txtgvAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqgvAdmin" ControlToValidate="txtgvAdmin" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
=======
                    <asp:DropDownList ID="ddlgvAdmin" runat="server" SelectedValue='<%# Bind("Admin") %>'>
                        <asp:ListItem Value="0">User</asp:ListItem>
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqgvAdmin" ControlToValidate="ddlgvAdmin" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
>>>>>>> master
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdmin" runat="server" Text='<%# Eval("Admin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
<<<<<<< HEAD
            <asp:Label ID="lblEmptly" runat="server" Text="No Records Available"></asp:Label>
=======
            <asp:Label ID="lblEmpty" runat="server" Text="No Records Available"></asp:Label>
>>>>>>> master
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

