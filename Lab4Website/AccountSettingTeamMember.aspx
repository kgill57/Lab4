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
            <li><asp:Image ID ="profilePicture" Height ="200px" Width ="150px" runat ="server"/></li>
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
                <td style="width: 160px">Upload Profile Picture:</td>
                <td>
        
        <asp:FileUpload ID ="UploadPicture" runat ="server" />
        <asp:Button ID ="btnUpload" runat ="server" Text ="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>

    </div>
    <div>

        <table style="width: 100%">
            <tr>
                <td style="width: 160px">Change Password</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
    <div>
        
        <table style="width: 100%">
            <tr>
                <td style="width: 161px">Current Password:</td>
                <td>
                    <asp:TextBox ID="txtCurrentPass" runat="server" Width="200px"></asp:TextBox>
&nbsp;<asp:Label ID="lblCurrentPassMSG" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 161px; height: 20px"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 161px; height: 20px">New Password:</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtNewPass1" runat="server" Width="200px"></asp:TextBox>
&nbsp;<asp:Label ID="lblNewPass1MSG" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 161px">Re-Enter Password:</td>
                <td>
                    <asp:TextBox ID="txtNewPass2" runat="server" Width="200px"></asp:TextBox>
&nbsp;<asp:Label ID="lblNewPass2MSG" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 161px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" Text="Confirm Password Change" Width="200px" />
                </td>
            </tr>
        </table>
        
    </div>
    
    

</asp:Content>
