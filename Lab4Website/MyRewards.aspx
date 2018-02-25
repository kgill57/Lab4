﻿<%@ Page Title="Your Rewards" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyRewards.aspx.cs" Inherits="MyRewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <li><a href="TeamMemberPage.aspx">Home</a></li>
            <li> <a href="RewardTeamMember.aspx">Reward Team Member</a></li>
            <li> <a href="BuyRewards.aspx">Buy Rewards</a></li>
            <li> <a href="MyRewards.aspx">My Rewards</a></li>
            <li><a href="AccountSettingTeamMember.aspx">Account Settings</a></li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>

<<<<<<< HEAD
    <h3>My Rewards</h3>
    <div>

        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>

    </div>

    
    
     
=======
<center>
    <h1 class="display-4">Your Rewards</h1>
    <div class="jumbotron" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px; height:1000px;">       
        <div class="container">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
    </div>
</center>
    
>>>>>>> master

    

    

    <br />
    <br />

    
</asp:Content>

