using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

public partial class AnalyticsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");
        }
        catch (Exception)
        {
            Response.Redirect("LoginPage.aspx");
        }

        if (!IsPostBack)
        {
            Chart2.Visible = false;
            Chart1.Visible = true;

        }
        

    }


    protected void giverAndReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (giverAndReceiver.SelectedIndex == 0)
        {
            Chart2.Visible = false;
            Chart1.Visible = true;
        }

        else if (giverAndReceiver.SelectedIndex == 1)
        {
            Chart1.Visible = false;
            Chart2.Visible = true;
        }
    }
}
