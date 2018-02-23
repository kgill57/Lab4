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
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><a href="AdminPage.aspx">Home</a></li>
            <li> <a href ="/UserOptions.aspx">User Options</a></li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>
    <asp:Image id = "headerIMG" runat ="server" ImageUrl ="~/Images/Header.png" width ="100%"/>
    <h1>Elk Logistics Rewards System</h1>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>

    

</asp:Content>


