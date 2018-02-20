using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class BuyRewards : System.Web.UI.Page
{
    public static Panel[] panelPost;
    public static CheckBox[] chkBuy;
    public static Reward[] reward;
    public static int arraySize;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[Reward] ORDER BY [RewardID] DESC", con);

        //Create Scaler to see how many rewards there are
        SqlCommand scaler = new SqlCommand("SELECT COUNT(RewardID) FROM [dbo].[Reward]", con);
        arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        reward = new Reward[arraySize];
        int arrayCounter = 0;

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
            labelPost[2].Text = "Reward Amount: " + reward[i].getRewardAmount();

            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            panelPost[i].Controls.Add(labelPost[2]);

            panelPost[i].Controls.Add(new LiteralControl("<br />"));

            chkBuy[i] = new CheckBox();
            chkBuy[i].AutoPostBack = true;
            panelPost[i].Controls.Add(chkBuy[i]);

            //if (chkBuy[i].Checked == true)
            //    System.Diagnostics.Debug.WriteLine("hello");

            panelPost[i].Controls.Add(new LiteralControl("<br />"));


            panelPost[i].BorderStyle = BorderStyle.Solid;

            panelPost[i].CssClass = "postCSS";

            Panel1.Controls.Add(panelPost[i]);
        }
        con.Close();
    }

    private void BuyRewards_CheckedChanged(object sender, EventArgs e)
    {
        throw new NotImplementedException();
        btnBuy.Text = "hello";
    }

    protected void chkBuy_CheckedChanged(Object sender, EventArgs e)
    {
        btnBuy.Text = "hello";
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
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand cmd = new SqlCommand("UPDATE [Reward] SET RewardQuantity = RewardQuantity - 1 WHERE RewardID = @rewardID", con);
        cmd.Parameters.AddWithValue("@rewardID", 3);

        cmd.ExecuteNonQuery();

        con.Close();
        

    }


    protected void btnBuy_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand cmd = new SqlCommand();

        double total = 0;
        for(int i = 0; i < arraySize; i++)
        {
            if(chkBuy[i].Checked == true)
            {
                cmd.CommandText = "INSERT INTO RewardEarned (UserID, RewardID, DateClaimed) VALUES (@userID, @rewardID, @dateClaimed)";
                
            }
        }

        
    }
}