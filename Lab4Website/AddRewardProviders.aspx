<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRewardProviders.aspx.cs" Inherits="AddRewardProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <link href="Style/desktop.css" rel="stylesheet" />
    <script src="Scripts/Sidebar.js"></script>
    <div id ="sidebar">
        <div class="toggle-btn" onclick="toggleSidebar();">
            <span></span>
            <span></span>
            <span></span>
        </div>
        <ul>
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><a href="AdminPage.aspx">Home</a></li>
            <li> <a href ="/UserOptions.aspx">User Options</a></li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
            <li><a href="LoginPage.aspx">Logout</a></li>
        </ul>
    </div>


    <table style="width: 100%">
        <tr>
            <td style="width: 241px">
                &nbsp;</td>
            <td>
            &nbsp;</td>
        </tr>
    </table>
    <br />
    <div id="RewardProviderGrid">
        <table>
            <tr>
                <td>
                     <asp:GridView ID="grdProviders" AutoGenerateColumns="False" runat="server"  style="left: 311px; top: 799px" Width="545px" 
                         OnRowCancelingEdit="grdProviders_RowCancelingEdit" OnRowEditing="grdProviders_RowEditing" OnRowUpdating="grdProviders_RowUpdating" AutoGenerateEditButton="True" DataKeyNames="ProviderID" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField HeaderText="ProviderID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProviderID" runat="server" Text='<%# Eval("ProviderID") %>' ReadOnly="True"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtProviderID" runat="server" ReadOnly="True" Text='<%# Eval("ProviderID") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProviderID" runat="server" Text='<%# Eval("ProviderID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProviderName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Eval("ProviderName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtProviderID" runat="server" ReadOnly="True" Text='<%# Eval("ProviderID") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProviderName" runat="server" Text='<%# Eval("ProviderName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProviderEmail">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtProviderEmail" runat="server" Text='<%# Eval("ProviderEmail") %>' TextMode="MultiLine"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtProviderID" runat="server" ReadOnly="True" Text='<%# Eval("ProviderID") %>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProviderEmail" runat="server" Text='<%# Eval("ProviderEmail") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label6" runat="server" Text="No Records Found"></asp:Label>
                        </EmptyDataTemplate>
                        </asp:GridView>
                </td>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text="Search for a project: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" runat="server">Subway</asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
                </td>
                
            </tr>
        </table>
       
        <br />
        <div id="tblNewProvider">
            <table  style="width: 100%">
                <tr>
                    <td style="width: 115px">
                        <asp:Button ID="btnAddProvider" runat="server" OnClick="btnAddProvider_Click1" Text="Add Reward Provider" CausesValidation="False" />
                    </td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click1" />
                    &nbsp;&nbsp;
                        <asp:Button ID="AutoFillRewardProviderID" runat="server" OnClick="AutoFillRewardProviderID_Click" Text="AutoFillRewardProvider" Width="167px" />
                    </td>
                </tr>
                <tr>
                    <td width: "10px">
                        <asp:Label ID="lblProviderName" runat="server" Text="Provider Name: " Visible="False"></asp:Label>
                    </td>
                    <td style="width: 80px">
                        <asp:TextBox ID="txtNewProviderName" runat="server" style="margin-left: 0px" Visible="False">Starbucks</asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqProviderName" ControlToValidate="txtNewProviderName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 115px">
                        <asp:Label ID="lblProviderEmail" runat="server" Text="Provider Email: " Visible="False"></asp:Label>
                    </td>
                    <td style="width: 20px">
                        <asp:TextBox ID="txtNewProviderEmail" runat="server" Visible="False" TextMode="Email">Starbucks@gmail.com</asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqProviderEmail" ControlToValidate="txtNewProviderEmail" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                    </td>
                    <td style="width: 145px">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="Add" Visible="False" />
                    </td>
                </tr>
            </table>
    </div>
    </div>
    <asp:Label ID="lblResult" runat="server"></asp:Label>

    
</asp:Content>

