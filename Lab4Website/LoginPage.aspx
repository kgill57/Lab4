<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Image id = "headerIMG" runat ="server" ImageUrl ="~/Images/Header.png" width ="100%"/>
    <h1 class="agent-3">Elk Logistics Rewards System</h1>
    <header>
        <link href="Style/desktop.css" rel="stylesheet" />
        
    </header>
    <div class="table">
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:" CssClass="agent-1"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="agent-1"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="agent-1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="agent-1"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Exit" />
        <asp:Button ID="btnCreateAdmin" runat="server" OnClick="btnCreateAdmin_Click" Text="Create Admin" />
    </div>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
    
</asp:Content>

