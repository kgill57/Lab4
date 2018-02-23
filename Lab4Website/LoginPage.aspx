<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<<<<<<< HEAD
    <asp:Image id = "headerIMG" runat ="server" ImageUrl ="~/Images/Header.png" width ="100%"/>
    <h1 class="agent-3">Elk Logistics Rewards System</h1>
=======
<center>
    <br />
    <br />
    <asp:Image id = "headerIMG" runat ="server" ImageUrl ="~/Images/elk-logo.png" />
    <%--<h1 style="position:absolute; top:10px; left:700px;">Elk Logistics Rewards System</h1>--%>
>>>>>>> aefeafdec146ea02fab448fb4369b93f1aa3ab6a
    <header>
        <link href="Style/bootstrap.min.css" rel="stylesheet" />
    </header>
<<<<<<< HEAD
    <div class="table">
        <table>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:" CssClass="agent-1"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="agent-1"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="agent-1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="agent-1"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Exit" />
        <asp:Button ID="btnCreateAdmin" runat="server" OnClick="btnCreateAdmin_Click" Text="Create Admin" />
    </div>
        <asp:Label ID="lblError" runat="server"></asp:Label>
=======
    
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
>>>>>>> aefeafdec146ea02fab448fb4369b93f1aa3ab6a
        <br />
</center>



        
        
        
       
        
    
</asp:Content>

