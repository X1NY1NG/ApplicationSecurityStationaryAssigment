using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationSecurityStationaryAssigment
{
    public partial class successpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["AuthToken"] !=null && Request.Cookies["AuthToken"]!=null)
            {
                if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    var theuser = (String)Session["LoggedIn"];
                    DateTime thetimenow = DateTime.Now;
                    string thedbvalue = retrievemaxtime(theuser);
                    if (thetimenow > Convert.ToDateTime(thedbvalue))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                        Response.Redirect("changepassword.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Loginpage.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/CustomError/error401.html", false);

            }

        }

        protected void logoutbutton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }
            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

            }
            Response.Redirect("Loginpage.aspx", false);
        }

        protected void changepassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword.aspx", false);
        }
        protected string retrievemaxtime(string userid)
        {
            string MYDBConnectionStrin = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            string G = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionStrin);
            string sql = "select maximumpasswordage FROM thedetails WHERE EmailAddress=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["maximumpasswordage"] != null)
                        {
                            if (reader["maximumpasswordage"] != DBNull.Value)
                            {
                                G = reader["maximumpasswordage"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return G;
        }
    }
}