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
            <li>View Rewards</li>
            <li> <a href ="/ViewRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
        </ul>
    </div>
    
</asp:Content>


