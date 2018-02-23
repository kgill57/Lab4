using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AddRewardProviders : System.Web.UI.Page
{
    public static string oldProvName;
    public static string oldProvEmail;
    public static string newProvName;
    public static string newProvEmail;
    int count = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            fillGridView();
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];
    }

    protected void fillGridView()
    {
        try
        {


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";


            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM RewardProvider;", sc);
            del.ExecuteNonQuery();

            grdProviders.DataSource = del.ExecuteReader();
            grdProviders.DataBind();
            sc.Close();

        }
        catch
        {

        }
    }

    protected void grdProviders_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdProviders.EditIndex = e.NewEditIndex;
        fillGridView();
    }

    protected void grdProviders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdProviders.EditIndex = -1;
        fillGridView();
    }

    protected void grdProviders_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";


        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((grdProviders.Rows[e.RowIndex].FindControl("txtProviderName") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((grdProviders.Rows[e.RowIndex].FindControl("txtProviderEmail") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (textError)
        {
            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE RewardProvider SET ProviderName=@newProvName, " +
                    "ProviderEmail=@newProvEmail WHERE ProviderID=@providerID", sc);
                del.Parameters.AddWithValue("@newProvName", (grdProviders.Rows[e.RowIndex].FindControl("txtProviderName") as TextBox).Text.ToString().ToLower());
                del.Parameters.AddWithValue("@projectDescription", (grdProviders.Rows[e.RowIndex].FindControl("txtProviderEmail") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@providerID", Convert.ToInt32(grdProviders.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                grdProviders.EditIndex = -1;

                fillGridView();
            }
            catch
            {

            }


        }



    }

    protected void grdProviders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM RewardProvider WHERE ProviderID = @providerID;", sc);
            del.Parameters.AddWithValue("@providerID", Convert.ToInt32(grdProviders.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            sc.Close();
            fillGridView();
        }
        catch
        {

        }
    }

    protected void btnAddProvider_Click1(object sender, EventArgs e)
    {
        lblProviderName.Visible = true;
        lblProviderEmail.Visible = true;
        txtNewProviderName.Visible = true;
        txtNewProviderEmail.Visible = true;
        btnAdd.Visible = true;
    }

    

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }


    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";


        sc.Open();
        //Declare the query string.

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand("INSERT INTO RewardProvider (ProviderName, ProviderEmail) VALUES (@providerName, @providerEmail)", sc);
        insert.Parameters.AddWithValue("@providerName", txtNewProviderName.Text);
        insert.Parameters.AddWithValue("@providerEmail", txtNewProviderEmail.Text);

        insert.ExecuteNonQuery();

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
                    " FROM RewardProvider;", sc);
                del.ExecuteNonQuery();

                grdProviders.DataSource = del.ExecuteReader();
                grdProviders.DataBind();
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

                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM RewardProvider WHERE ProviderName LIKE '%' + @ProviderName;", sc);
                del.Parameters.AddWithValue("@ProviderName", txtSearch.Text);
                del.ExecuteNonQuery();

                grdProviders.DataSource = del.ExecuteReader();
                grdProviders.DataBind();
                sc.Close();

            }
            catch
            {

            }
        }
    }

    protected void btnClear_Click1(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }



    protected void AutoFillRewardProviderID_Click(object sender, EventArgs e)
    {
        txtNewProviderName.Text = "Provider" + count;
        txtNewProviderEmail.Text = "provider" + count + "@gmail.com";
    }
}