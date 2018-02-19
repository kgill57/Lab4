using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class TeamMemberPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
        con.Open();

        SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION]", con);

        //Create Scaler to see how many transactions there are
        SqlCommand scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION]", con);
        int arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        Post[] transaction = new Post[arraySize];
        int arrayCounter = 0;
        while (reader.Read())
        {
            transaction[arrayCounter] = new Post(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)), 
                Convert.ToString(reader.GetValue(2)), Convert.ToString(reader.GetValue(3)), Convert.ToDouble(reader.GetValue(4)), Convert.ToString(reader.GetValue(5)), Convert.ToInt32(reader.GetValue(7)), Convert.ToInt32(reader.GetValue(8)));
            arrayCounter++;
        }
        con.Close();
        Label[] test = new Label[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            test[i] = new Label();

            test[i].Text = (transaction[i].getGiverID() + " gifted " + transaction[i].getReceiverID());

            Panel1.Controls.Add(test[i]);
            Panel1.Controls.Add(new LiteralControl("<br />"));
        }
        


    }

}