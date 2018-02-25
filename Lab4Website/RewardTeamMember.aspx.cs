using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class RewardTeamMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Show user's name and account balance in the sidebar
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + Session["AccountBalance"];

            // On initial page load, set default values for all drop down lists and fill the drop down list containing usernames
            if (!IsPostBack)
            {
                ddlCompanyValue.ClearSelection();
                ddlCategory.ClearSelection();
                ddlRewardValue.ClearSelection();
                loadDropDown();
            }
        }
        catch (Exception)
        {
            // Return the user to the login page if something goes wrong
            Response.Redirect("LoginPage.aspx");
        }

    }

    public void loadDropDown()
    {
        // Setting up a SQL connection and command
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
<<<<<<< HEAD
=======

>>>>>>> master
        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        // Show all current users in the database besides the one using the program right now
        cmdInsert.CommandText = "SELECT Username FROM [User] WHERE [Admin] != 1 AND UserID != " + Convert.ToString((int)Session["UserID"]);

        // Instantiate SQL objects to fill the drop down list
        SqlDataAdapter da = new SqlDataAdapter(cmdInsert);
        DataTable dt = new DataTable();

        da.Fill(dt);

        drpUsernames.DataSource = dt;
        drpUsernames.DataTextField = "Username";
        drpUsernames.DataBind();

        sc.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Instantiate a new Post object and give its data fields values
        Post post = new Post();
        post.setValue(ddlCompanyValue.SelectedValue);
        post.setCategory(ddlCategory.SelectedValue);
        post.setDescription(txtDescription.Text);
        post.setRewardValue(Convert.ToDouble(ddlRewardValue.SelectedValue));
        post.setPostDate(DateTime.Now);
        post.setGiverID((int)Session["UserID"]);

        // Check if the user wanted the transaction to be public or private
        if (Convert.ToByte(chkPrivate.Checked) == 0)
        {
            post.setIsPrivate(false);
        }

        else if (Convert.ToByte(chkPrivate.Checked) == 1)
        {
            post.setIsPrivate(true);
        }

        try
        {
            // Instantiate SQL objects, set up a connection
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
<<<<<<< HEAD
=======

>>>>>>> master
            sc.Open();

            System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
            cmdInsert.Connection = sc;

            // Check if this is the user's first and only transaction of the day
            if (checkTransactionDate(post.getGiverID()) == true)
            {
                // Create a parameterized query to insert the Post object's values into the SQL database
                cmdInsert.CommandText = "INSERT INTO [dbo].[Transaction] (CompanyValue, Category, Description, RewardValue, TransactionDate,"
                    + " Private, GiverID, ReceiverID) VALUES (@CompanyValue, @Category, @Description, @RewardValue, @TransactionDate, @Private," +
                    " @GiverID, @ReceiverID)";
                cmdInsert.Parameters.AddWithValue("@CompanyValue", post.getValue());
                cmdInsert.Parameters.AddWithValue("@Category", post.getCategory());
                cmdInsert.Parameters.AddWithValue("@Description", post.getDescription());
                cmdInsert.Parameters.AddWithValue("@RewardValue", post.getRewardValue());
                cmdInsert.Parameters.AddWithValue("@TransactionDate", post.getPostDate());
                cmdInsert.Parameters.AddWithValue("@Private", post.getIsPrivate());
                cmdInsert.Parameters.AddWithValue("@GiverID", (int)Session["UserID"]);
                cmdInsert.Parameters.AddWithValue("@ReceiverID", getRecieverID(drpUsernames.SelectedItem.Text));

                cmdInsert.ExecuteNonQuery();

                // Subtract the user's chosen reward value from their current balance and the employer's total balance
                cmdInsert.CommandText = "UPDATE [Employer] SET TotalBalance = TotalBalance - @RewardValue WHERE EmployerID=1";
                cmdInsert.ExecuteNonQuery();
                cmdInsert.CommandText = "UPDATE [User] SET AccountBalance = AccountBalance + @RewardValue WHERE UserID=@ReceiverID";
                cmdInsert.ExecuteNonQuery();

                lblResult.Text = "Reward Sent.";

                sc.Close();

                //        try
                //        {
                //            System.Data.SqlClient.SqlDataReader readerEmail;
                //            SqlConnection checkemail = new SqlConnection();
                //            checkemail.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
                //            checkemail.Open();

                //            SqlCommand reademail = new SqlCommand("SELECT TotalBalance FROM Employer WHERE CompanyName='ElkLogistics'"
                //                    , checkemail);
                //            readerEmail = reademail.ExecuteReader();

                //            Decimal totalBalance = 0;

                //            while (readerEmail.Read())
                //            {
                //                totalBalance = readerEmail.GetDecimal(0);
                //            }
                //            checkemail.Close();

                //            if (totalBalance < 500)
                //            {
                //                var fromAddress = new MailAddress("elklogisticsmanagement@gmail.com", "Johnathon Hoyns");
                //                var toAddress = new MailAddress("johnathonhoyns@gmail.com", "Administrator");
                //                const string fromPassword = "Daisydoo#1pet";
                //                const string subject = "Reward balance is below 500 dollars";
                //                const string body = "Dear Administrator, It seems that"
                //                    + " the company account balance is below 500 dollars. Please consider adding additional"
                //                    + " money to the account some time today.";

                //                var smtp = new SmtpClient
                //                {
                //                    Host = "smtp.aol.com",
                //                    Port = 587,
                //                    EnableSsl = true,
                //                    DeliveryMethod = SmtpDeliveryMethod.Network,
                //                    UseDefaultCredentials = false,
                //                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                //                };
                //                using (var message = new MailMessage(fromAddress, toAddress)
                //                {
                //                    Subject = subject,
                //                    Body = body
                //                })
                //                {
                //                    smtp.Send(message);
                //                }
                //            }
                //        }
                //        catch
                //        {

                //        }

                loadDropDown();
            }
        }

        catch
        {

        }
    }



    public Boolean checkTransactionDate(int giverID)
    {
        // Instantiate a Boolean object and set its default value to true
        Boolean valid = true;

        // Instantiate SQL objects, set up a connection
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        // Get the date of the current user's most recent transaction
        cmdInsert.CommandText = "SELECT TransactionDate FROM [Transaction] WHERE TransID = (SELECT MAX(TransID) FROM [Transaction] WHERE GiverID=@giverID)";
        cmdInsert.Parameters.AddWithValue("@giverID", giverID);

        // Instantiate a new DateTime object and set its value equal to the result of the SQL statement
        DateTime transDate = Convert.ToDateTime(cmdInsert.ExecuteScalar());

        // Have the system know what the most recent transaction date is
        System.Diagnostics.Debug.WriteLine(transDate);

        // Instantiate another DateTime object and set its value equal to today's date
        DateTime today = DateTime.Today.Date;

        // Do not allow user to make more than one transaction per day
        if (transDate.Date == today)
        {
            lblResult.Text = "Cannot make two transactions in one day.";
            valid = false;
        }       

        sc.Close();
        return valid;
    }

    public int getRecieverID(String username)
    {
        // Instantiate SQL objects, set up a connection
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        // Get the current program user's UserID and return it
        cmdInsert.CommandText = "SELECT UserID FROM [User] WHERE Username = @username";
        cmdInsert.Parameters.AddWithValue("@username", username);

        int userID = (int)cmdInsert.ExecuteScalar();

        sc.Close();
        return userID;
    }

    protected void AutoFillRewardSendID_Click(object sender, EventArgs e)
    {
        txtDescription.Text = "Very good job!";
    }
}
