using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ViewRewards : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillGridView();
    }

    protected void fillGridView()
    {
        try
        {

            SqlConnection sc = new SqlConnection(@"Data Source=DESKTOP-CCFVS7L\SQLEXPRESS;Initial Catalog=lab4;Integrated Security=True");
            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM Reward;", sc);
            del.ExecuteNonQuery();

            grdRewards.DataSource = del.ExecuteReader();
            grdRewards.DataBind();
            sc.Close();

        }
        catch
        {

        }
    }

    
}