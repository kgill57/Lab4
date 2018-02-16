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
        lblSession.Text = Convert.ToString((int)Session["UserID"]);
        lbl1.Text = Convert.ToString(Session["FName"]);
    }
}