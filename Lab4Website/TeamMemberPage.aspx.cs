using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeamMemberPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];


        Label2.Text = Convert.ToString((int)Session["UserID"]);
        Label5.Text = (String)(Session["UserName"]);
        Label6.Text = Convert.ToString((int)Session["Admin"]);
        Label7.Text = Convert.ToString((int)Session["EmployerID"]);
    }
}