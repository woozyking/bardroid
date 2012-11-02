using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Microsoft.Data.Odbc;

public sealed class DatabaseController
{
    static DatabaseController controller;
    static readonly object padlock = new object();

    private List<Drink> drinks = new List<Drink>();

    public static DatabaseController Controller
    {
        get
        {
            lock (padlock)
            {
                if (controller == null)
                    controller = new DatabaseController();
                return controller;
            }
        }
    }

    private string dbInfo = "DRIVER={MySQL ODBC 5.1 Driver};" +
              "SERVER=localhost;" +
              "DATABASE=bartender;" +
              "UID=root;" +
              "PASSWORD=password;" +
              "OPTION=3";

    private OdbcConnection myConnection;
    private OdbcCommand myQuery;

    public DatabaseController()
    {
        Connect();
    }

    public void Connect()
    {
        myConnection = new OdbcConnection(dbInfo);
        myConnection.Open();
        myQuery = myConnection.CreateCommand();
        Console.Write("DB connect");    
    }

    public void Disconnect()
    {
        myConnection.Close();
    }

    public OdbcCommand ODBCCommand
    {
        get { return myQuery; }
        set { this.myQuery = value; }
    }   
}
