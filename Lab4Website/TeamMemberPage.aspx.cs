using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class TeamMemberPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Show the current user's name and account balance in the sidebar
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");
        }
        catch (Exception)
        {
            // Redirect the user to the login page if something goes wrong
            Response.Redirect("LoginPage.aspx");
        }

        // On initial page load
        if (!IsPostBack)
        {
            // Initialize SQL objects, set up a connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=lab4;Integrated Security=True";
            con.Open();

            // Show all transactions in the SQL database involving the current user
            SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " OR " +
                "ReceiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);

            // Create a SQL command to find how many transactions in the database involve the current user
            SqlCommand scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " OR " +
                "ReceiverID=" + (int)Session["UserID"], con);

            // Declare an int variable and set its value to the result of the above SQL command
            int arraySize = (int)scaler.ExecuteScalar();

            // Instantiate a data reader object to later read in database transactions
            SqlDataReader reader = read.ExecuteReader();

            // Instantiate an array of Post objects and set its size equal to the arraySize variable
            Post[] transaction = new Post[arraySize];

            // Declare an int variable to fill each Post in the Post array
            int arrayCounter = 0;

            while (reader.Read())
            {
                // Fill each array element with the corresponding Post data field values 
                transaction[arrayCounter] = new Post(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)),
                    Convert.ToString(reader.GetValue(2)), Convert.ToString(reader.GetValue(3)), Convert.ToDouble(reader.GetValue(4)), Convert.ToDateTime(reader.GetValue(5)), Convert.ToBoolean(reader.GetValue(6)), Convert.ToInt32(reader.GetValue(7)), Convert.ToInt32(reader.GetValue(8)));
                arrayCounter++;
            }
            con.Close();

            // Instantiate an array of Panel objects and set its size equal to arraySize
            Panel[] panelPost = new Panel[arraySize];

            // Reopen the SQL database connection
            con.Open();

            // Give each transaction post a panel to make the team member page look more professional
            for (int i = 0; i < arraySize; i++)
            {
                // Instantiate a new Panel object for each element in the array of Panels
                panelPost[i] = new Panel();

                // Instantiate an array of Labels and set its size equal to the amount of details we want to show to the user; for now, it's five labels
                Label[] labelPost = new Label[5];

                // Instantiate a new Label object for each element in the array of Labels
                labelPost[0] = new Label();

                // If any transactions involving the current user are private, do not show the involved parties' names
                if (transaction[i].getIsPrivate() == true)
                {
                    labelPost[0].Text = ("Anonymous" + " gifted " + "Anonymous $" + transaction[i].getRewardValue());
                }

                // For all public transactions, show the names of the users involved
                else
                {

                    SqlCommand select = new SqlCommand("SELECT [FName] + ' ' + [LName] FROM [dbo].[User] WHERE [UserID] = " + transaction[i].getGiverID(), con);
                    String giver = (String)select.ExecuteScalar();

                    select.CommandText = "SELECT [FName] + ' ' + [LName] FROM [dbo].[User] WHERE [UserID] = " + transaction[i].getReceiverID();
                    String reciever = (String)select.ExecuteScalar();

                    labelPost[0].Text = (giver + " gifted " + reciever + " $" + transaction[i].getRewardValue());
                }

                // Add the Label object to the current element of the array of Panels to make it visible
                panelPost[i].Controls.Add(labelPost[0]);

                // Add a line break to show the next detail
                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                // Instantiate a new Label object, make it show the value of the current element in the array of Posts, and add it to the array of Panels
                labelPost[1] = new Label();
                labelPost[1].Text = ("Value: " + transaction[i].getValue());
                panelPost[i].Controls.Add(labelPost[1]);

                // Line break
                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                // Make the label show the category the transaction falls under
                labelPost[2] = new Label();
                labelPost[2].Text = ("Category: " + transaction[i].getCategory());
                panelPost[i].Controls.Add(labelPost[2]);

                // Line break
                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                // Make the label show the description the giver entered
                labelPost[3] = new Label();
                labelPost[3].Text = ("Description: " + transaction[i].getDescription());
                panelPost[i].Controls.Add(labelPost[3]);

                // Line break
                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                // Make the label show how long ago the transaction was made
                labelPost[4] = new Label();
                TimeSpan difference = DateTime.Now - transaction[i].getPostDate();
                labelPost[4].Text = "Posted " + Convert.ToString((int)difference.TotalMinutes) + " Minutes Ago";
                panelPost[i].Controls.Add(labelPost[4]);

                // Set the border style of the panels
                panelPost[i].BorderStyle = BorderStyle.Solid;

                // Assign a CssClass to the panels
                panelPost[i].CssClass = "postCSS";

                // Add all of the elements in the array of Panels to the master panel
                Panel1.Controls.Add(panelPost[i]);

            }

            con.Close();
        }

    }


    protected void giverAndReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Code is mostly similar to the Page_Load method
        // Check if the user chooses to see all transactions in the database
        if (giverAndReceiver.SelectedIndex == 0)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=lab4;Integrated Security=True";
            con.Open();

            SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " OR " +
                "ReceiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);

            //Create Scaler to see how many transactions there are
            SqlCommand scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " OR " +
                "ReceiverID=" + (int)Session["UserID"], con);

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
            Panel[] panelPost = new Panel[arraySize];
            con.Open();

            for (int i = 0; i < arraySize; i++)
            {
                panelPost[i] = new Panel();

                Label[] labelPost = new Label[5];

                labelPost[0] = new Label();

                if (transaction[i].getIsPrivate() == true)
                {
                    labelPost[0].Text = ("Anonymous" + " gifted " + "Anonymous $" + transaction[i].getRewardValue());
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

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[1] = new Label();
                labelPost[1].Text = ("Value: " + transaction[i].getValue());
                panelPost[i].Controls.Add(labelPost[1]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[2] = new Label();
                labelPost[2].Text = ("Category: " + transaction[i].getCategory());
                panelPost[i].Controls.Add(labelPost[2]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[3] = new Label();
                labelPost[3].Text = ("Description: " + transaction[i].getDescription());
                panelPost[i].Controls.Add(labelPost[3]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[4] = new Label();
                TimeSpan difference = DateTime.Now - transaction[i].getPostDate();
                labelPost[4].Text = "Posted " + Convert.ToString((int)difference.TotalMinutes) + " Minutes Ago";
                panelPost[i].Controls.Add(labelPost[4]);

                panelPost[i].BorderStyle = BorderStyle.Solid;

                panelPost[i].CssClass = "postCSS";

                Panel1.Controls.Add(panelPost[i]);

            }

            con.Close();
        }

        // Check if user chooses to see only the transactions where they were the giver
        else if (giverAndReceiver.SelectedIndex == 1)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=lab4;Integrated Security=True";
            con.Open();

            SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);

            //Create Scaler to see how many transactions there are
            SqlCommand scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"], con);
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
            Panel[] panelPost = new Panel[arraySize];
            con.Open();

            for (int i = 0; i < arraySize; i++)
            {
                panelPost[i] = new Panel();

                Label[] labelPost = new Label[5];

                labelPost[0] = new Label();

                if (transaction[i].getIsPrivate() == true)
                {
                    labelPost[0].Text = ("Anonymous" + " gifted " + "Anonymous $" + transaction[i].getRewardValue());
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

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[1] = new Label();
                labelPost[1].Text = ("Value: " + transaction[i].getValue());
                panelPost[i].Controls.Add(labelPost[1]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[2] = new Label();
                labelPost[2].Text = ("Category: " + transaction[i].getCategory());
                panelPost[i].Controls.Add(labelPost[2]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[3] = new Label();
                labelPost[3].Text = ("Description: " + transaction[i].getDescription());
                panelPost[i].Controls.Add(labelPost[3]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[4] = new Label();
                TimeSpan difference = DateTime.Now - transaction[i].getPostDate();
                labelPost[4].Text = "Posted " + Convert.ToString((int)difference.TotalMinutes) + " Minutes Ago";
                panelPost[i].Controls.Add(labelPost[4]);

                panelPost[i].BorderStyle = BorderStyle.Solid;

                panelPost[i].CssClass = "postCSS";

                Panel1.Controls.Add(panelPost[i]);

            }

            con.Close();
        }

        // Check if the user chooses to see only the transactions where they were the receiver
        else if (giverAndReceiver.SelectedIndex == 2)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=lab4;Integrated Security=True";
            con.Open();

            SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE ReceiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);

            //Create Scaler to see how many transactions there are
            SqlCommand scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE ReceiverID=" + (int)Session["UserID"], con);
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
            Panel[] panelPost = new Panel[arraySize];
            con.Open();

            for (int i = 0; i < arraySize; i++)
            {
                panelPost[i] = new Panel();
                Label[] labelPost = new Label[5];
                labelPost[0] = new Label();

                if (transaction[i].getIsPrivate() == true)
                {
                    labelPost[0].Text = ("Anonymous" + " gifted " + "Anonymous $" + transaction[i].getRewardValue());
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

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[1] = new Label();
                labelPost[1].Text = ("Value: " + transaction[i].getValue());
                panelPost[i].Controls.Add(labelPost[1]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[2] = new Label();
                labelPost[2].Text = ("Category: " + transaction[i].getCategory());
                panelPost[i].Controls.Add(labelPost[2]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[3] = new Label();
                labelPost[3].Text = ("Description: " + transaction[i].getDescription());
                panelPost[i].Controls.Add(labelPost[3]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[4] = new Label();
                TimeSpan difference = DateTime.Now - transaction[i].getPostDate();
                labelPost[4].Text = "Posted " + Convert.ToString((int)difference.TotalMinutes) + " Minutes Ago";
                panelPost[i].Controls.Add(labelPost[4]);

                panelPost[i].BorderStyle = BorderStyle.Solid;

                panelPost[i].CssClass = "postCSS";

                Panel1.Controls.Add(panelPost[i]);

            }

            con.Close();
        }
    }
}
