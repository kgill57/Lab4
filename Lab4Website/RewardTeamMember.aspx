<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RewardTeamMember.aspx.cs" Inherits="RewardTeamMember" %>

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
            <a href="TeamMemberPage.aspx"><li>See Reward Posts</li></a>
            <a href="#"><li>Buy Rewards</li></a>
        </ul>
    </div>

    <div style="height: 610px">

        <br /><br />

        <h2><asp:Label ID="lblRewardTeamMember" runat="server" style="font-weight: 700; font-size: xx-large;" Text="Reward Team Member"></asp:Label></h2>

        <br />

        <asp:Label ID="lblCompanyValue" runat="server" style="font-weight: 700" Text="Company Value:"></asp:Label>
        <asp:TextBox ID="txtCompanyValue" runat="server"></asp:TextBox>

        <br /> <br /><br />
       
        <asp:Label ID="lblCategory" runat="server" style="font-weight: 700" Text="Category: "></asp:Label>
        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>

        <br /><br /><br />

        <asp:Label ID="lblDescription" runat="server" Text="Description: " style="font-weight: 700"></asp:Label>      
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

        <br /><br /><br />

        <asp:Label ID="lblRewardValue" runat="server" Text="Reward Value: " style="font-weight: 700"></asp:Label>      
        <asp:DropDownList ID="ddlRewardValue" runat="server">
            <asp:ListItem>$10</asp:ListItem>
            <asp:ListItem>$25</asp:ListItem>
            <asp:ListItem>$50</asp:ListItem>
        </asp:DropDownList>

        <br /><br /><br />

        <asp:Label ID="lblReceiver" runat="server" Text="Team Member Being Rewarded: " style="font-weight: 700"></asp:Label>      
        <asp:TextBox ID="txtReceiver" runat="server" OnTextChanged="txtReceiver_TextChanged"></asp:TextBox>

        <br /><br /><br /><br /><br />
          
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Reward" />

    </div>
</asp:Content>

