using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;

using BarTenderController;
using Microsoft.Data.Odbc;
using System.Collections.Specialized;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
        if (Session["Owner"] == null)
            Response.Redirect("Default.aspx");
    }
   
    protected void btnliquor_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tos.aspx");
    }

    protected void btnpop_Click(object sender, EventArgs e)
    {
        Response.Redirect("Drinks.aspx?type=non-alcoholic");
    }
}