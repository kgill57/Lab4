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

    }

    protected void btnInsertUser_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
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
            insertString += "@LName, @Email, @UserName, NULL, " + adminBit + ", 1, @EmployerID, 'Bennsky', '2018-01-01')";

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

            
        }
        else
        {

            lblError.Text = "This username is already taken";

        }

        con.Close();
    }
}