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
using System.Web.Services;

using Microsoft.Data.Odbc;

public partial class CardReader : System.Web.UI.Page
{
    private static DatabaseController dbController = new DatabaseController();
    private const string PASS = "pass";
    private const string UNDERAGE = "underage";

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["Owner"] == null)
            Response.Redirect("Default.aspx");
        
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
        this.MessageText.Text = "Please swipe your Driver's License using the card reader beside the machine and then press the \"OK\" button.";        
        
        if (!Page.IsPostBack)
            DeleteBarcodeResult();
    }

    private string GetBarcodeResult()
    {
        string barcodeResult = string.Empty;
        int counter = 0;
        try
        {            
            while (barcodeResult.Equals(string.Empty))
            {
                dbController.ODBCCommand.CommandText = "SELECT * FROM barcode";
                OdbcDataReader myDataReader = dbController.ODBCCommand.ExecuteReader();
                while (myDataReader.Read())
                {                
                    barcodeResult = myDataReader.GetString(0);
                }
                myDataReader.Close();                
                System.Threading.Thread.Sleep(2000);                
                if (counter++ == 2)
                    return "error";
            }            
            return barcodeResult;
        }
        catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        {
            Console.WriteLine(MyOdbcException.Errors[0].Message);
        }
        return "error";
    }

    private void DeleteBarcodeResult()
    {
        try
        {
            dbController.ODBCCommand.CommandText = "TRUNCATE TABLE barcode";
            dbController.ODBCCommand.ExecuteReader();                       
        }
        catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        {
            Console.WriteLine(MyOdbcException.Errors[0].Message);
        }        
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {               
        string result = GetBarcodeResult();
        if (result.Equals(UNDERAGE))  //underage        
            this.MessageText.Text = "Sorry, you are not over the age requirement.";
        else if (result.Equals(PASS)) //pass
        {
            Session["ValidAge"] = "true";
            Response.Redirect("Breathalyzer.aspx");
        }
        else
            this.ErrorBox.Visible = true;    
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BarDroid.aspx");
    }
}
