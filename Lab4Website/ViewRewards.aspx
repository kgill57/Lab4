<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewRewards.aspx.cs" Inherits="ViewRewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="grdRewards" AutoGenerateColumns="False" runat="server"  style="left: 311px; top: 799px" Width="545px" >
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

