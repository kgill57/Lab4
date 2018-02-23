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
        if (!IsPostBack)
            fillGridView();
    }

    protected void fillGridView()
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        sc.Open();

        SqlCommand cmd = new SqlCommand("SELECT DISTINCT Reward.RewardName, Reward.RewardAmount, RewardEarned.DateClaimed FROM Reward, RewardEarned " +
            "WHERE Reward.RewardID IN (SELECT RewardID FROM RewardEarned WHERE UserID = @userID)", sc);
        cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);

        cmd.ExecuteNonQuery();

        grdMyRewards.DataSource = cmd.ExecuteReader();
        grdMyRewards.DataBind();
        sc.Close();
    }
}