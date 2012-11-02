using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

using BarTenderController;
using Microsoft.Data.Odbc;

public partial class Drinks : System.Web.UI.Page
{        
    private static DatabaseController dbController = new DatabaseController();
    private const string ALCOHOLIC = "alcoholic";
    private const string NONALCOHOLIC = "non-alcoholic";
    private const string BEER = "beer";
    private const string COCKTAIL = "cocktail";
    private const string POP = "pop";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
        LoadDrinkMenu();
    }

    public void LoadDrinkMenu()
    {
        string type = Request.QueryString["Type"];
        if (type == null)
            type = string.Empty;

        string output = string.Empty;
        try
        {
            if (type.Equals(ALCOHOLIC))
                dbController.ODBCCommand.CommandText = "SELECT id, name FROM drinks where alcoholic = true";
            else if (type.Equals(NONALCOHOLIC))
                dbController.ODBCCommand.CommandText = "SELECT id, name FROM drinks where alcoholic = false";
            else if (type.Equals(BEER))
                dbController.ODBCCommand.CommandText = "SELECT id, name FROM drinks where type = 'beer'";
            else if (type.Equals(COCKTAIL))
                dbController.ODBCCommand.CommandText = "SELECT id, name FROM drinks where type = 'cocktail'";
            else if (type.Equals(POP))
                dbController.ODBCCommand.CommandText = "SELECT id, name FROM drinks where type = 'pop'";
            else
                dbController.ODBCCommand.CommandText = "SELECT id, name FROM drinks";

            OdbcDataReader myDataReader = dbController.ODBCCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                int id = myDataReader.GetInt32(0);
                string name = myDataReader.GetString(1);                               
                output += "<input type=\"button\" value=\"" + name + "\" class=\"tr_button\" id=\"" + id + "\" onClick=\"parent.location='DrinkDetails.aspx?ID=" + id + "'\" /><br /><br />";
            }
            myDataReader.Close();
        }
        catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        {
            Console.WriteLine(MyOdbcException.Errors[0].Message);
        }        
        if (type != null  && !(type.Equals("pop") || type.Equals("non-alcoholic")))
            output += "<input type=\"button\" value=\"Customize Your Drinks\" class=\"tr_button\" onClick=\"parent.location='Customize.aspx'\" /><br />";
        this.DrinkMenu.Text = output;
    }        
     
}
