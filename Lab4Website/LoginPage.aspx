<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <br />
    <br />
    <asp:Image id = "headerIMG" runat ="server" ImageUrl ="~/Images/elk-logo.png" />
    <%--<h1 style="position:absolute; top:10px; left:700px;">Elk Logistics Rewards System</h1>--%>
    <header>
        <link href="Style/bootstrap.min.css" rel="stylesheet" />
    </header>
    
    <br />
    <br />
    
        <div class="container" style="top:150px">
        <div class="col-lg-4"></div>
        <div class="col-lg-4">
            <div class="jumbotron">
                <div class="form-group">
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button CssClass="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button CssClass="btn btn-secondary" runat="server" OnClick="btnExit_Click" Text="Exit" />
                <asp:Button CssClass="btn btn-secondary" runat="server" OnClick="btnCreateAdmin_Click" Text="Create Admin" />
            </div>
        </div>
        <div class="col-lg-4"></div>
        </div>
    <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
</center>



        
        
        
       
        
    
</asp:Content>

