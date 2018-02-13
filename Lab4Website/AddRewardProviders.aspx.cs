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

    protected void Page_Load(object sender, EventArgs e)
    {
        fillGridView();
    }

    protected void fillGridView()
    {
        try
        {

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

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

        TextBox provName = (TextBox)grdProviders.Rows[e.NewEditIndex].Cells[1].FindControl("txtProviderName");
        oldProvName = provName.Text;

        System.Diagnostics.Debug.WriteLine(oldProvName);
        System.Diagnostics.Debug.WriteLine("");

        TextBox provEmail = (TextBox)grdProviders.Rows[e.NewEditIndex].Cells[2].FindControl("txtProviderEmail");
        oldProvEmail = provEmail.Text;
    }

    protected void grdProviders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void grdProviders_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

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



        //TextBox upProvName = (TextBox)grdProviders.Rows[e.RowIndex].Cells[1].FindControl("txtProviderName");
        //newProvName = upProvName.Text;

        //System.Diagnostics.Debug.WriteLine(newProvName);
        //Console.WriteLine();

        //TextBox upProvEmail = (TextBox)grdProviders.Rows[e.RowIndex].Cells[2].FindControl("txtProviderEmail");
        //newProvEmail = upProvEmail.Text;

        ////Creates a new sql connection and links the application to the lab 3 database
        //System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        //sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        ////Opens the sql connection
        //sc.Open();
        ////Creates a new sql insert command to insert 
        //System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();

        //insert.Connection = sc;

        //RewardProvider updateProvider = new RewardProvider();
        //updateProvider.setName(newProvName);
        //updateProvider.setEmail(newProvEmail);

        //insert.Parameters.AddWithValue("@oldProvName", oldProvName);
        //insert.Parameters.AddWithValue("@oldProvEmail", oldProvEmail);
        //insert.Parameters.AddWithValue("@newProvName", updateProvider.getName());
        //insert.Parameters.AddWithValue("@newProvEmail", updateProvider.getEmail());

        //insert.CommandText = "UPDATE RewardProvider SET ProviderName = @newProvName, ProviderEmail = @newProvEmail WHERE ProviderName LIKE @oldProvName";

        //System.Diagnostics.Debug.WriteLine(insert.CommandText);
        //System.Diagnostics.Debug.WriteLine(oldProvName);
        //System.Diagnostics.Debug.WriteLine(oldProvEmail);
        //System.Diagnostics.Debug.WriteLine(updateProvider.getName());
        //System.Diagnostics.Debug.WriteLine(updateProvider.getEmail());
        //Console.WriteLine();
        //insert.ExecuteNonQuery();

        //lblResult.Text = "Project Updated.";
    }
}