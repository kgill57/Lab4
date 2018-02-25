<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <link href="Style/desktop.css" rel="stylesheet" />
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
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
            <li><a href="/CommunityPostFeed.aspx">Community Events</a></li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>
    <h1 class="display-4" style="color:white; font: bold;">News Feed</h1>
    <div class="jumbotron jumbotron-fluid" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px;">
        <div class="container" style="padding-top: -20px;">
            <asp:Panel ID="Panel1" runat="server" ></asp:Panel>
        </div>
    </div>
</center>
</asp:Content>


