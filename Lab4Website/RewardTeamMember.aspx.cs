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

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =KYLEPC\SQLEXPRESS01;Database=Lab4;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
            cmdInsert.Connection = sc;
            cmdInsert.CommandText = "INSERT INTO [dbo].[Transaction] (CompanyValue, Category, Description, RewardValue, TransactionDate,"
                + " Private, GiverID, ReceiverID) VALUES (@CompanyValue, @Category, @Description, @RewardValue, @TransactionDate, @Private," +
                " @GiverID, @ReceiverID)";
            cmdInsert.Parameters.AddWithValue("@CompanyValue", post.getValue());
            cmdInsert.Parameters.AddWithValue("@Category", post.getCategory());
            cmdInsert.Parameters.AddWithValue("@Description", post.getDescription());
            cmdInsert.Parameters.AddWithValue("@RewardValue", post.getRewardValue());
            cmdInsert.Parameters.AddWithValue("@TransactionDate", post.getPostDate());
            cmdInsert.Parameters.AddWithValue("@Private", 1);
            cmdInsert.Parameters.AddWithValue("@GiverID", (int)Session["UserID"]);
            cmdInsert.Parameters.AddWithValue("@ReceiverID", 2);

            cmdInsert.ExecuteNonQuery();
        }

        catch
        {

        }
    }
}
