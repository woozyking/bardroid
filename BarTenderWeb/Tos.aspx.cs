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
using System.IO;

public partial class Tos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
        this.Literal2.Text = File.ReadAllText(Server.MapPath("tos.txt"));
    }

    protected void btnAgree_Click(object sender, EventArgs e)
    {
        Response.Redirect("CardReader.aspx", false);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BarDroid.aspx", false);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.UrlReferrer.ToString());        
    }
}
