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
            <li><asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <a href="TeamMemberPage.aspx"><li>Home</li></a>
            <a href="RewardTeamMember.aspx"><li>Reward Team Member</li></a>
            <a href="BuyRewards.aspx"><li>Buy Rewards</li></a>
            <a href="/LoginPage.aspx"><li>Logout</li></a>
        </ul>
    </div>

    <div style="height: 610px">

        <br /><br />

        <h2><asp:Label ID="lblPostFeed" runat="server" style="font-weight: 700; font-size: xx-large;" Text="Recent Posts"></asp:Label></h2>        

        <div>

            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>

        </div>
    </div>

<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
</asp:Content>


