using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Calls the method to load the news feed
        loadNewsFeed();
    }

    protected void loadNewsFeed()
    {
        //Populates the nav bar with the admin's first and last name
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];

        //sql connection
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] ORDER BY [TransID] DESC", con);

        //Create Scaler to see how many transactions there are
        SqlCommand scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION]", con);
        int arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        Post[] transaction = new Post[arraySize];
        int arrayCounter = 0;
        while (reader.Read())
        {
            transaction[arrayCounter] = new Post(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)),
                Convert.ToString(reader.GetValue(2)), Convert.ToString(reader.GetValue(3)), Convert.ToDouble(reader.GetValue(4)), Convert.ToDateTime(reader.GetValue(5)), Convert.ToBoolean(reader.GetValue(6)), Convert.ToInt32(reader.GetValue(7)), Convert.ToInt32(reader.GetValue(8)));
            arrayCounter++;
        }
        con.Close();
        Label[] test = new Label[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            test[i] = new Label();

            Panel1.Controls.Add(test[i]);
            Panel1.Controls.Add(new LiteralControl("<br />"));
        }

        con.Close();
        Panel[] panelPost = new Panel[arraySize];
        con.Open();

        for (int i = 0; i < arraySize; i++)
        {
            panelPost[i] = new Panel();

            Label[] labelPost = new Label[5];


            labelPost[0] = new Label();

            if (transaction[i].getIsPrivate() == true)
            {
                labelPost[0].Text = ("Anonymous" + " gifted " + "Anonymous");
            }
            else
            {

                SqlCommand select = new SqlCommand("SELECT [FName] + ' ' + [LName] FROM [dbo].[User] WHERE [UserID] = " + transaction[i].getGiverID(), con);
                String giver = (String)select.ExecuteScalar();

                select.CommandText = "SELECT [FName] + ' ' + [LName] FROM [dbo].[User] WHERE [UserID] = " + transaction[i].getReceiverID();
                String reciever = (String)select.ExecuteScalar();

                labelPost[0].Text = (giver + " gifted " + reciever + " $" + transaction[i].getRewardValue());
            }
            panelPost[i].Controls.Add(labelPost[0]);
            labelPost[0].Style.Add("padding-left", "10px");

            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            labelPost[1] = new Label();
            labelPost[1].Text = ("Value: " + transaction[i].getValue());
            panelPost[i].Controls.Add(labelPost[1]);
            labelPost[1].Style.Add("padding-left", "10px");

            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            labelPost[2] = new Label();
            labelPost[2].Text = ("Category: " + transaction[i].getCategory());
            panelPost[i].Controls.Add(labelPost[2]);
            labelPost[2].Style.Add("padding-left", "10px");

            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            labelPost[3] = new Label();
            labelPost[3].Text = ("Description: " + transaction[i].getDescription());
            panelPost[i].Controls.Add(labelPost[3]);
            labelPost[3].Style.Add("padding-left", "10px");

            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            labelPost[4] = new Label();
            TimeSpan difference = DateTime.Now - transaction[i].getPostDate();
            labelPost[4].Text = "Posted " + Convert.ToString((int)difference.TotalMinutes) + " Minutes Ago";
            panelPost[i].Controls.Add(labelPost[4]);
            labelPost[4].Style.Add("padding-left", "10px");

            panelPost[i].BorderStyle = BorderStyle.Solid;
            panelPost[i].Style.Add("padding", "10px");

            panelPost[i].CssClass = "postCSS";


            Panel1.Controls.Add(panelPost[i]);
        }

        con.Close();
    }
}