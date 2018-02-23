using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
<<<<<<< HEAD
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
=======
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
>>>>>>> aefeafdec146ea02fab448fb4369b93f1aa3ab6a
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
            if (String.IsNullOrWhiteSpace(txtMI.Text) == true)
            {
                insertString += "NULL,";
            }
            else
            {
                insertString += "@MI, ";
            }

            insertString += "@LName, @Email, @UserName, NULL, " + adminBit + ", "+ (int)Session["UserID"] +", @EmployerID, @AccountBalance, 1, '" + (String)Session["LName"] + "', '2018-01-01')";

            select.CommandText = insertString;

            select.Parameters.Add(new SqlParameter("@FName", SqlDbType.VarChar));
            select.Parameters["@FName"].Value = char.ToUpper(txtFName.Text[0]) + txtFName.Text.Substring(1);

            if (String.IsNullOrWhiteSpace(txtMI.Text) == false)
            {
                select.Parameters.Add(new SqlParameter("@MI", SqlDbType.Char));
                select.Parameters["@MI"].Value = char.ToUpper(txtMI.Text[0]);
            }

            select.Parameters.Add(new SqlParameter("@LName", SqlDbType.VarChar));
            select.Parameters["@LName"].Value = char.ToUpper(txtLName.Text[0]) + txtLName.Text.Substring(1);

            select.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
            select.Parameters["@Email"].Value = txtEmail.Text;

            select.Parameters.Add(new SqlParameter("@EmployerID", SqlDbType.Int));
            select.Parameters["@EmployerID"].Value = CompanyDropdown.SelectedIndex + 1;

            select.Parameters.Add(new SqlParameter("@AccountBalance", SqlDbType.Money));
            select.Parameters["@AccountBalance"].Value = 0;

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
        fillGridView();
    }

    protected void fillGridView()
    {
        try
        {


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
<<<<<<< HEAD
            sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
=======
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
>>>>>>> aefeafdec146ea02fab448fb4369b93f1aa3ab6a

            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT UserID, FName, LName, MI, Email, " +
                "Username, Admin, EmployedStatus FROM [User];", sc);
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
<<<<<<< HEAD
            sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
=======
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
>>>>>>> aefeafdec146ea02fab448fb4369b93f1aa3ab6a

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
<<<<<<< HEAD
        sc.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
=======
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
>>>>>>> aefeafdec146ea02fab448fb4369b93f1aa3ab6a

        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvFName") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvLName") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvEmail") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvUsername") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }


        

        if (textError)
        {
            var ddl = grdUsers.Rows[e.RowIndex].FindControl("ddlgvAdmin") as DropDownList;
            var ddlEmployed = grdUsers.Rows[e.RowIndex].FindControl("drpStatus") as DropDownList;
         
            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE [User] SET FName=@newFName, " +
                    "LName=@newLName, MI=@newMI, Email=@newEmail, Username=@newUsername, Admin=@newAdmin, EmployedStatus=@employedStatus WHERE UserID=@userID", sc);
                del.Parameters.AddWithValue("@newFName", (char.ToUpper((grdUsers.Rows[e.RowIndex].FindControl("txtFName") as TextBox).Text[0])
                    + (grdUsers.Rows[e.RowIndex].FindControl("txtFName") as TextBox).Text.Substring(1)));
                del.Parameters.AddWithValue("@newLName", (char.ToUpper((grdUsers.Rows[e.RowIndex].FindControl("txtLName") as TextBox).Text[0])
                    + (grdUsers.Rows[e.RowIndex].FindControl("txtLName") as TextBox).Text.Substring(1)));
                del.Parameters.AddWithValue("@newMI", (char.ToUpper((grdUsers.Rows[e.RowIndex].FindControl("txtMI") as TextBox).Text[0])));
                del.Parameters.AddWithValue("@newEmail", (grdUsers.Rows[e.RowIndex].FindControl("txtgvEmail") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newUsername", (grdUsers.Rows[e.RowIndex].FindControl("txtgvUsername") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newAdmin", ddl.SelectedValue);
                del.Parameters.AddWithValue("@employedStatus", ddlEmployed.SelectedValue);
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

    protected void btnAutoFillUser_Click(object sender, EventArgs e)
    {
        txtFName.Text = "Carey";
        txtMI.Text = "";
        txtLName.Text = "Cole";
        txtEmail.Text = "Carey_Cole@jmu.edu";
        txtUsername.Text = "CCole";
    }
}