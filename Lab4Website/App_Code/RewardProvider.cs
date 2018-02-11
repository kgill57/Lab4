using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class RewardProvider
{
    private int companyID;
    private String name;
    private String email;

    // Setters
    public void setCompanyID(int companyID)
    {
        this.companyID = companyID;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }

    // Getters
    public int getCompanyID()
    {
        return this.companyID;
    }

    public String getName()
    {
        return this.name;
    }

    public String getEmail()
    {
        return this.email;
    }

    public RewardProvider()
    {
        
    }
}