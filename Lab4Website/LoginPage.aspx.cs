using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    string adminUser = "admin";
    string adminPass = "admin";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if(txtUsername.Text.Equals(adminUser) && txtPassword.Text.Equals(adminPass))
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}