using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=DESKTOP-CCFVS7L\SQLEXPRESS;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = con;

        select.CommandText = "INSERT INTO [dbo].[User] VALUES('Chris', 'J', 'Bennsky', 'Bennskych@gmail.com', 'admin', NULL, 1, NULL, 'Bennsky', '2018-01-01')";
        select.ExecuteNonQuery();

        string password = "password";

        string passwordHashNew =
                   SimpleHash.ComputeHash(password, "MD5", null);

        select.CommandText = "INSERT INTO[dbo].[Password] Values (1, '" + passwordHashNew + "')";
        select.ExecuteNonQuery();
        con.Close();
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String username = txtUsername.Text;
        String password = txtPassword.Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=DESKTOP-CCFVS7L\SQLEXPRESS;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = con;

        select.CommandText = "SELECT [PasswordHash] FROM [dbo].[Password] WHERE [UserID] = (SELECT [UserID] FROM [dbo].[User] WHERE [UserName] = '" + username + "')";
        String hash = (String)select.ExecuteScalar();

        bool admin;
        select.CommandText = "(SELECT [Admin] FROM [dbo].[User] WHERE [UserName] = '" + username + "')";
        admin = Convert.ToBoolean(select.ExecuteScalar());
        con.Close();

        bool verify = SimpleHash.VerifyHash(password, "MD5", hash);

        if (verify)
        {
            if(admin)
            {
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                //Send to user page
            }
        }
        else
        {
            lblError.Text = "Invalid username and/or password.";
        }
    }
}