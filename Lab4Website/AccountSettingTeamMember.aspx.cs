using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class AccountSettingTeamMember : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";

        con.Open();
        //Load Profile Picture
        try
        {
            
            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "SELECT ProfilePicture FROM [dbo].[User] WHERE UserID =" + Convert.ToString((int)Session["UserID"]);
            string currentPicture = (String)select.ExecuteScalar();

            profilePicture.ImageUrl = "~/Images/" + currentPicture;
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");

        }
        catch (Exception)
        {

        }
        con.Close();
    }



    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        lblCurrentPassMSG.Visible = false;
        lblNewPass1MSG.Visible = false;
        lblNewPass2MSG.Visible = false;

        //Check if current password is real password
        String currentPass = txtCurrentPass.Text;
        con.Open();
        SqlCommand select = new SqlCommand();
        select.Connection = con;
        select.CommandText = "SELECT PasswordHash FROM [dbo].[Password] WHERE UserID =" + Convert.ToString((int)Session["UserID"]);
        
        String currentHash = (String)select.ExecuteScalar();

        bool correctHash = SimpleHash.VerifyHash(currentPass, "MD5", currentHash);
        if (correctHash)
        {
            if(txtNewPass1.Text == "")
            {
                lblNewPass1MSG.Text = "(Must Enter A New Password)";
            }
            else if (txtNewPass1.Text == txtNewPass2.Text)
            {
                String newPassHash = SimpleHash.ComputeHash(txtNewPass1.Text, "MD5", null);
                select.CommandText = "UPDATE [dbo].[Password] SET [PasswordHash] = @PasswordHash WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
                select.Parameters.AddWithValue("@PasswordHash", newPassHash);
                select.ExecuteNonQuery();
            }
            else
            {
                lblNewPass1MSG.Visible = true;
                lblNewPass2MSG.Visible = true;
                lblNewPass1MSG.Text = "(New Passwords Don't Match)";
                lblNewPass2MSG.Text = "(New Passwords Don't Match)";

                lblNewPass1MSG.ForeColor = System.Drawing.Color.Red;
                lblNewPass2MSG.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        else
        {
            lblCurrentPassMSG.Text = "(Incorrect Password)";
            lblCurrentPassMSG.ForeColor = System.Drawing.Color.Red;
        }

        con.Close();

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //gets the name of the file
        string fileName = Path.GetFileName(UploadPicture.PostedFile.FileName);
        //saves file to server map
        UploadPicture.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
        

        con.Open();
        SqlCommand upload = new SqlCommand();
        upload.Connection = con;
        upload.CommandText = "UPDATE [dbo].[user] SET [ProfilePicture] = @ProfilePicture WHERE [UserID] =" + Convert.ToString((int)Session["UserID"]);
        upload.Parameters.AddWithValue("@ProfilePicture", fileName);
        upload.ExecuteNonQuery();
        con.Close();

    }
}