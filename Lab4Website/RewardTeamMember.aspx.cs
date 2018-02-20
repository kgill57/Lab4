using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class RewardTeamMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + Session["AccountBalance"];
            if (!IsPostBack)
            {
                ddlCompanyValue.ClearSelection();
                ddlCategory.ClearSelection();
                ddlRewardValue.ClearSelection();
                loadDropDown();
            }
        }
        catch (Exception)
        {
            Response.Redirect("LoginPage.aspx");
        }

    }

    public void loadDropDown()
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        cmdInsert.CommandText = "SELECT Username FROM [User] WHERE [Admin] != 1 AND UserID != " + Convert.ToString((int)Session["UserID"]);

        SqlDataAdapter da = new SqlDataAdapter(cmdInsert);
        DataTable dt = new DataTable();

        da.Fill(dt);

        drpUsernames.DataSource = dt;
        drpUsernames.DataTextField = "Username";
        drpUsernames.DataBind();
        sc.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Post post = new Post();
        post.setValue(ddlCompanyValue.SelectedValue);
        post.setCategory(ddlCategory.SelectedValue);
        post.setDescription(txtDescription.Text);
        post.setRewardValue(Convert.ToDouble(ddlRewardValue.SelectedValue));
        post.setPostDate(DateTime.Now);
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

            if (checkTransactionDate(post.getGiverID()) == true)
            {

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
                cmdInsert.Parameters.AddWithValue("@ReceiverID", getRecieverID(drpUsernames.SelectedItem.Text));

                cmdInsert.ExecuteNonQuery();

                cmdInsert.CommandText = "UPDATE [Employer] SET TotalBalance = TotalBalance - @RewardValue WHERE EmployerID=1";
                cmdInsert.ExecuteNonQuery();
                cmdInsert.CommandText = "UPDATE [User] SET AccountBalance = AccountBalance + @RewardValue WHERE UserID=@ReceiverID";
                cmdInsert.ExecuteNonQuery();

                lblResult.Text = "Reward Sent.";


                sc.Close();
                loadDropDown();
            }
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
        DateTime today = DateTime.Today.Date;
        if (transDate.Date == today)
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
