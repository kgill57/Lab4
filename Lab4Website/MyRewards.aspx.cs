using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MyRewards : System.Web.UI.Page
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
            fillRewards();

        loadProfilePicture();
        
    }

    public void fillRewards()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand scaler = new SqlCommand("SELECT Count(RewardEarned.DateClaimed) FROM RewardEarned WHERE RewardEarned.UserID = 2", con);
        int size = (int)scaler.ExecuteScalar();

        SqlCommand read = new SqlCommand("SELECT Reward.RewardName, Reward.RewardAmount, RewardEarned.DateClaimed FROM Reward, RewardEarned WHERE RewardEarned.UserID = @UserID", con);
        read.Parameters.AddWithValue("@UserID", (int)Session["UserID"]);
        SqlDataReader reader = read.ExecuteReader();
        Panel[] panel = new Panel[size];
        int counter = 0;
        
        while (reader.Read())
        {
            panel[counter] = new Panel();

            Label[] lblArray = new Label[3];

            lblArray[0] = new Label();

            lblArray[0].Text = "Reward: " + (String)reader.GetValue(0);
            panel[counter].Controls.Add(lblArray[0]);

            panel[counter].Controls.Add(new LiteralControl("<br />"));

            lblArray[1] = new Label();

            lblArray[1].Text = "Value: $" + ((Decimal)reader.GetValue(1)).ToString("0.##");

            panel[counter].Controls.Add(lblArray[1]);

            panel[counter].Controls.Add(new LiteralControl("<br />"));

            lblArray[2] = new Label();

            DateTime date = (DateTime)reader.GetValue(2);

            lblArray[2].Text = "Purchase Date: " + Convert.ToString(date.Month) + "/" + Convert.ToString(date.Day) + "/" + Convert.ToString(date.Year);

            panel[counter].Controls.Add(lblArray[2]);

            Panel1.Controls.Add(panel[counter]);

            panel[counter].BorderStyle = BorderStyle.Solid;

            panel[counter].CssClass = "postCSS";

            counter++;


        }





        //for (int i = 0; i < arraySize; i++)
        //{
        //    panelPost[i] = new Panel();

        //    Label[] labelPost = new Label[5];

        //    labelPost[0] = new Label();

        //    if (transaction[i].getIsPrivate() == true)
        //    {
        //        labelPost[0].Text = ("Anonymous" + " gifted " + "Anonymous $" + transaction[i].getRewardValue());
        //    }
        //    else
        //    {

        //        SqlCommand select = new SqlCommand("SELECT [FName] + ' ' + [LName] FROM [dbo].[User] WHERE [UserID] = " + transaction[i].getGiverID(), con);
        //        String giver = (String)select.ExecuteScalar();

        //        select.CommandText = "SELECT [FName] + ' ' + [LName] FROM [dbo].[User] WHERE [UserID] = " + transaction[i].getReceiverID();
        //        String reciever = (String)select.ExecuteScalar();

        //        labelPost[0].Text = (giver + " gifted " + reciever + " $" + transaction[i].getRewardValue());
        //    }
        //    panelPost[i].Controls.Add(labelPost[0]);

        //    panelPost[i].Controls.Add(new LiteralControl("<br />"));

        //    labelPost[1] = new Label();
        //    labelPost[1].Text = ("Value: " + transaction[i].getValue());
        //    panelPost[i].Controls.Add(labelPost[1]);

        //    panelPost[i].Controls.Add(new LiteralControl("<br />"));

        //    labelPost[2] = new Label();
        //    labelPost[2].Text = ("Category: " + transaction[i].getCategory());
        //    panelPost[i].Controls.Add(labelPost[2]);

        //    panelPost[i].Controls.Add(new LiteralControl("<br />"));

        //    labelPost[3] = new Label();
        //    labelPost[3].Text = ("Description: " + transaction[i].getDescription());
        //    panelPost[i].Controls.Add(labelPost[3]);

        //    panelPost[i].Controls.Add(new LiteralControl("<br />"));

        //    labelPost[4] = new Label();

        //    TimeSpan difference = DateTime.Now - transaction[i].getPostDate();
        //    labelPost[4].Text = "Posted " + Convert.ToString((int)difference.TotalMinutes) + " Minutes Ago";

        //    panelPost[i].Controls.Add(labelPost[4]);

        //    panelPost[i].BorderStyle = BorderStyle.Solid;

        //    panelPost[i].CssClass = "postCSS";


        //    Panel1.Controls.Add(panelPost[i]);
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
}