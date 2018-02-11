using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Post
{
    private int PID;
    private String value;
    private String category;
    private String title;
    private String description;
    private double rewardValue;
    private DateTime postDate;

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

    public void setTitle(String title)
    {
        this.title = title;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    public void setRewardValue(double rewardValue)
    {
        this.rewardValue = rewardValue;
    }

    public void setPostDate(DateTime postDate)
    {
        this.postDate = postDate;
    }

    // Setters
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

    public String getTitle()
    {
        return this.title;
    }

    public String getDescription()
    {
        return this.description;
    }

    public double getRewardValue()
    {
        return this.rewardValue;
    }

    public DateTime getPostDate()
    {
        return this.postDate;
    }

    public Post()
    {
       
    }
}