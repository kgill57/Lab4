<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Style/desktop.css" rel="stylesheet" />
    <script src="Scripts/Sidebar.js"></script>
    <div id ="sidebar">
        <div class="toggle-btn" onclick="toggleSidebar();">
            <span></span>
            <span></span>
            <span></span>
        </div>
        <ul>
            <li>User Options</li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/ViewRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
        </ul>
    </div>

    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>
    <asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

</asp:Content>


