using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestApprovalApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null || Session["roleids"].ToString() != "2")
            {
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}