using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Update : System.Web.UI.Page
{
    ArrayList uNames = null;
    string uName = null;
    int indexRow = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection gsData = Request.QueryString;
        if (gsData.Get("uName") == null || Session["uNames"] == null)
        {
            Response.Redirect("mainData.aspx");
        }
        else
        {
            uNames = (ArrayList)Session["uNames"];
            uName = gsData.Get("uName");
            string pword = gsData.Get("pword");

        }
    }
}
//will show up on quiz 5
// exposure to a major 