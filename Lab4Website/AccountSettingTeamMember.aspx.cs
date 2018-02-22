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
        btnEditFName.Visible = false;
    }

    protected void btnEditMI_Click(object sender, EventArgs e)
    {
        txtNewMI.Text = lblCurrentMI.Text;

        txtNewMI.Visible = true;
        btnMI.Visible = true;
        btnEditMI.Visible = false;
    }

    protected void btnEditLName_Click(object sender, EventArgs e)
    {
        txtNewLName.Text = lblCurrentLName.Text;

        txtNewLName.Visible = true;
        btnLName.Visible = true;
        btnEditLName.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtNewEmail.Text = lblCurrentEmail.Text;

        txtNewEmail.Visible = true;
        btnEmail.Visible = true;
        Button1.Visible = false;
    }

    protected void btnFName_Click(object sender, EventArgs e)
    {
        Boolean validInput = true;
        // Check if the last name is either empty or only letters exist
        if (String.IsNullOrEmpty(txtNewFName.Text))
        {
            Label1.Visible = true;
            Label1.Text = "Please fill the textbox";
            validInput = false;
        }

        // Check the lastname to ensure only letters exist and spaces allowed
        char[] LastNameCharArray = txtNewFName.Text.ToCharArray();

        for (int i = 0; i < txtNewFName.Text.Length; i++)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(
            LastNameCharArray[i].ToString(), "^[a-zA-Z]"))
            {
                if (!LastNameCharArray[i].Equals(' '))
                {
                    Label1.Visible = true;
                    Label1.Text = "Please only enter letters";
                    validInput = false;
                }
            }
        }
        //SQL to update changes
        con.Open();
        if (validInput)
        {
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
            btnEditFName.Visible = true;
            Label1.Visible = false;
        }

    }

    protected void btnMI_Click(object sender, EventArgs e)
    {
        Boolean validInput = true;
        // Check the middle name to ensure only letters 
        if (txtNewMI.Text.Length != 1 ||
            !System.Text.RegularExpressions.Regex.IsMatch(
                txtNewMI.Text, "^[a-zA-Z]"))
        {

            Label2.Visible = true;
            Label2.Text = "Please only enter letters or fill the field";
            validInput = false;
            
        }
        if (validInput)
        {
            //SQL to update changes
            con.Open();

            SqlCommand update = new SqlCommand();
            update.Connection = con;

            update.CommandText = "UPDATE [dbo].[User] SET [MI] = @MI WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
            update.Parameters.AddWithValue("MI", txtNewMI.Text);

            update.ExecuteNonQuery();
            con.Close();
            Session["MI"] = txtNewMI.Text;

            txtNewMI.Visible = false;
            btnMI.Visible = false;
            Response.Redirect(Request.RawUrl);
            btnEditMI.Visible = false;
            Label2.Visible = false;
        }
    }

    protected void btnLName_Click(object sender, EventArgs e)
    {
        Boolean validInput = true;
        // Check if the last name is either empty or only letters exist
        if (String.IsNullOrEmpty(txtNewLName.Text))
        {
            Label3.Visible = true;
            Label3.Text = "Please fill the field";
            validInput = false;
        }

        // Check the lastname to ensure only letters exist and spaces allowed
        char[] LastNameCharArray = txtNewLName.Text.ToCharArray();

        for (int i = 0; i < txtNewLName.Text.Length; i++)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(
            LastNameCharArray[i].ToString(), "^[a-zA-Z]"))
            {
                if (!LastNameCharArray[i].Equals(' '))
                {
                    Label3.Visible = true;
                    Label3.Text = "Plese only enter letters";
                    validInput = false;
                }
            }
        }
        if (validInput)
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
            btnEditLName.Visible = true;
            Label3.Visible = false;
        }
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        Boolean validInput = true;
        // Check if the Street text box is empty
        if (String.IsNullOrEmpty(txtNewEmail.Text))
        {
            Label4.Visible = true;
            Label4.Text = "This field may not be empty";
            validInput = false;
        }

        // Check if the Street text box only contains letters
        char[] StreetCharArray = txtNewEmail.Text.ToCharArray();

        for (int i = 0; i < txtNewEmail.Text.Length; i++)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(
            StreetCharArray[i].ToString(), "^[a-zA-Z]"))
            {
                if (!StreetCharArray[i].Equals(' '))
                {
                    Label4.Visible = true;
                    Label4.Text = "Only letters and spaces allowed";
                    validInput = false;
                }
            }
        }
        if (validInput)
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
            Button1.Visible = true;
            Label4.Visible = false;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        txtNewFName.Text = "Phil";
        txtNewMI.Text = "M";
        txtNewLName.Text = "Lee";
        txtNewEmail.Text = "PhillLee@Elk.com";
    }
}