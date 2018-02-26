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
            rewardsReceived.Visible = true;
            rewardsGiven.Visible = false;
            topSales.Visible = false;
            RewardsPerMonth.Visible = false;

        }


    }


    protected void giverAndReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (giverAndReceiver.SelectedIndex == 0)
        {
            rewardsReceived.Visible = true;
            rewardsGiven.Visible = false;
            topSales.Visible = false;
            RewardsPerMonth.Visible = false;
        }

        else if (giverAndReceiver.SelectedIndex == 1)
        {
            rewardsReceived.Visible = false;
            rewardsGiven.Visible = true;
            topSales.Visible = false;
            RewardsPerMonth.Visible = false;
        }
        else if(giverAndReceiver.SelectedIndex == 2)
        {
            rewardsReceived.Visible = false;
            rewardsGiven.Visible = false;
            topSales.Visible = true;
            RewardsPerMonth.Visible = false;
        }
        else if(giverAndReceiver.SelectedIndex == 3)
        {
            rewardsReceived.Visible = false;
            rewardsGiven.Visible = false;
            topSales.Visible = false;
            RewardsPerMonth.Visible = true;
        }
        
    }
}