﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewRewards.aspx.cs" Inherits="ViewRewards" %>

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
            <li>User Options</li>
            <li>View Rewards</li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
        </ul>
    </div>

    <asp:GridView ID="grdRewards" AutoGenerateColumns="False" runat="server"  DataKeyNames="RewardID" ShowHeaderWhenEmpty="True" AutoGenerateEditButton="True" AutoGenerateDeleteButton="True" >
        <Columns>
            <asp:TemplateField HeaderText="RewardID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" Text='<%# Eval("RewardID") %>' ReadOnly="True"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRewardID" runat="server" Text='<%# Eval("RewardID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RewardName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtRewardName" runat="server" Text='<%# Eval("RewardName") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRewardName" runat="server" Text='<%# Eval("RewardName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RewardQuantity">
                <EditItemTemplate>
                    <asp:TextBox ID="txtRewardQuantity" runat="server" Text='<%# Eval("RewardQuantity") %>' TextMode="MultiLine"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblRewardQuantity" runat="server" Text='<%# Eval("RewardQuantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RewardAmount">
                <EditItemTemplate>
                    <asp:TextBox ID="txtRewardAmount" runat="server" Text='<%# Eval("RewardAmount") %>' ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <asp:ItemTemplate>
                    <asp:Label ID="lblRewardAmount" runat="server" Text='<%# Eval("RewardAmount") %>'></asp:Label>
                </asp:ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProviderID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtProviderID" runat="server" Text='<%# Eval("ProviderID") %>' ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <asp:ItemTemplate>
                    <asp:Label ID="lblProviderID" runat="server" Text='<%# Eval("ProviderID") %>'></asp:Label>
                </asp:ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AdminID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAdminID" runat="server" Text='<%# Eval("AdminID") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <asp:ItemTemplate>
                    <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>'></asp:Label>
                </asp:ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DateAdded">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDateAdded" runat="server" Text='<%# Eval("DateAdded") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <asp:ItemTemplate>
                    <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateAdded") %>'></asp:Label>
                </asp:ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label6" runat="server" Text="No Records Found"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

