using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UserOptions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];

        if (!IsPostBack)
            fillGridView();
    }

    protected void btnInsertUser_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=Localhost;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = con;

        select.CommandText = "SELECT UserName FROM [dbo].[User] WHERE UserName = @UserName";

        select.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar));
        select.Parameters["@UserName"].Value = txtUsername.Text;

        String existingUserName = (String)select.ExecuteScalar();
        if (existingUserName == null)
        {
            int adminBit;
            adminBit = Convert.ToInt32(ddlAccountType.SelectedItem.Value);


            String insertString;

            insertString = "INSERT INTO [dbo].[User] VALUES(@FName, ";
            if (txtMI.Text.Equals(""))
            {
                insertString += "NULL,";
            }
            else
            {
                insertString += "@MI, ";
            }
            insertString += "@LName, @Email, @UserName, NULL, " + adminBit + ", "+ (int)Session["UserID"] +", @EmployerID, '" + (String)Session["LName"] + "', '2018-01-01')";

            select.CommandText = insertString;

            select.Parameters.Add(new SqlParameter("@FName", SqlDbType.VarChar));
            select.Parameters["@FName"].Value = txtFName.Text;

            if (!txtMI.Text.Equals(""))
            {
                select.Parameters.Add(new SqlParameter("@MI", SqlDbType.Char));
                select.Parameters["@MI"].Value = txtMI.Text;
            }

            select.Parameters.Add(new SqlParameter("@LName", SqlDbType.VarChar));
            select.Parameters["@LName"].Value = txtLName.Text;

            select.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
            select.Parameters["@Email"].Value = txtEmail.Text;



            select.Parameters.Add(new SqlParameter("@EmployerID", SqlDbType.Int));
            select.Parameters["@EmployerID"].Value = txtCompany.Text;

            select.ExecuteNonQuery();

            //Create Password
            string password = "password";

            string passwordHashNew =
                       SimpleHash.ComputeHash(password, "MD5", null);
            select.CommandText = "SELECT [UserID] FROM [USER] WHERE [UserName] = @UserName";
            int userID = (int)select.ExecuteScalar();
            select.CommandText = "INSERT INTO[dbo].[Password] Values ("+ userID +", '" + passwordHashNew + "')";
            select.ExecuteNonQuery();
            
            
        }
        else
        {

            lblError.Text = "This username is already taken";

        }

        con.Close();
    }

    protected void fillGridView()
    {
        try
        {


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT UserID, FName, LName, MI, Email, " +
                "Username, Admin FROM [User];", sc);
            del.ExecuteNonQuery();

            grdUsers.DataSource = del.ExecuteReader();
            grdUsers.DataBind();
            sc.Close();

        }
        catch
        {

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
            sc.ConnectionString = @"Data Source=LOCALHOST;Initial Catalog=lab4;Integrated Security=True";

            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM [Password] WHERE UserID = @userID;", sc);
            del.Parameters.AddWithValue("@userID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            del.CommandText = "DELETE FROM [User] WHERE UserID=@userID";
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
        sc.ConnectionString = @"Data Source=LOCALHOST;Initial Catalog=lab4;Integrated Security=True";


        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtFName") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtLName") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtMI") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtAdmin") as TextBox).Text.ToString()))
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
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE [User] SET FName=@newFName, " +
                    "LName=@newLName, MI=@newMI, Email=@newEmail, Username=@newUsername, Admin=@newAdmin WHERE UserID=@userID", sc);
                del.Parameters.AddWithValue("@newFName", (grdUsers.Rows[e.RowIndex].FindControl("txtFName") as TextBox).Text.ToString().ToLower());
                del.Parameters.AddWithValue("@newLName", (grdUsers.Rows[e.RowIndex].FindControl("txtLName") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newMI", (grdUsers.Rows[e.RowIndex].FindControl("txtMI") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newEmail", (grdUsers.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newUsername", (grdUsers.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newAdmin", (grdUsers.Rows[e.RowIndex].FindControl("txtAdmin") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@userID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                grdUsers.EditIndex = -1;

                fillGridView();
            }
            catch
            {

            }

        }
    }

    protected void grdUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdUsers.EditIndex = -1;
        fillGridView();
    }
}