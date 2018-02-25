<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TeamMemberPage.aspx.cs" Inherits="TeamMemberPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <li><a href="TeamMemberPage.aspx">Home</a></li>
            <li> <a href="RewardTeamMember.aspx">Reward Team Member</a></li>
            <li> <a href="BuyRewards.aspx">Buy Rewards</a></li>
            <li> <a href="MyRewards.aspx">My Rewards</a></li>
            <li><a href="AccountSettingTeamMember.aspx">Account Settings</a></li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>
<<<<<<< HEAD

    <asp:Image id = "headerIMG" runat ="server" ImageUrl ="~/Images/Header.png" width ="100%"/>
    <h1>Elk Logistics Rewards System</h1>

    <div style="height: 610px">

        <br /><br />
        
        <h2><asp:Label ID="lblPostFeed" runat="server" style="font-weight: 700; font-size: xx-large;" Text="Recent Posts"></asp:Label></h2>        
        <p>
            <asp:DropDownList ID="giverAndReceiver" runat="server" OnSelectedIndexChanged="giverAndReceiver_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Show All Rewards</asp:ListItem>
                <asp:ListItem>Show Your Rewards Given</asp:ListItem>
                <asp:ListItem>Show Your Rewards Received</asp:ListItem>
            </asp:DropDownList>
        </p>
=======
    <h1 class="display-4" style="color:white; font: bold;">News Feed</h1>
    <div class="jumbotron jumbotron-fluid" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px; height:1000px;">
        <br />
        <br />
>>>>>>> master
        <div>
            <asp:DropDownList ID="giverAndReceiver" runat="server" OnSelectedIndexChanged="giverAndReceiver_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>All Transactions</asp:ListItem>
                <asp:ListItem>Your Transactions</asp:ListItem>
                <asp:ListItem>Your Rewards Given</asp:ListItem>
                <asp:ListItem>Your Rewards Received</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div class="container" style="padding-top: -20px;">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
    </div>
</center>

</asp:Content>
