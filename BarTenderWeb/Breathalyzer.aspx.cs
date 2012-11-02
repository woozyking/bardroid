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

public partial class Breathalyzer : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Owner"] == null || Session["ValidAge"] == null)
            Response.Redirect("Default.aspx", false);
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
        this.lblContent.Text = "Stand close to the breathalyzer and gently blow some air into it.";
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        string result = BarTenderController.BarTenderController.Controller.GetBreathResult();
        if (result == "0") //pass
        {
            Session["PassBreathTest"] = "true";
            Response.Redirect("Drinks.aspx?type=alcoholic", false);
        }
        else
        {
            this.lblContent.Text = "Fail. Your alcoholic level is above the acceptable intoxicaiton level.";
            this.btnStart.Text = "Try Again";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bardroid.aspx", false); 
    }
}
