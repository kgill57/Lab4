﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageCommunityPost.aspx.cs" Inherits="ManageCommunityPost" %>

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
            <li><a href="AnalyticsPage.aspx">View Analytics</a></li>
            <li><a href="/ManageCommunityPost.aspx">Community Events</a></li>
            <li><a href="/Default.aspx">Logout</a></li>
        </ul>
    </div>
    
    
<center>
    <h1 class="display-4">Community Events</h1>
    <div class="jumbotron agent-1" style="width:78%; background-color:lightblue; opacity: 0.83; border-radius:25px; padding-top:1px;">
        <br />
        <br />
        <div style="width:50%;">
            <div class="form-group">
                <asp:TextBox ID="txtEventName" CssClass="form-control" placeholder="Event Title" runat="server" Width="419px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqFName" ControlToValidate="txtEventName" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group"> 
                <asp:TextBox ID="txtEventDesc" runat="server" CssClass="form-control" placeholder="Event Description" MaxLength="30" Height="99px" TextMode="MultiLine" Width="419px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqLName" ControlToValidate="txtEventDesc" Display="Dynamic" Text="(Required)" Font-Bold="true" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
            </div>
            <br />
            <asp:Button ID="btnInsertEvent" CssClass="btn btn-primary" runat="server" OnClick="btnInsertUser_Click" Text="Insert Event" />
            <asp:Button ID="btnAutoFillEvent" CssClass="btn btn-secondary" runat="server" OnClick="btnAutoFillUser_Click" Text="AutoFill Event" CausesValidation="False" />
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <br />

        <div>
            <asp:GridView ID="grdUsers" ValidationGroup="validNewEmp" runat="server" AutoGenerateColumns="False" DataKeyNames="EventPostID" OnRowCancelingEdit="grdUsers_RowCancelingEdit" OnRowDeleting="grdUsers_RowDeleting" OnRowEditing="grdUsers_RowEditing" OnRowUpdating="grdUsers_RowUpdating" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                <Columns>
                     <asp:TemplateField HeaderText="EventID">
                        <EditItemTemplate>
                            <asp:Label ID="txtgvFName" runat="server" MaxLength="30" Text='<%# Eval("EventPostID") %>' Height="22px" Width="136px" ReadOnly="True"></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFName" runat="server" Text='<%# Eval("EventPostID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Event Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="EventTitleEdit" runat="server" MaxLength="30" Text='<%# Eval("EventTitle") %>' Height="22px" Width="122px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqgvTitle" ControlToValidate="EventTitleEdit" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFName" runat="server" Text='<%# Eval("EventTitle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Event Description">
                        <EditItemTemplate>
                            <asp:TextBox ID="EventDescEdit" runat="server" MaxLength="30" Text='<%# Eval("EventDesc") %>' Height="113px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqgvDesc" ControlToValidate="EventDescEdit" Text="(Required)" Display="Dynamic" Runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="validNewEmp"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLName" runat="server" Text='<%# Eval("EventDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Posted">
        
                        <EditItemTemplate>
                            <asp:Label ID="DatePostedtxt" runat="server" Text='<%# Eval("DatePosted") %>' ReadOnly="True"></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="DatePostedlbl" runat="server" Text='<%# Eval("DatePosted") %>' ></asp:Label>
                        </ItemTemplate>
        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Admin">
        
                        <EditItemTemplate>
                            <asp:Label ID="AdminIDtxt" runat="server" Text='<%# Eval("AdminID") %>' ReadOnly="True"></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="AdminIDtxt" runat="server" Text='<%# Eval("AdminID") %>'></asp:Label>
                        </ItemTemplate>
        
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lblEmptly" runat="server" Text="No Records Available"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</center>
        
    
</asp:Content>