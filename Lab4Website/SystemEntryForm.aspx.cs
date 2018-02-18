// We have neither given nor received help on this assignment
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemEntryForm : System.Web.UI.Page
{
    //Project newProject;


    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void TrigSearchProject(object sender, EventArgs e)
    {
        Boolean textError = true;
        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty(projectNameSearch.Text))
        {
            try
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = @"Data Source=LOCALHOST;Initial Catalog=lab3;Integrated Security=True";

                sc.Open();
                //Declare the query string.

                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT *" +
                    " FROM PROJECT;", sc);
                del.ExecuteNonQuery();

                projectGridView.DataSource = del.ExecuteReader();
                projectGridView.DataBind();
                sc.Close();
            }
            catch
            {

            }
        }
        else
        {
            try
        {

            SqlConnection sc = new SqlConnection(@"Data Source=DESKTOP-08HFDJ7\\LOCALHOST;Initial Catalog=lab3;Integrated Security=True");
            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM PROJECT WHERE ProjectName LIKE '%' + @ProjectName;", sc);
            del.Parameters.AddWithValue("@ProjectName", projectNameSearch.Text);
            del.ExecuteNonQuery();

            projectGridView.DataSource = del.ExecuteReader();
            projectGridView.DataBind();
            sc.Close();

        }
        catch
        {

        }
        }

    }

    protected void projectGridView_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        projectGridView.EditIndex = e.NewEditIndex;
        fillGridView();
    }

    protected void fillGridView()
    {
        try
        {

            SqlConnection sc = new SqlConnection(@"Data Source=LOCALHOST;Initial Catalog=lab3;Integrated Security=True");
            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM PROJECT;", sc);
            del.ExecuteNonQuery();

            projectGridView.DataSource = del.ExecuteReader();
            projectGridView.DataBind();
            sc.Close();

        }
        catch
        {

        }
    }



    protected void projectGridView_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Data Source=LOCALHOST;Initial Catalog=lab3;Integrated Security=True";

        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((projectGridView.Rows[e.RowIndex].FindControl("ProjectNametxt") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((projectGridView.Rows[e.RowIndex].FindControl("ProjectDescriptiontxt") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        string name = (projectGridView.Rows[e.RowIndex].FindControl("ProjectNametxt") as TextBox).Text.ToString().ToLower();
        Console.WriteLine();
        if (textError)
        {
            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE PROJECT SET projectName=@projectName, " +
                    "projectDescription=@projectDescription WHERE projectID=@projectID", sc);
                del.Parameters.AddWithValue("@projectName", (projectGridView.Rows[e.RowIndex].FindControl("ProjectNametxt") as TextBox).Text.ToString().ToLower());
                del.Parameters.AddWithValue("@projectDescription", (projectGridView.Rows[e.RowIndex].FindControl("ProjectDescriptiontxt") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@ProjectID", Convert.ToInt32(projectGridView.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                projectGridView.EditIndex = -1;

                fillGridView();
            }
            catch
            {

            }
        }

    }

    protected void projectGridView_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        projectGridView.EditIndex = -1;
        fillGridView();
    }


    protected void projectGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Data Source=LOCALHOST;Initial Catalog=lab3;Integrated Security=True";

            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM PROJECT WHERE ProjectID = @ProjectID;", sc);
            del.Parameters.AddWithValue("@ProjectID", Convert.ToInt32(projectGridView.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            sc.Close();
            fillGridView();
        }
        catch
        {

        }
    }

    protected void projectGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Project newProject = new Project((projectGridView.FooterRow.FindControl("ProjectNametxt") as TextBox).Text,
            (projectGridView.FooterRow.FindControl("ProjectDescriptiontxt") as TextBox).Text,
            "Hoyns", 
            DateTime.Now.ToString());


        //try/catch for emptying the Project table, adding the array elements to the Project table and updating the

        //Project table with the needed null values
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = "Data Source=DESKTOP-08HFDJ7\\localhost;Initial Catalog=lab3;Integrated Security=True";

            sc.Open();

            // insert Employee values from the Employee array
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand("insert into [dbo].[Project] values(@ProjectName, @ProjectDescription," +
                " @LastUpdatedBy, @LastUpdated);");
            insert.Connection = sc;
            insert.Parameters.AddWithValue("@ProjectName", newProject.getprojectName().ToString().ToLower());
            insert.Parameters.AddWithValue("@ProjectDescription", newProject.getprojectDescription().ToString());
            insert.Parameters.AddWithValue("@LastUpdatedBy", newProject.getLastUpdatedBy().ToString());
            insert.Parameters.AddWithValue("@LastUpdated", newProject.getLastUpdated().ToString());
            insert.ExecuteNonQuery();

            ProjectInsertSuccess.Visible = true;
            ProjectInsertSuccess.Text = "Success commiting to the database";




            sc.Close();



        }
        catch (Exception err)
        {
            ProjectInsertSuccess.Visible = true;
            ProjectInsertSuccess.Text = "Error commiting to the database";
        }
    }
}

