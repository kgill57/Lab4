<%@ Page Title="Buy Rewards" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuyRewards.aspx.cs" Inherits="BuyRewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <header>        
        <link href="Style/desktop.css" rel="stylesheet" />       
        <script src="Scripts/Sidebar.js"></script>
    </header>

    <div id ="sidebar">
        <div class="toggle-btn" onclick="toggleSidebar();">
            <span></span>
            <span></span>
            <span></span>
        </div>
        <ul>
            <li><asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <a href="TeamMemberPage.aspx"><li>Home</li></a>
            <a href="RewardTeamMember.aspx"><li>Reward Team Member</li></a>
            <a href="BuyRewards.aspx"><li>Buy Rewards</li></a>
            <a href="/LoginPage.aspx"><li>Logout</li></a>
        </ul>
    </div>

    <asp:Button ID="btnBuy" runat="server" Text="Buy Items" OnClick="btnBuy_Click" />
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>

    <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>

    <br />
    <br />

    
</asp:Content>

