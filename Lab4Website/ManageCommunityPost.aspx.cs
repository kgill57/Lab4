using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class ManageCommunityPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];

        if (!IsPostBack)
            fillGridView();
    }

    protected void btnInsertUser_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "INSERT INTO [dbo].[EventPost] VALUES(@EventTitle, " +  
                " @EventDesc, '" + DateTime.Today.ToString() + "', " + (int)Session["UserID"] + ")";

            select.Parameters.Add(new SqlParameter("@EventTitle", SqlDbType.VarChar));
            select.Parameters["@EventTitle"].Value = txtFName.Text;

            select.Parameters.Add(new SqlParameter("@EventDesc", SqlDbType.VarChar));
            select.Parameters["@EventDesc"].Value = txtLName.Text;



            select.ExecuteNonQuery();

            con.Close();
        }
        catch(Exception a)
        {
            Console.WriteLine();
        }
        fillGridView();
    }

    protected void fillGridView()
    {
        try
        {


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT " +
                "* FROM [EventPost];", sc);
            del.ExecuteNonQuery();

            grdUsers.DataSource = del.ExecuteReader();
            grdUsers.DataBind();
            sc.Close();

        }
        catch (Exception a)
        {
            Console.WriteLine();
        }
    }

    protected void grdUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdUsers.EditIndex = e.NewEditIndex;
        fillGridView();
    }

    protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int num = Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString());
        Console.WriteLine();
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM [EventPost] WHERE EventPostID = @EventPostID;", sc);
            del.Parameters.AddWithValue("@EventPostID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            sc.Close();
            fillGridView();
        }
        catch
        {

        }
    }

    protected void grdUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        ////Check if the project name Text box is empty
        //if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvFName") as TextBox).Text.ToString()))
        //{
        //    //projectNameError.Visible = true;
        //    //projectNameError.Text = "The project name cannot be empty";
        //    textError = false;
        //}

        ////Check if the Project Description Text box is empty
        //if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvLName") as TextBox).Text.ToString()))
        //{
        //    //projectDescriptionErrror.Visible = true;
        //    //projectDescriptionErrror.Text = "Field cannot be empty";
        //    textError = false;
        //}

        //if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvEmail") as TextBox).Text.ToString()))
        //{
        //    //projectDescriptionErrror.Visible = true;
        //    //projectDescriptionErrror.Text = "Field cannot be empty";
        //    textError = false;
        //}

        //if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvUsername") as TextBox).Text.ToString()))
        //{
        //    //projectDescriptionErrror.Visible = true;
        //    //projectDescriptionErrror.Text = "Field cannot be empty";
        //    textError = false;
        //}


        if (textError)
        {
         
            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE [EventPost] SET EventTitle=@EventTitle, " +
                    "EventDesc=@EventDesc WHERE EventPostID=@EventPostID", sc);
                del.Parameters.AddWithValue("@EventTitle", (grdUsers.Rows[e.RowIndex].FindControl("EventTitleEdit") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@EventDesc", (grdUsers.Rows[e.RowIndex].FindControl("EventDescEdit") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@EventPostID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                grdUsers.EditIndex = -1;
                fillGridView();
            }
            catch (Exception a)
            {
                Console.WriteLine();
            }

        }
    }

    protected void grdUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdUsers.EditIndex = -1;
        fillGridView();
    }

    protected void btnAutoFillUser_Click(object sender, EventArgs e)
    {
        txtFName.Text = "Carey";
        txtLName.Text = "Cole";

    }
}