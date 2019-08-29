using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace RequestApprovalApp
{
    public partial class login : System.Web.UI.Page
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["requestcreationdb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string password = TextBox2.Text;

            string usercount = scalarReturn("select count(*) from users where emailid='" + email + "' and password='" + password + "'");

            if (usercount.Equals("0"))
            {
                Response.Write("<script>alert('Invalid Email or Password')</script>");
            }
            else
            {
                Session["name"] = scalarReturn("select emailid from users where emailid='" + email + "' and password='" + password + "'");
                string roleid = scalarReturn("select roleid from users where emailid='" + email + "' and password='" + password + "'");
                if (roleid.Equals("1"))
                {
                    Session["roleids"] = roleid;
                    Response.Redirect("~/WebForm1.aspx");
                }
                else if (roleid.Equals("2"))
                {
                    Session["roleids"] = roleid;
                    Response.Redirect("~/WebForm2.aspx");
                }
                else
                {
                    Session.RemoveAll();
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }
            }

        }

        public string scalarReturn(string q)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand(q, conn);
            string s = cmd.ExecuteScalar().ToString();
            return s;

        }
    }
}