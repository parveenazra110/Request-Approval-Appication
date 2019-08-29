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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["requestcreationdb"].ToString());
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("uspCreateRequest", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string desc = TextBox1.Text;
            cmd.Parameters.AddWithValue("@requestdesc", desc);
            cmd.Parameters.AddWithValue("@emailid", Session["name"]);
            if (desc != null || desc != string.Empty)
            {


                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Request Created Successfully.')</script>");
                    TextBox1.Text = String.Empty;
                }
                catch
                {
                    Response.Write("<script>alert('Invalid input. Cannot create your request.')</script>");
                }
                finally
                {
                    conn.Close();
                }
            }
            else {
                Response.Write("<script>alert('Please provide request description')</script>");
            }
            
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("uspGetRequestForUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            List<request> reqlist = new List<request>();
            cmd.Parameters.AddWithValue("@emailid", Session["name"]);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    request reqobj = new request()
                    {
                        reqid = Convert.ToInt32(rdr[0]),
                        reqdesc = Convert.ToString(rdr[1]),
                        emailid = Convert.ToString(rdr[2]),
                        reqstatus = Convert.ToString(rdr[3])
                    };

                    reqlist.Add(reqobj);
                }
                GridView1.DataSource = reqlist;
                GridView1.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('Some error occured while processing you request')</script>");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}