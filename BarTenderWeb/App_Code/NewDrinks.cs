using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class NewDrink
{
    private int id;
    private string name;
    private string description;
    private List<NVP> ingredients = new List<NVP>();
    private string image;
    private bool alcoholic;
    private string type;

    public NewDrink()
    {
        this.id = 0;
        this.name = string.Empty;        
        this.description = string.Empty;
        this.image = string.Empty;
        this.alcoholic = false;
        this.type = string.Empty;
    }

    public NewDrink(int id, string name, string description, string ingredients, string image, bool alcoholic, string type)
    {
        this.id = id;
        this.name = name;        
        this.description = description;
        this.image = image;
        this.alcoholic = alcoholic;
        this.type = type;
        ProcessIngredients(ingredients);
    }

    public void ProcessIngredients(string text)
    {
        string[] nvps = text.Split(',');
        foreach (string nvp in nvps)
        {
            string[] ingred = nvp.Split('=');
            if (ingred.Length == 2)
                this.ingredients.Add(new NVP(ingred[0], int.Parse(ingred[1])));
        }
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
    
    public List<NVP> Ingredients
    {
        get { return this.ingredients; }
        set { this.ingredients = value; }
    } 
    
    public string Image
    {
        get { return this.image; }
        set { this.image = value; }
    }

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

       
}
