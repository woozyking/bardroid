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

public partial class Login : System.Web.UI.Page
{
    private static DatabaseController dbController = new DatabaseController();
    private OdbcCommand myQuery;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
    }

    private bool IsAuthenticate()
    {
        if (this.tbusername.Text.Equals("aa") && this.tbpassword.Text.Equals("aa"))
        {
            if (IsNoSessionExists())
            {
                CreateSession();
                return true;
            }
            this.ErrorBox.Text = "A user is already logged in.";
            this.ErrorBox.Visible = true;
            return false;
        }
        this.ErrorBox.Text = "Incorrect username or password.";
        this.ErrorBox.Visible = true;
        return false;
    }

    private bool IsNoSessionExists()
    {
        try
        {
            myQuery.CommandText = "SELECT id FROM session";
            OdbcDataReader myDataReader = myQuery.ExecuteReader();
            bool noSessionExists = !myDataReader.Read();
            myDataReader.Close();
            return noSessionExists;
        }
        catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        {
            Console.WriteLine(MyOdbcException.Errors[0].Message);
        }        
        return false;
    }


    public void CreateSession()
    {
        Session["Owner"] = this.tbusername.Text;
        //try
        //{
        //    string query = "Insert into session (sessionid, username, created) Values ('";
        //    query += this.Session.SessionID + "', '";
        //    query += this.username + "', NOW())";            

        //    myQuery.CommandText = query;
        //    OdbcDataReader myDataReader = myQuery.ExecuteReader();
        //    myDataReader.Close();
        //}
        //catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
        //{
        //    Console.WriteLine(MyOdbcException.Errors[0].Message);
        //}
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        myQuery = dbController.ODBCCommand;
        if (IsAuthenticate())
            Response.Redirect("Owner.aspx");
    }
}
