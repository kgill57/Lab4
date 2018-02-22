<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountSettingTeamMember.aspx.cs" Inherits="AccountSettingTeamMember" %>

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
            <a href="LoginPage.aspx"><li>Logout</li></a>
        </ul>
    </div>
        <h2><asp:Label ID="lblPostFeed" runat="server" style="font-weight: 700; font-size: xx-large;" Text="Account Settings"></asp:Label></h2>        

    <div>

        <table style="width: 100%">
            <tr>
                <td style="width: 107px">First Name:</td>
                <td style="width: 204px">
                    <asp:Label ID="lblCurrentFName" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 189px">
                    <asp:Button ID="btnEditFName" runat="server" OnClick="btnEditFName_Click" Text="Edit First Name" Width="170px" />
                </td>
                <td style="width: 239px">
                    <asp:TextBox ID="txtNewFName" runat="server" Visible="False" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnFName" runat="server" OnClick="btnFName_Click" Text="Confirm" Visible="False" />
                </td>
                <td>

                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td style="width: 107px">MI:</td>
                <td style="width: 204px">
                    <asp:Label ID="lblCurrentMI" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 189px">
                    <asp:Button ID="btnEditMI" runat="server" OnClick="btnEditMI_Click" Text="Edit MI" Width="170px" />
                </td>
                <td style="width: 239px">
                    <asp:TextBox ID="txtNewMI" runat="server" Visible="False" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnMI" runat="server" OnClick="btnMI_Click" Text="Confirm" Visible="False" />
                </td>
                <td>

                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td style="width: 107px">Last Name:</td>
                <td style="width: 204px">
                    <asp:Label ID="lblCurrentLName" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 189px">
                    <asp:Button ID="btnEditLName" runat="server" OnClick="btnEditLName_Click" Text="Edit Last Name" Width="170px" />
                </td>
                <td style="width: 239px">
                    <asp:TextBox ID="txtNewLName" runat="server" Visible="False" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnLName" runat="server" OnClick="btnLName_Click" Text="Confirm" Visible="False" />
                </td>
                <td>

                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td style="width: 107px">Email:</td>
                <td style="width: 204px">
                    <asp:Label ID="lblCurrentEmail" runat="server" Text="Label"></asp:Label>
                </td>
                <td style="width: 189px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit Email " Width="170px" />
                </td>
                <td style="width: 239px">
                    <asp:TextBox ID="txtNewEmail" runat="server" Visible="False" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnEmail" runat="server" OnClick="btnEmail_Click" Text="Confirm" Visible="False" />
                </td>
                <td>

                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Autofill_account_settings" />
                </td>
            </tr>
            </table>

    </div>
    
    

</asp:Content>
