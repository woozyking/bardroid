using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class NVP
{
    private string name;
    private int value;

    public NVP(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

}
