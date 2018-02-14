<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TeamMemberPage.aspx.cs" Inherits="TeamMemberPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header>
        <link href="Style/desktop.css" rel="stylesheet" />       
    </header>

    <div style="height: 610px">
        <br />
        <asp:Label ID="lblOptions" runat="server" style="font-weight: 700" Text="Options:"></asp:Label>
        <br /><br />
        <asp:Button ID="btnSendReward" style="margin-left: auto; margin-right: auto; margin-top: 0; font-weight: 700;" runat="server" Text="Reward an Employee" />
        <br /><br />
        <asp:Button ID="btnBuyReward" style="margin-left: auto; margin-right: auto; margin-top: 0; font-weight: 700;" runat="server" Text="Buy a Reward" />       
        <br /><br /><br /><br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />

    </div>
</asp:Content>


