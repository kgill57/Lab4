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
            <li><asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label></li>
            <a href="TeamMemberPage.aspx"><li>Home</li></a>
            <a href="#"><li>Buy Rewards</li></a>
            <a href="LoginPage.aspx"><li>Logout</li></a>
            <a href="TeamMemberPage.aspx"><li>See Reward Posts</li></a>
            <a href="#"><li>Buy Rewards</li></a>
        </ul>
    </div>

    <div style="height: 610px">

        <br /><br />

        <h2><asp:Label ID="lblRewardTeamMember" runat="server" style="font-weight: 700; font-size: xx-large;" Text="Reward Team Member"></asp:Label></h2>

        <br />

        <asp:Label ID="lblCompanyValue" runat="server" style="font-weight: 700" Text="Company Value: "></asp:Label>
        <asp:DropDownList ID="ddlCompanyValue" runat="server" AutoPostBack="true">
            <asp:ListItem Value="Health, Well Being and Safety of Team Members">Health, Well Being and Safety of Team Members</asp:ListItem>
            <asp:ListItem>Community Involvement</asp:ListItem>
            <asp:ListItem>Customer Service and Retention/Attracting New Customers</asp:ListItem>
            <asp:ListItem>Process Improvement Initiatives</asp:ListItem>
            <asp:ListItem>Leadership Development/Mentoring/Team Building/Education</asp:ListItem>
        </asp:DropDownList>

        <br /> 

        <asp:RequiredFieldValidator ID="reqCompanyValue" ControlToValidate="ddlCompanyValue" Text="(Required)" Display="Dynamic" runat ="server" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>

        <br /><br />
       
        <asp:Label ID="lblCategory" runat="server" style="font-weight: 700" Text="Category: "></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true">
            <asp:ListItem>Creative</asp:ListItem>
            <asp:ListItem>Distinguished</asp:ListItem>
            <asp:ListItem>Exceptional</asp:ListItem>
            <asp:ListItem>Fresh Approach</asp:ListItem>
            <asp:ListItem>Superior</asp:ListItem>
            <asp:ListItem>Ingenious</asp:ListItem>
            <asp:ListItem>Incomparable</asp:ListItem>
            <asp:ListItem>Outstanding</asp:ListItem>
            <asp:ListItem>Surprising</asp:ListItem>
            <asp:ListItem>Symbolic</asp:ListItem>
            <asp:ListItem>Unexpected</asp:ListItem>
        </asp:DropDownList>

        <br /> 

        <asp:RequiredFieldValidator ID="reqCategory" ControlToValidate="ddlCategory" Text="(Required)" Display="Dynamic" runat ="server" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>

        <br /><br />

        <asp:Label ID="lblDescription" runat="server" Text="Description: " style="font-weight: 700"></asp:Label>      
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

        <br /><br />

        <asp:Label ID="lblRewardValue" runat="server" Text="Reward Value: " style="font-weight: 700"></asp:Label>      
        <asp:DropDownList ID="ddlRewardValue" runat="server" AutoPostBack="true">
            <asp:ListItem Value="10">$10</asp:ListItem>
            <asp:ListItem Value="25">$25</asp:ListItem>
            <asp:ListItem Value="50">$50</asp:ListItem>
        </asp:DropDownList>

        <br />

        <asp:RequiredFieldValidator ID="reqRewardValue" ControlToValidate="ddlRewardValue" Text="(Required)" Display="Dynamic" runat ="server" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>

        <br /><br />

        <asp:CheckBox ID="chkPrivate" runat="server" AutoPostBack="True" style="font-weight: 700" Text="Should Transaction Be Private?" />

        <br /><br />

        <asp:Label ID="lblReceiver" runat="server" Text="Team Member Being Rewarded: " style="font-weight: 700"></asp:Label>      

        <asp:DropDownList ID="drpUsernames" runat="server">
        </asp:DropDownList>

        <br /><br /><br /><br /><br />
          
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Reward" OnClick="btnSubmit_Click" />

        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

    </div>
</asp:Content>

