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

public partial class Owner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Owner"] == null)        
            Response.Redirect("Default.aspx");
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
    }
    protected void btnStart_Click(object sender, EventArgs e)
    {
        Response.Redirect("BarDroid.aspx");  
    }
    protected void btnAddDrinks_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomizeDrinks.aspx?_a=admin");
    }
    protected void btnSetPump_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomizeDrinks.aspx?_a=admin&_s=SetPump");  
    }
}
