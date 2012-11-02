using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Data.Odbc;

public partial class CustomizeDrinks : System.Web.UI.Page
{
    private static BarTenderController.BarTenderController controller = BarTenderController.BarTenderController.Controller;
    private static DatabaseController dbController = new DatabaseController();
    private List<MotorDrink> md = new List<MotorDrink>();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
        if (!Page.IsPostBack)
        {
            string a = Server.HtmlEncode(Request.QueryString["_a"]);
            string s = Server.HtmlEncode(Request.QueryString["_s"]);
            LoadPump();
            if (a != null && a.Equals("admin"))
            {
                if (s != null && s.Equals("SetPump"))
                {
                    LoadSetPump();
                    this.pnSetPump.Visible = true;
                    this.pnCustomize.Visible = false;
                }
                else
                {
                    LoadCustomize();
                    this.pnSetPump.Visible = false;
                    this.pnCustomize.Visible = true;
                    this.pnNameOfDrink.Visible = true;
                }
            }
            else
            {
                LoadCustomize();
                this.btnSave.Text = "Pour";
                this.pnSetPump.Visible = false;
                this.pnCustomize.Visible = true;
                this.pnNameOfDrink.Visible = false;
            }
        }
    }
    
    public void LoadPump()
    {
        try
        {            
            dbController.ODBCCommand.CommandText = "SELECT * FROM pumps";
            OdbcDataReader myDataReader = dbController.ODBCCommand.ExecuteReader();
            while (myDataReader.Read())
            {
                md.Add(new MotorDrink(myDataReader.GetInt32(0), myDataReader.GetString(1)));
            }
            myDataReader.Close();
        }
        catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        {
            Console.WriteLine(MyOdbcException.Errors[0].Message);
        }
    }

    private void LoadSetPump()
    {
        this.lblInstr.Text = "Please enter the drink type for each pump.";        
        this.tbMotor1.Text = md[0].LiquidType;
        this.tbMotor2.Text = md[1].LiquidType;
        this.tbMotor3.Text = md[2].LiquidType;
    }

    private void LoadCustomize()
    {
        this.lblInstr.Text = "Please select the number of shots per drink type.";        
        this.lblMotor1.Text = md[0].LiquidType;
        this.lblMotor2.Text = md[1].LiquidType;
        this.lblMotor3.Text = md[2].LiquidType;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string a = Server.HtmlEncode(Request.QueryString["_a"]);
        string s = Server.HtmlEncode(Request.QueryString["_s"]);
        
        this.lbbSaveResult.Visible = true;

        if (a != null && a.Equals("admin") &&  s != null && s.Equals("SetPump"))
        {
            try
            {                
                dbController.ODBCCommand.CommandText = "Update pumps set liquidname = '" + this.tbMotor1.Text + "' where pumpno = '1'";
                dbController.ODBCCommand.ExecuteReader();
                dbController.Disconnect();
                dbController.Connect();
                dbController.ODBCCommand.CommandText = "Update pumps set liquidname = '" + this.tbMotor2.Text + "' where pumpno = '2'";
                dbController.ODBCCommand.ExecuteReader();
                dbController.Disconnect();
                dbController.Connect();
                dbController.ODBCCommand.CommandText = "Update pumps set liquidname = '" + this.tbMotor3.Text + "' where pumpno = '3'";
                dbController.ODBCCommand.ExecuteReader();
            }
            catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
            {
                Console.WriteLine(MyOdbcException.Errors[0].Message);
                this.lbbSaveResult.Text = "Save was unsuccesfully.";
                return;
            }
            this.lbbSaveResult.Text = "Save was succesfully.";
        }
        else if (a != null && a.Equals("admin"))
        {
            string query = "Insert into drinks (name, description, ingredients, images, alcoholic, type) Values (";
            query += "'" + this.tbDrinkName.Text + "',";
            query += "'Customed Drink',";
            query += "'" + this.lblMotor1.Text + "=" + this.TextBox1.Text + ",";
            query += this.lblMotor2.Text + "=" + this.TextBox2.Text + ",";
            query += this.lblMotor3.Text + "=" + this.TextBox3.Text + "',";
            query += "'images/cocktail-icon.png',";
            query += "'1',";
            query += "'cocktail')";

            dbController.ODBCCommand.CommandText = query;
            dbController.ODBCCommand.ExecuteReader();

            this.lbbSaveResult.Text = "Drink has been added into database.";
        }
        else
        {
            controller.PumpOn(1, int.Parse(this.TextBox1.Text) * 1000);
            System.Threading.Thread.Sleep(1000);
            controller.PumpOn(2, int.Parse(this.TextBox1.Text) * 1000);
            System.Threading.Thread.Sleep(1000);
            controller.PumpOn(3, int.Parse(this.TextBox1.Text) * 1000);
            System.Threading.Thread.Sleep(1000);
        }
    }
    
    private int drinkMax = 4;    

    private int GetCounter()
    {
        return int.Parse(this.TextBox1.Text) + int.Parse(this.TextBox2.Text) + int.Parse(this.TextBox3.Text);
    }

    protected void btnDown1_Click(object sender, EventArgs e)
    {        
        if (int.Parse(this.TextBox1.Text) > 0)
            this.TextBox1.Text = "" + (int.Parse(this.TextBox1.Text) - 1);        
    }

    protected void btnUp1_Click(object sender, EventArgs e)
    {
        if (GetCounter() < drinkMax)
            this.TextBox1.Text = "" + (int.Parse(this.TextBox1.Text) + 1);
    }

    protected void btnDown2_Click(object sender, EventArgs e)
    {
        if (int.Parse(this.TextBox2.Text) > 0)
            this.TextBox2.Text = "" + (int.Parse(this.TextBox2.Text) - 1);
    }

    protected void btnUp2_Click(object sender, EventArgs e)
    {
        if (GetCounter() <= drinkMax)
            this.TextBox2.Text = "" + (int.Parse(this.TextBox2.Text) + 1); ;
    }

    protected void btnDown3_Click(object sender, EventArgs e)
    {
        if (int.Parse(this.TextBox3.Text) > 0)
            this.TextBox3.Text = "" + (int.Parse(this.TextBox3.Text) - 1);
    }

    protected void btnUp3_Click(object sender, EventArgs e)
    {
        if (GetCounter() <= drinkMax)
            this.TextBox3.Text = "" + (int.Parse(this.TextBox3.Text) + 1);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.UrlReferrer.ToString());
    }

    protected void btnPour_Click(object sender, EventArgs e)
    {
        controller.PumpOn(1, int.Parse(this.TextBox1.Text) * 1000);
        System.Threading.Thread.Sleep(1000);
        controller.PumpOn(2, int.Parse(this.TextBox2.Text) * 1000);
        System.Threading.Thread.Sleep(1000);
        controller.PumpOn(3, int.Parse(this.TextBox3.Text) * 1000);
        System.Threading.Thread.Sleep(1000);
    }

    class MotorDrink
    {
        private int motorNo;
        private string liquidType;

        public MotorDrink(int motor, string liquidType)
        {
            this.motorNo = motor;
            this.liquidType = liquidType;
        }

        public int MotorNo
        {
            get { return this.motorNo; }
            set { this.motorNo = value; }
        }

        public string LiquidType
        {
            get { return this.liquidType; }
            set { this.liquidType = value; }
        }
    }
}
