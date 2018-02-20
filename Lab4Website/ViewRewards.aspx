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
            <li> <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></li>
            <li><a href="AdminPage.aspx">Home</a></li>
            <li> <a href ="/UserOptions.aspx">User Options</a></li>
            <li> <a href="/ViewRewards.aspx">View Rewards</a></li>
            <li> <a href ="/AddRewardProviders.aspx">View Reward Providers</a></li>
            <li>Add Community Events</li>
            <li><a href ="LoginPage.aspx">Logout</a></li>
        </ul>
    </div>

    <asp:GridView ID="grdRewards" AutoGenerateColumns="False" runat="server"  DataKeyNames="RewardID" ShowHeaderWhenEmpty="True" AutoGenerateEditButton="True" AutoGenerateDeleteButton="True" OnRowCancelingEdit="grdRewards_RowCancelingEdit" OnRowDeleting="grdRewards_RowDeleting" OnRowEditing="grdRewards_RowEditing" OnRowUpdating="grdRewards_RowUpdating">
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
                <ItemTemplate>
                    <asp:Label ID="lblRewardAmount" runat="server" Text='<%# Eval("RewardAmount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProviderID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtProviderID" runat="server" Text='<%# Eval("ProviderID") %>' ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblProviderID" runat="server" Text='<%# Eval("ProviderID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AdminID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAdminID" runat="server" Text='<%# Eval("AdminID") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DateAdded">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDateAdded" runat="server" Text='<%# Eval("DateAdded") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtRewardID" runat="server" ReadOnly="True" Text='<%# Eval("RewardID") %>'></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateAdded") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label6" runat="server" Text="No Records Found"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <br />

    <table id="tblAddReward">
        <tr>
            <td>
                <asp:Button ID="btnAddReward" runat="server" Text="Add Reward" OnClick="btnAddReward_Click" CausesValidation="False" />
            </td>
            <td>
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" />
            &nbsp;
                <asp:Button ID="RewardAutoFillID" runat="server" OnClick="RewardAutoFillID_Click" Text="AutoFill Reward" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSearch" runat="server" Text="Search for a Reward: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSearch" runat="server"  ></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />
            </td>
        </tr>
    </table>

    <br />

    <asp:Panel ID="rewardPanel" runat="server" Visible="False">
        <table id="newReward">
            <tr>
                <td>
                    <asp:Label ID="lblRewardName" runat="server" Text="Reward Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRewardName" runat="server" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblRewardQuantity" runat="server" Text="Reward Quantity: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRewardQuantity" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:RequiredFieldValidator id="reqRewardName" ControlToValidate="txtRewardName" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
                <td>

                </td>
                <td>
                    <asp:RequiredFieldValidator id="reqRewardQuantity" ControlToValidate="txtRewardQuantity" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRewardAmount" runat="server" Text="Reward Amount: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRewardAmount" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:CompareValidator ID="cmpRewardAmount" ControlToValidate="txtRewardAmount" Type="Currency" Operator="DatatypeCheck" Text="(Invalid Format)" runat="server"></asp:CompareValidator>
                </td>
                <td>
                    <asp:Label ID="lblRewardProvider" runat="server" Text="Reward Provider: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpRewardProvider" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator id="reqRewardAmount" ControlToValidate="txtRewardAmount" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
                <td>

                </td>
                <td>
                    <asp:RequiredFieldValidator id="reqRewardProvider" ControlToValidate="drpRewardProvider" Text="(Required)" runat="server"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

