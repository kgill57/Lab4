<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountSettingTeamMember.aspx.cs" Inherits="AccountSettingTeamMember" %>
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
            <li><asp:Image ID ="profilePicture" Height ="200px" Width ="150px" runat ="server"/></li>
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><a href="TeamMemberPage.aspx">Home</a></li>
            <li> <a href="RewardTeamMember.aspx">Reward Team Member</a></li>
            <li> <a href="BuyRewards.aspx">Buy Rewards</a></li>
            <li> <a href="MyRewards.aspx">My Rewards</a></li>
            <li><a href="AccountSettingTeamMember.aspx">Account Settings</a></li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>

<center>
    <h1 class="display-4">Account Settings</h1>
    <div class="jumbotron" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px; height:1000px;">
        <br />
        <br />
        <div>
            <div class="form-group">
                <table >
                    <tr>
                        <td style="width: 160px">Upload Profile Picture:</td>
                        <td>   
                            <asp:FileUpload ID ="UploadPicture" runat ="server" />
                            <asp:Button ID ="btnUpload" runat ="server" Text ="Upload" OnClick="btnUpload_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtCurrentPass" CssClass="form-control" placeholder="Current Password" runat="server" Width="200px"></asp:TextBox>
            </div>
            <div class="form-group">
                 <asp:TextBox ID="txtNewPass1" CssClass="form-control" placeholder="New Password" runat="server" Width="200px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtNewPass2" CssClass="form-control" placeholder="Confirm New Password" runat="server" Width="200px"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnChangePass" runat="server" OnClick="btnChangePass_Click" Text="Confirm Password Change" Width="200px" />
            </div>
        </div>
    </div>
</center>
    
        <h2><asp:Label ID="lblPostFeed" runat="server" style="font-weight: 700; font-size: xx-large;" Text="Account Settings"></asp:Label></h2>        
    <div>
        
        
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
                   
&nbsp;<asp:Label ID="lblNewPass1MSG" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 161px">Re-Enter Password:</td>
                <td>
                    
&nbsp;<asp:Label ID="lblNewPass2MSG" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 161px">&nbsp;</td>
                <td>
                    
                </td>
            </tr>
        </table>
        
    </div>
    
    

</asp:Content>
