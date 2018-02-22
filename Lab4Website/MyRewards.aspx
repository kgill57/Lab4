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
            <li><asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <a href="TeamMemberPage.aspx"><li>Home</li></a>
            <a href="RewardTeamMember.aspx"><li>Reward Team Member</li></a>
            <a href="BuyRewards.aspx"><li>Buy Rewards</li></a>
            <a href="AccountSettingTeamMember.aspx"><li>Account Settings</li></a>
            <a href="LoginPage.aspx"><li>Logout</li></a>
        </ul>
    </div>
    
    <br />




     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
         <Columns>
             <asp:TemplateField HeaderText="Reward Name">
                 <ItemTemplate>
                     <asp:Label ID="lblRewardName" runat="server" Text="Label"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Reward Amount">
                 <ItemTemplate>
                     <asp:Label ID="lblRewardAmount" runat="server" Text="Label"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Reward Quantity">
                 <ItemTemplate>
                     <asp:Label ID="lblRewardQuantity" runat="server" Text="Label"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Date Purchased">
                 <ItemTemplate>
                     <asp:Label ID="lblDatePurchased" runat="server" Text="Label"></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>




</asp:Content>
