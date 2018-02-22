using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Post
{
    private int PID;
    private String value;
    private String category;
    private String description;
    private double rewardValue;
<<<<<<< HEAD
    private String postDate;
=======
    private DateTime postDate;
>>>>>>> master
    private bool isPrivate;
    private int giverID;
    private int receiverID;

    public Post()
    {

    }
<<<<<<< HEAD
    public Post(int pID, String value, String category, String description, double rewardValue, String postDate, bool isPrivate, int giverID, int receiverID)
=======
    public Post(int pID, String value, String category, String description, double rewardValue, DateTime postDate, bool isPrivate, int giverID, int receiverID)
>>>>>>> master
    {
        setPID(pID);
        setValue(value);
        setCategory(category);
        setDescription(description);
        setRewardValue(rewardValue);
        setPostDate(postDate);
        setIsPrivate(isPrivate);
        setGiverID(giverID);
        setReceiverID(receiverID);
    }

    // Setters
    public void setPID(int PID)
    {
        this.PID = PID;
    }

    public void setValue(String value)
    {
        this.value = value;
    }

    public void setCategory(String category)
    {
        this.category = category;
    }

    
    public void setDescription(String description)
    {
        this.description = description;
    }

    public void setRewardValue(double rewardValue)
    {
        this.rewardValue = rewardValue;
    }

<<<<<<< HEAD
    public void setPostDate(String postDate)
=======
    public void setPostDate(DateTime postDate)
>>>>>>> master
    {
        this.postDate = postDate;
    }

    public void setIsPrivate(bool isPrivate)
    {
        this.isPrivate = isPrivate;
    }

    public void setGiverID(int giverID)
    {
        this.giverID = giverID;
    }
    public void setReceiverID(int receiverID)
    {
        this.receiverID = receiverID;
    }

    // Getters
    public int getPID()
    {
        return this.PID;
    }

    public String getValue()
    {
        return this.value;
    }

    public String getCategory()
    {
        return this.category;
    }


    public String getDescription()
    {
        return this.description;
    }

    public double getRewardValue()
    {
        return this.rewardValue;
    }

<<<<<<< HEAD
    public String getPostDate()
=======
    public DateTime getPostDate()
>>>>>>> master
    {
        return this.postDate;
    }

    public bool getIsPrivate()
    {
        return this.isPrivate;
    }

    public int getGiverID()
    {
        return this.giverID;
    }
    
    public int getReceiverID()
    {
        return this.receiverID;
    }

    public string getGiverUsername(int giverID)
    {
        SqlConnection con = new SqlConnection();
<<<<<<< HEAD
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
=======
        con.ConnectionString = @"Server=bennskychlab4.ct7g1o0ekjxl.us-east-1.rds.amazonaws.com;Database=Lab4;User Id=bennskych;Password=lab4password;";
>>>>>>> master
        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT Username FROM [User] WHERE UserID = @userID", con);
        cmd.Parameters.AddWithValue("@userID", giverID);

        string username = (String)cmd.ExecuteScalar();
        return username;
    }

    public string getReceiverUsername(int receiverID)
    {
        SqlConnection con = new SqlConnection();
<<<<<<< HEAD
        con.ConnectionString = @"Server=LOCALHOST;Database=Lab4;Trusted_Connection=Yes;";
=======
        con.ConnectionString = @"Server=bennskychlab4.ct7g1o0ekjxl.us-east-1.rds.amazonaws.com;Database=Lab4;User Id=bennskych;Password=lab4password;";
>>>>>>> master
        con.Open();

        SqlCommand cmd = new SqlCommand("SELECT Username FROM [User] WHERE UserID = @userID", con);
        cmd.Parameters.AddWithValue("@userID", receiverID);

        string username = (String)cmd.ExecuteScalar();
        return username;
    }

    
}