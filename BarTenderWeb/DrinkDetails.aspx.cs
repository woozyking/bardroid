using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Data.Odbc;

public partial class DrinkDetails : System.Web.UI.Page
{
    private static BarTenderController.BarTenderController controller = BarTenderController.BarTenderController.Controller;
    private static DatabaseController dbController = new DatabaseController();
    private string idString;
    private NewDrink drink;

    protected void Page_Load(object sender, EventArgs e)
    {
        idString = Server.HtmlEncode(Request.QueryString["ID"]);
        //if (Session["Owner"] == null)
        //    this.btnPour.Visible = false;
        
        if (idString == null)
            Response.Redirect("Drinks.aspx");     

        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");

        LoadDrinkDetails(int.Parse(idString));        
    }

    protected void btnPour_Click(object sender, EventArgs e)
    {
        ProcessDrink();
        Response.Redirect("BarDroid.aspx", false);   
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Drinks.aspx");
    }

    public void LoadDrinkDetails(int id)
    {
        drink = new NewDrink();
        string output = string.Empty;
        try
        {
            OdbcCommand myQuery = dbController.ODBCCommand;
            myQuery.CommandText = "SELECT * FROM drinks where id = " + id;
            OdbcDataReader myDataReader = myQuery.ExecuteReader();

            while (myDataReader.Read())
            {                
                string name = myDataReader.GetString(1);
                string description = myDataReader.GetString(2);
                string ingredients = myDataReader.GetString(3);
                string imagesrc = myDataReader.GetString(4);
                bool alcoholic = myDataReader.GetBoolean(5);
                string type = myDataReader.GetString(6);
                drink = new NewDrink(id, name, description, ingredients, imagesrc, alcoholic, type);                
            }
            myDataReader.Close();
        }
        catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        {
            Console.WriteLine(MyOdbcException.Errors[0].Message);
        }
        this.DrinkName.Text = drink.Name;
        this.DrinkDescription.Text = drink.Description;
        this.DrinkImage.ImageUrl = drink.Image;        
    }

    public string ProcessDrink()
    {
        //int id = int.Parse(idString);
      
        //Drink dr = new Drink();
        //try
        //{
        //    OdbcCommand myQuery = dbController.ODBCCommand;
        //    myQuery.CommandText = "SELECT * FROM drinks where id = " + id;
        //    OdbcDataReader myDataReader = myQuery.ExecuteReader();

        //    while (myDataReader.Read())
        //    {
        //        dr = new Drink(myDataReader.GetInt32(0), myDataReader.GetString(1), myDataReader.GetBoolean(5), myDataReader.GetString(6), myDataReader.GetString(7), myDataReader.GetInt32(2), myDataReader.GetInt32(3), myDataReader.GetInt32(4));
        //    }
        //    myDataReader.Close();
        //}
        //catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        //{
        //    Console.WriteLine(MyOdbcException.Errors[0].Message);
        //}
        for (int i = 1; i <= 3; i++)
        {
            controller.PumpOn(i, drink.Ingredients[i-1].Value * 1000);
            System.Threading.Thread.Sleep(1000);
        }
        return "0";        
    }  
}
