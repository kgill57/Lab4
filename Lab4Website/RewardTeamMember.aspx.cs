using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RewardTeamMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + Session["AccountBalance"];
        if (!IsPostBack)
        {
            ddlCompanyValue.ClearSelection();
            ddlCategory.ClearSelection();
            ddlRewardValue.ClearSelection();
        }     
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Post post = new Post();
        post.setValue(ddlCompanyValue.SelectedValue);
        post.setCategory(ddlCategory.SelectedValue);
        post.setDescription(txtDescription.Text);
        post.setRewardValue(Convert.ToDouble(ddlRewardValue.SelectedValue));
        post.setPostDate(Convert.ToString(DateTime.Now));
        post.setGiverID((int)Session["UserID"]);

        if (Convert.ToByte(chkPrivate.Checked) == 0)
        {
            post.setIsPrivate(false);
        }

        else if (Convert.ToByte(chkPrivate.Checked) == 1)
        {
            post.setIsPrivate(true);
        }

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
            cmdInsert.Connection = sc;

            if (checkTransactionDate(post.getGiverID()) == false)
                return;

            cmdInsert.CommandText = "INSERT INTO [dbo].[Transaction] (CompanyValue, Category, Description, RewardValue, TransactionDate,"
                + " Private, GiverID, ReceiverID) VALUES (@CompanyValue, @Category, @Description, @RewardValue, @TransactionDate, @Private," +
                " @GiverID, @ReceiverID)";
            cmdInsert.Parameters.AddWithValue("@CompanyValue", post.getValue());
            cmdInsert.Parameters.AddWithValue("@Category", post.getCategory());
            cmdInsert.Parameters.AddWithValue("@Description", post.getDescription());
            cmdInsert.Parameters.AddWithValue("@RewardValue", post.getRewardValue());
            cmdInsert.Parameters.AddWithValue("@TransactionDate", post.getPostDate());
            cmdInsert.Parameters.AddWithValue("@Private", post.getIsPrivate());
            cmdInsert.Parameters.AddWithValue("@GiverID", (int)Session["UserID"]);
            cmdInsert.Parameters.AddWithValue("@ReceiverID", getRecieverID(txtReceiver.Text));

            cmdInsert.ExecuteNonQuery();

            cmdInsert.CommandText = "UPDATE [User] SET AccountBalance = AccountBalance - @RewardValue WHERE UserID=@GiverID";
            cmdInsert.ExecuteNonQuery();
            cmdInsert.CommandText = "UPDATE [User] SET AccountBalance = AccountBalance + @RewardValue WHERE UserID=@ReceiverID";
            cmdInsert.ExecuteNonQuery();

            lblResult.Text = "Reward Sent.";

            
            sc.Close();
        }

        catch
        {

        }
    }

    public Boolean checkTransactionDate(int giverID)
    {

        Boolean valid = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        cmdInsert.CommandText = "SELECT TransactionDate FROM [Transaction] WHERE TransID = (SELECT MAX(TransID) FROM [Transaction] WHERE GiverID=@giverID)";
        cmdInsert.Parameters.AddWithValue("@giverID", giverID);
        DateTime transDate = Convert.ToDateTime(cmdInsert.ExecuteScalar());

        System.Diagnostics.Debug.WriteLine(transDate);

        if (transDate == DateTime.Today)
        {
            lblResult.Text = "Cannot make 2 transactions in one day.";
            valid = false;
        }
            

        sc.Close();

        return valid;
    }

    public int getRecieverID(String username)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;
        cmdInsert.CommandText = "SELECT UserID FROM [User] WHERE Username = @username";

        cmdInsert.Parameters.AddWithValue("@username", username);

        int userID = (int)cmdInsert.ExecuteScalar();

        sc.Close();
        return userID;
    }
}
