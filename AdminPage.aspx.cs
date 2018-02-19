using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];


        lblSession.Text = Convert.ToString((int)Session["UserID"]);
        lbl1.Text = (String)(Session["FName"]);
        Label1.Text = (String)(Session["LName"]);
        Label2.Text = (String)(Session["UserName"]);
        Label3.Text = Convert.ToString((int)Session["Admin"]);
        Label4.Text = Convert.ToString((int)Session["EmployerID"]);
    }
}