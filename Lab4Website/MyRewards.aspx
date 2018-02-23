<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyRewards.aspx.cs" Inherits="MyRewards" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
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
    <br />

    <h3>My Rewards</h3>

    <div class="gridview">
        <asp:GridView ID="grdMyRewards" runat="server" AutoGenerateColumns="False">
             <Columns>
                 <asp:TemplateField HeaderText="Reward Name">
                     <ItemTemplate>
                         <asp:Label ID="lblRewardName" runat="server" Text='<%# Eval("RewardName") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Reward Amount">
                     <ItemTemplate>
                         <asp:Label ID="lblRewardAmount" runat="server" Text='<%# Eval("RewardAmount") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Date Purchased">
                     <ItemTemplate>
                         <asp:Label ID="lblDatePurchased" runat="server" Text='<%# Eval("DateClaimed") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
        </asp:GridView>
    </div>
     




</asp:Content>
