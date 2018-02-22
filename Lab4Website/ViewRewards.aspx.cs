using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ViewRewards : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillGridView();
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];
    }

    protected void fillGridView()
    {
        try
        {

            SqlConnection sc = new SqlConnection(@"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;");
            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM Reward;", sc);
            del.ExecuteNonQuery();

            grdRewards.DataSource = del.ExecuteReader();
            grdRewards.DataBind();
            sc.Close();

        }
        catch
        {

        }
    }

    protected void fillDropDown()
    {
        SqlConnection sc = new SqlConnection(@"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;");
        sc.Open();
        // Declare the query string.

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand("SELECT ProviderName FROM RewardProvider;", sc);
        SqlDataAdapter da = new SqlDataAdapter(select);
        DataTable dt = new DataTable();

        da.Fill(dt);

        drpRewardProvider.DataSource = dt;
        drpRewardProvider.DataTextField = "ProviderName";
        drpRewardProvider.DataBind();
        sc.Close();
    }



    protected void grdRewards_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdRewards.EditIndex = -1;
        fillGridView();
    }

    protected void grdRewards_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM Reward WHERE RewardID = @rewardID;", sc);
            del.Parameters.AddWithValue("@rewardID", Convert.ToInt32(grdRewards.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            sc.Close();
            fillGridView();
        }
        catch
        {

        }
    }

    protected void grdRewards_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((grdRewards.Rows[e.RowIndex].FindControl("txtRewardName") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((grdRewards.Rows[e.RowIndex].FindControl("txtRewardQuantity") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        Reward newReward = new Reward();
        newReward.setRewardName((grdRewards.Rows[e.RowIndex].FindControl("txtRewardName") as TextBox).Text.ToString().ToLower());
        newReward.setRewardQuantity(Convert.ToInt32((grdRewards.Rows[e.RowIndex].FindControl("txtRewardQuantity") as TextBox).ToString()));
        newReward.setRewardID(Convert.ToInt32(grdRewards.DataKeys[e.RowIndex].Value.ToString()));

        if (textError)
        {
            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE Reward SET RewardName=@RewardName, " +
                    "RewardQuantity=@rewardQuantity WHERE RewardID=@rewardID", sc);
                del.Parameters.AddWithValue("@rewardName", newReward.getRewardName());
                del.Parameters.AddWithValue("@rewardQuantity", newReward.getRewardQuantity());
                del.Parameters.AddWithValue("@rewardID", newReward.getRewardID());
                del.ExecuteNonQuery();
                sc.Close();
                grdRewards.EditIndex = -1;

                fillGridView();
            }
            catch
            {

            }
        }
    }

    protected void grdRewards_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdRewards.EditIndex = e.NewEditIndex;
        fillGridView();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Boolean textError = true;
        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty(txtSearch.Text))
        {
            try
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

                sc.Open();
                //Declare the query string.

                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT *" +
                    " FROM Reward;", sc);
                del.ExecuteNonQuery();

                grdRewards.DataSource = del.ExecuteReader();
                grdRewards.DataBind();
                sc.Close();
            }
            catch
            {

            }
        }
        else
        {
            try
            {

                SqlConnection sc = new SqlConnection(@"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;");
                sc.Open();
                // Declare the query string.

                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM Reward WHERE LOWER(RewardName) LIKE LOWER('%' + @rewardName + '%');", sc);
                del.Parameters.AddWithValue("@rewardName", txtSearch.Text);
                del.ExecuteNonQuery();

                grdRewards.DataSource = del.ExecuteReader();
                grdRewards.DataBind();
                sc.Close();

            }
            catch
            {

            }
        }
    }

    protected void btnAddReward_Click(object sender, EventArgs e)
    {
        rewardPanel.Visible = true;
        fillDropDown();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        sc.Open();
        //Declare the query string.

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand("INSERT INTO Reward (RewardName, RewardQuantity, RewardAmount, " +
            "ProviderID, AdminID, DateAdded) VALUES (@rewardName, @rewardQuantity, @rewardAmount, @providerID, @adminID, @dateAdded)", sc);
        insert.Parameters.AddWithValue("@rewardName", txtRewardName.Text);
        insert.Parameters.AddWithValue("@rewardQuantity", Convert.ToInt32(txtRewardQuantity.Text));
        insert.Parameters.AddWithValue("@rewardAmount", Convert.ToDouble(txtRewardAmount.Text));
        insert.Parameters.AddWithValue("@providerID", findProviderID(drpRewardProvider.SelectedItem.Text));
        insert.Parameters.AddWithValue("@adminID", (int)Session["UserID"]);
        insert.Parameters.AddWithValue("@dateAdded", DateTime.Today);

        insert.ExecuteNonQuery();

        fillGridView();
    }

    public int findProviderID(string providerName)
    {
        SqlConnection sc = new SqlConnection();
        sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
        sc.Open();
        SqlCommand select = new SqlCommand("SELECT ProviderID FROM RewardProvider WHERE ProviderName LIKE '%' + @providerName", sc);
        select.Parameters.AddWithValue("@providerName", providerName);

        int providerID = Convert.ToInt32(select.ExecuteScalar());

        return providerID;
    }

    protected void RewardAutoFillID_Click(object sender, EventArgs e)
    {
        txtRewardName.Text = "Hardworking";
        txtRewardQuantity.Text = "50";
        txtRewardAmount.Text = "50";

    }
}