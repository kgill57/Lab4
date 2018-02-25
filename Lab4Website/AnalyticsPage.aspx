<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AnalyticsPage.aspx.cs" Inherits="AnalyticsPage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


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
            <li><a href="CommunityPostFeed.aspx">Commuity Post Feed</a></li>
            <li><a href="AccountSettingTeamMember.aspx">Account Settings</a></li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>
    <center>
    <h1 class="display-4" style="color:white; font: bold;">News Feed</h1>
    <div class="jumbotron jumbotron-fluid" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px; height:1000px;">
        <br />
        <br />
        <div>
            <asp:DropDownList ID="giverAndReceiver" runat="server" OnSelectedIndexChanged="giverAndReceiver_SelectedIndexChanged" AutoPostBack="True" Width="476px">
                <asp:ListItem>Amount of each Reward</asp:ListItem>
                <asp:ListItem>Number of Event Posts per Day</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div class="container" style="padding-top: -20px;">
            <asp:Chart ID="Chart1" runat="server" DataSourceID="lab4ConnectionString" Height="489px" Width="1020px"> 
                <Series>
                    <asp:Series Name="Series1" XValueMember="RewardName" YValueMembers="RewardQuantity"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="lab4connectionstring" runat="server" ConnectionString="<%$ ConnectionStrings:lab4ConnectionString %>" SelectCommand="SELECT [RewardName], [RewardQuantity] FROM [Reward]"></asp:SqlDataSource>
            
            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1"  Height="489px" Width="1020px">
                <Series>
                    <asp:Series Name="Series1" XValueMember="DatePosted" YValueMembers="EventPostID" ChartType="Area"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lab4ConnectionString %>" SelectCommand="SELECT [EventPostID], [DatePosted] FROM [EventPost]"></asp:SqlDataSource>
           
        </div>
    </div>
</center>

</asp:Content>

