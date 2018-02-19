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

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Post post = new Post();
        post.setValue(txtCompanyValue.Text);
        post.setCategory(txtCategory.Text);
        post.setDescription(txtDescription.Text);
        post.setRewardValue(Convert.ToDouble(ddlRewardValue.SelectedValue));
        post.setPostDate(Convert.ToDateTime(DateTime.Now));

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost;Database=Lab4;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand("RewardInsert", sc);
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyValue", post.getValue()));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Category", post.getCategory()));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", post.getDescription()));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RewardValue", post.getRewardValue()));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransactionDate", post.getPostDate()));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Private", 1));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GiverID", (int)Session["UserID"]));
            cmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReceiverID", 2));
            cmdInsert.ExecuteNonQuery();
        }

        catch
        {
            Response.Write("Did not work");
        }
    }
}
