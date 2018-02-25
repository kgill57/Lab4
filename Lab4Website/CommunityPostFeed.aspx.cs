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

public partial class CommunityPostFeed : System.Web.UI.Page
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
            loadFeed();
            loadProfilePicture();
        }

    }

    protected void loadProfilePicture()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        try
        {

            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "SELECT ProfilePicture FROM [dbo].[User] WHERE UserID =" + Convert.ToString((int)Session["UserID"]);
            string currentPicture = (String)select.ExecuteScalar();

            profilePicture.ImageUrl = "~/Images/" + currentPicture;
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");

        }
        catch (Exception)
        {

        }
        con.Close();
    }

    protected void loadFeed()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[EventPost] ORDER BY [EventPostID] DESC", con);

        // Create Scaler to see how many transactions there are
        SqlCommand scaler = new SqlCommand("SELECT COUNT(EventPostID) FROM [dbo].[EventPost]", con);

        int arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        EventPost[] transaction = new EventPost[arraySize];
        int arrayCounter = 0;
        while (reader.Read())
        {
            transaction[arrayCounter] = new EventPost(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)),
                Convert.ToString(reader.GetValue(2)), Convert.ToDateTime(reader.GetValue(3)), Convert.ToString(reader.GetValue(4)));
            arrayCounter++;
        }
        con.Close();
        Panel[] panelPost = new Panel[arraySize];
        con.Open();
        DateTime dt;
        String adminName;

        for (int i = 0; i < arraySize; i++)
        {
            panelPost[i] = new Panel();

            Label[] labelPost = new Label[3];

            labelPost[0] = new Label();
            labelPost[0].Text = ("Event Title: " + transaction[i].getEventTitle());
            panelPost[i].Controls.Add(labelPost[0]);
            panelPost[i].Controls.Add(new LiteralControl("<br />"));


            labelPost[1] = new Label();
            labelPost[1].Text = ("Event Description: " + transaction[i].getEventDesc());
            panelPost[i].Controls.Add(labelPost[1]);
            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            labelPost[2] = new Label();
            dt = transaction[i].getDatePosted();
            // Create Scaler to see how many transactions there are
            SqlCommand UserName = new SqlCommand("SELECT [dbo].[User].[FName] + ' ' + [dbo].[User].[LName]  FROM [dbo].[EventPost], [dbo].[User] WHERE [dbo].[EventPost].AdminID=[dbo].[User].[UserID]"
                + " AND [dbo].[EventPost].EventPostID=" + transaction[i].getEventPostID(), con);

            adminName = (String)UserName.ExecuteScalar();
            labelPost[2].Text = ("Posted By " + adminName + " on " + String.Format("{0:dddd, MMMM d, yyyy}", dt));
            panelPost[i].Controls.Add(labelPost[2]);
            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            panelPost[i].BorderStyle = BorderStyle.Solid;

            panelPost[i].CssClass = "postCSS";


            Panel1.Controls.Add(panelPost[i]);

        }

        con.Close();
    }
}