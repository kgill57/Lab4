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
                    <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFName" ControlToValidate="txtFName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">MI</td>
                <td>
                    <asp:TextBox ID="txtMI" runat="server" MaxLength="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqMI" ControlToValidate="txtMI" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Last Name</td>
                <td>
                    <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqLName" ControlToValidate="txtLName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtEmail" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 151px; height: 20px">Username</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
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
                    <asp:TextBox ID="txtCompany" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCompany" ControlToValidate="txtCompany" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            </table>
            <div>

                <asp:Button ID="btnInsertUser" runat="server" OnClick="btnInsertUser_Click" Text="Insert User" />

            </div>
        <div>

            <asp:Label ID="lblError" runat="server" Text="No Error"></asp:Label>

        </div>

    </div>
</asp:Content>

