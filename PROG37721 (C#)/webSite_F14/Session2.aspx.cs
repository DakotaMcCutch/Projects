using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sesion2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int myInt = Convert.ToInt32(Session["myInt"]);
        double myDouble = Convert.ToDouble(Session["myDouble"]);
        //string myString = Session["myString"].ToString();
        string myString = Convert.ToString(Session["myString"]);

        //display
        Response.Write("myInt =" + myInt + " MyDouble = " + myDouble + " myString = " + myString);
    }
}