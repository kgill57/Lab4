﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRewardProviders.aspx.cs" Inherits="AddRewardProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
    <link href="Style/desktop.css" rel="stylesheet" />
    <script src="Scripts/Sidebar.js"></script>
     <div id ="sidebar">
        <div class="toggle-btn" onclick="toggleSidebar();">
            <span></span>
            <span></span>
            <span></span>
        </div>
        <ul>
            <li><asp:Image ID ="profilePicture" Height ="120px" Width ="120px" runat ="server"/></li>
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><asp:Label ID="lblBalance" runat="server" ></asp:Label></li>
            <li><a href="AdminPage.aspx">Home</a></li>
            <li> <a href ="/UserOptions.aspx">User Options</a></li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li><a href="/ManageCommunityPost.aspx">Community Events</a></li>
            <li><a href="/LoginPage.aspx">Logout</a></li>
        </ul>
    </div>
    
<center>
    <h1 class="display-4">Reward Provider Options</h1>
    <div class="jumbotron" style="width:78%; height:1000px; background-color:lightblue; opacity:0.88;">
        <div style="float:left;">
            <asp:Button ID="btnAddProvider" CssClass="btn btn-primary" runat="server" OnClick="btnAddProvider_Click1" Text="Add Reward Provider" CausesValidation="False" />
            <asp:Button ID="btnClear" CssClass="btn btn-secondary" runat="server" Text="Clear" CausesValidation="False" OnClick="btnClear_Click1" />
            <asp:Button ID="AutoFillRewardProviderID" CssClass="btn btn-secondary" runat="server" OnClick="AutoFillRewardProviderID_Click" CausesValidation="false" Text="AutoFillRewardProvider"  />
        </div>
        <br />
        <br />
        <asp:Panel ID="providerPanel" runat="server" Visible="false">
            <div>
                <div class="form-group">
                    <asp:TextBox ID="txtNewProviderName" placeholder="Provider Name" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqProviderName"  ControlToValidate="txtNewProviderName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtNewProviderEmail" placeholder="Provider Email" runat="server"  TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqProviderEmail" ControlToValidate="txtNewProviderEmail" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" OnClick="btnAdd_Click1" Text="Add"  />
                </div>
            </div>
        </asp:Panel>
        <br />
        <br />
        <asp:TextBox ID="txtSearch"  placeholder="Search" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
        <br />
        <br />

        <asp:Label ID="lblResult" runat="server"></asp:Label>

        <div id="RewardProviderGrid">
        <asp:GridView ID="grdProviders" ValidationGroup="validNewProvider" AutoGenerateColumns="False" runat="server" style="left: 311px; top: 799px" Width="545px" 
                         OnRowCancelingEdit="grdProviders_RowCancelingEdit" OnRowEditing="grdProviders_RowEditing" OnRowUpdating="grdProviders_RowUpdating" DataKeyNames="ProviderID" ShowHeaderWhenEmpty="True" OnRowDeleting="grdProviders_RowDeleting" AutoGenerateDeleteButton="True">
                        <Columns>                            
                            <asp:CommandField ShowEditButton="true" CausesValidation="true" ValidationGroup="validNewProvider"/>
                            <asp:TemplateField HeaderText="Provider ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvProviderID" runat="server" Text='<%# Eval("ProviderID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Provider Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtgvProviderName" runat="server" Text='<%# Eval("ProviderName") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqgvProviderName" ControlToValidate="txtgvProviderName" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewProvider"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvProviderName" runat="server" Text='<%# Eval("ProviderName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Provider Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtgvProviderEmail" runat="server" Text='<%# Eval("ProviderEmail") %>' TextMode="SingleLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqgvProviderEmail" ControlToValidate="txtgvProviderEmail" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewProvider"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblgvProviderEmail" runat="server" Text='<%# Eval("ProviderEmail") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lvlgvNoProvider" runat="server" Text="No Records Found"></asp:Label>
                        </EmptyDataTemplate>
                        </asp:GridView>
    </div>

    </div>
</center>
    
    
                
                
                    
                
        
    

    
</asp:Content>

