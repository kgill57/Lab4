<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CommunityPostFeed.aspx.cs" Inherits="CommunityPostFeed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
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
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>

<center>
    <h1 class="display-4">Community Events</h1>
    <div class="jumbotron" style="width:78%; height:1000px; background-color:lightblue; opacity:0.88;">
        <div>
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </div>
    </div>
</center>


</asp:Content>

