using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class Drink
{
    private int id;
    private string name;
    private bool alcoholic;
    private string description;
    private string image;
    private int pump1Interval;
    private int pump2Interval;
    private int pump3Interval;

    public Drink()
    {
        this.id = 0;
        this.name = string.Empty;
        this.alcoholic = false;
        this.description = string.Empty;
        this.image = string.Empty;
        this.pump1Interval = 0;
        this.pump2Interval = 0;
        this.pump3Interval = 0;
    }

    public Drink(int id, string name, bool alcoholic, string description, string image, int pump1, int pump2, int pump3)
    {
        this.id = id;
        this.name = name;
        this.alcoholic = alcoholic;
        this.description = description;
        this.image = image;
        this.pump1Interval = pump1;
        this.pump2Interval = pump2;
        this.pump3Interval = pump3;
    }

    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public bool Alcoholic
    {
        get { return this.alcoholic; }
        set { this.alcoholic = value; }
    }

    public string Description
    {
        get { return this.description; }
        set { this.description = value; }
    }

    public string Image
    {
        get { return this.image; }
        set { this.image = value; }
    }

    public int Pump1
    {
        get { return this.pump1Interval; }
        set { this.pump1Interval = value; }
    }

    public int Pump2
    {
        get { return this.pump2Interval; }
        set { this.pump2Interval = value; }
    }

    public int Pump3
    {
        get { return this.pump3Interval; }
        set { this.pump3Interval = value; }
    }
}
