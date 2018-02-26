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

public partial class BuyRewards : System.Web.UI.Page
{
    public static Panel[] panelPost;
    public static CheckBox[] chkBuy;
    public static Reward[] reward;
    public static int arraySize;
    protected void Page_Load(object sender, EventArgs e)
    {
        createRewardFeed();
        loadProfilePicture();

        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");
        }
        catch (Exception)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }


    // Only for testing btnBuy functionality
    void GreetingBtn_Click(Object sender,
                           EventArgs e)
    {
        // When the button is clicked,
        // change the button text, and disable it.

        Button clickedButton = (Button)sender;
        clickedButton.Text = "...button clicked...";
        clickedButton.Enabled = false;

        //testing update to the database
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand("UPDATE [Reward] SET RewardQuantity = RewardQuantity - 1 WHERE RewardID = @rewardID", con);
        cmd.Parameters.AddWithValue("@rewardID", 3);

        cmd.ExecuteNonQuery();

        con.Close();


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

    public Boolean checkFunds()
    {
        Boolean valid = true;

        SqlConnection con = new SqlConnection();


        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "SELECT AccountBalance FROM [User] WHERE UserID = @userID";
        cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);
        double balance = Convert.ToDouble(cmd.ExecuteScalar());

        for (int i = 0; i < reward.Length; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                if (balance < reward[i].getRewardAmount())
                {
                    lblResult.Text = "Insufficient funds.";
                    valid = false;
                }
            }

        }

        con.Close();

        return valid;
    }


    protected void btnBuy_Click(object sender, EventArgs e)
    {

        if (checkFunds() == false)
            return;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);
        bool itemSelected = false;

        for (int i = 0; i < arraySize; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                itemSelected = true;
                cmd.CommandText = "INSERT INTO RewardEarned (UserID, RewardID, DateClaimed) VALUES (@userID, @rewardID, @dateClaimed)";
                cmd.Parameters.AddWithValue("@rewardID", reward[i].getRewardID());
                cmd.Parameters.AddWithValue("@dateClaimed", DateTime.Today.Date);
                cmd.ExecuteNonQuery();
            }
        }



        for (int i = 0; i < arraySize; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                cmd.CommandText = "UPDATE [Reward] SET RewardQuantity = RewardQuantity - 1 WHERE RewardID = @reward";
                cmd.Parameters.AddWithValue("@reward", reward[i].getRewardID());
                cmd.ExecuteNonQuery();
            }
        }

        for (int i = 0; i < arraySize; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                cmd.CommandText = "UPDATE [User] SET AccountBalance = AccountBalance - @rewardAmount WHERE UserID = @userID";
                cmd.Parameters.AddWithValue("@rewardAmount", reward[i].getRewardAmount());
                //cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);
                cmd.ExecuteNonQuery();

                Session["AccountBalance"] = (decimal)Session["AccountBalance"] - Convert.ToDecimal(reward[i].getRewardAmount());
            }
        }

        if (itemSelected == true)
        {
            lblResult.Text = "Reward claimed!";
            createRewardFeed();
        }
        else
        {
            lblResult.Text = "Please select an item";
        }


        con.Close();


    }

    public void createRewardFeed()
    {
        Panel1.Controls.Clear();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[Reward] WHERE [RewardQuantity] > 0 ORDER BY [RewardID] DESC", con);

        //Create Scaler to see how many rewards there are
        SqlCommand scaler = new SqlCommand("SELECT COUNT(RewardID) FROM [dbo].[Reward] WHERE [RewardQuantity] > 0", con);
        arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        reward = new Reward[arraySize];
        int arrayCounter = 0;

        if (arraySize != 0)
        {


            while (reader.Read())
            {
                reward[arrayCounter] = new Reward(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)),
                    Convert.ToInt32(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToInt32(reader.GetValue(5)), Convert.ToDateTime(reader.GetValue(6)));
                arrayCounter++;
            }

            con.Close();
            panelPost = new Panel[arraySize];
            chkBuy = new CheckBox[arraySize];
            con.Open();

            for (int i = 0; i < arraySize; i++)
            {
                panelPost[i] = new Panel();
                Label[] labelPost = new Label[4];


                labelPost[0] = new Label();
                labelPost[0].Text = "Reward Name: " + reward[i].getRewardName();

                panelPost[i].Controls.Add(labelPost[0]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                labelPost[1] = new Label();
                labelPost[1].Text = "Reward Quantity: " + reward[i].getRewardQuantity();

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                panelPost[i].Controls.Add(labelPost[1]);

                labelPost[2] = new Label();
                labelPost[2].Text = "Reward Value: $" + reward[i].getRewardAmount();

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                panelPost[i].Controls.Add(labelPost[2]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));

                chkBuy[i] = new CheckBox();
                chkBuy[i].AutoPostBack = true;
                panelPost[i].Controls.Add(chkBuy[i]);

                panelPost[i].Controls.Add(new LiteralControl("<br />"));


                panelPost[i].BorderStyle = BorderStyle.Solid;

                panelPost[i].CssClass = "postCSS";

                Panel1.Controls.Add(panelPost[i]);
            }
            con.Close();
        }
    }
}