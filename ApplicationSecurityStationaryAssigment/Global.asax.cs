using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ApplicationSecurityStationaryAssigment
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("doesthiswork");
            string MYDBConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            SqlConnection connections = new SqlConnection(MYDBConnectionStrings);
            string sqls = "UPDATE thedetails SET failedattempts=@paraattempts ";
            SqlCommand commands = new SqlCommand(sqls, connections);
            commands.Parameters.AddWithValue("@paraattempts",0);


            try
            {
                connections.Open();
                int results = commands.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                
            }
            finally
            {
                connections.Close();
            }

            

            


        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("bye");
        }
    }
}