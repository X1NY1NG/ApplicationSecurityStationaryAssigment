using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationSecurityStationaryAssigment
{
    public partial class verifyemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var thevalues = Request.Form["thevalue"];
            string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "UPDATE thedetails SET VerifiedAccount=@paraverified where AuthenticationToken=@paratoken ";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@paraverified", "Yes");
            command.Parameters.AddWithValue("@paratoken", thevalues);

            connection.Open();
            int results = command.ExecuteNonQuery();
            connection.Close();

            System.Diagnostics.Debug.WriteLine(thevalues);
            Response.Redirect("Loginpage.aspx", false);
        }
    }
}