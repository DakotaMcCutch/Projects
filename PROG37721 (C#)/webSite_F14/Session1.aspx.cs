using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Session1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //create session variables
        Session["myInt"] = 5;
        Session["myDouble"] = 9.5;
        Session["myString"] = "ABC";
        Response.Redirect("Session2.aspx");
    }
}