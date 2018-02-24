<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TeamMemberPage.aspx.cs" Inherits="TeamMemberPage" %>

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
            <li><asp:Image ID ="profilePicture" Height ="200px" Width ="150px" runat ="server"/></li>
            <li><asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <a href="TeamMemberPage.aspx"><li>Home</li></a>
            <a href="RewardTeamMember.aspx"><li>Reward Team Member</li></a>
            <a href="BuyRewards.aspx"><li>Buy Rewards</li></a>
            <a href="MyRewards.aspx"><li>My Rewards</li></a>
            <a href="AccountSettingTeamMember.aspx"><li>Account Settings</li></a>
            <a href="LoginPage.aspx"><li>Logout</li></a>
        </ul>
    </div>

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
        <div>

            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>

        </div>
    </div>


</asp:Content>
