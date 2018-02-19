using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Post
{
    private int PID;
    private String value;
    private String category;
    private String description;
    private double rewardValue;
    private String postDate;
    private bool isPrivate;
    private int giverID;
    private int recieverID;

    public Post()
    {

    }
    public Post(int pID, String value, String category, String description, double rewardValue, String postDate, int giverID, int recieverID)
    {
        setPID(pID);
        setValue(value);
        setCategory(category);
        setDescription(description);
        setRewardValue(rewardValue);
        setPostDate(postDate);
        setGiverID(giverID);
        setRecieverID(recieverID);
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

    public void setPostDate(String postDate)
    {
        this.postDate = postDate;
    }

    public void setGiverID(int giverID)
    {
        this.giverID = giverID;
    }
    public void setRecieverID(int recieverID)
    {
        this.recieverID = recieverID;
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

    public String getPostDate()
    {
        return this.postDate;
    }

    public int getGiverID()
    {
        return this.giverID;
    }
    
    public int getRecieverID()
    {
        return this.recieverID;
    }

    
}