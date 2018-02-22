using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class AccountSettingTeamMember : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Load Labels
        lblCurrentFName.Text = (String)Session["FName"];
        lblCurrentMI.Text = (String)Session["MI"];
        lblCurrentLName.Text = (String)Session["LName"];
        lblCurrentEmail.Text = (String)Session["Email"];

        con = new SqlConnection();
        con.ConnectionString = @"Server=bennskychlab4.ct7g1o0ekjxl.us-east-1.rds.amazonaws.com;Database=Lab4;User Id=bennskych;Password=lab4password;";
    }

    protected void btnEditFName_Click(object sender, EventArgs e)
    {
        txtNewFName.Text = lblCurrentFName.Text;

        txtNewFName.Visible = true;
        btnFName.Visible = true;
    }

    protected void btnEditMI_Click(object sender, EventArgs e)
    {
        txtNewMI.Text = lblCurrentMI.Text;

        txtNewMI.Visible = true;
        btnMI.Visible = true;
    }

    protected void btnEditLName_Click(object sender, EventArgs e)
    {
        txtNewLName.Text = lblCurrentLName.Text;

        txtNewLName.Visible = true;
        btnLName.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtNewEmail.Text = lblCurrentEmail.Text;

        txtNewEmail.Visible = true;
        btnEmail.Visible = true;
    }

    protected void btnFName_Click(object sender, EventArgs e)
    {
        //SQL to update changes
        
        con.Open();

        SqlCommand update = new SqlCommand();
        update.Connection = con;

        update.CommandText = "UPDATE [dbo].[User] SET [FName] = @FName WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
        update.Parameters.AddWithValue("@FName", txtNewFName.Text);

        update.ExecuteNonQuery();
        con.Close();
        Session["FName"] = txtNewFName.Text;
        txtNewFName.Visible = false;
        btnFName.Visible = false;

        Response.Redirect(Request.RawUrl);

    }

    protected void btnMI_Click(object sender, EventArgs e)
    {
        //SQL to update changes

        con.Open();

        SqlCommand update = new SqlCommand();
        update.Connection = con;

        if(txtNewMI.Text != "")
        {
            update.CommandText = "UPDATE [dbo].[User] SET [MI] = @MI WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
            update.Parameters.AddWithValue("MI", txtNewMI.Text);

            update.ExecuteNonQuery();
            con.Close();
            Session["MI"] = txtNewMI.Text;

            
        }
        txtNewMI.Visible = false;
        btnMI.Visible = false;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnLName_Click(object sender, EventArgs e)
    {
        //SQL to update changes
        con.Open();

        SqlCommand update = new SqlCommand();
        update.Connection = con;

        update.CommandText = "UPDATE [dbo].[User] SET [LName] = @LName WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
        update.Parameters.AddWithValue("@LName", txtNewLName.Text);

        update.ExecuteNonQuery();
        con.Close();
        Session["LName"] = txtNewLName.Text;

        txtNewLName.Visible = false;
        btnLName.Visible = false;
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        //SQL to update changes
        con.Open();

        SqlCommand update = new SqlCommand();
        update.Connection = con;

        update.CommandText = "UPDATE [dbo].[User] SET [Email] = @Email WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
        update.Parameters.AddWithValue("@Email", txtNewEmail.Text);

        update.ExecuteNonQuery();
        con.Close();
        Session["Email"] = txtNewEmail.Text;

        txtNewEmail.Visible = false;
        btnEmail.Visible = false;

        Response.Redirect(Request.RawUrl);
    }
}