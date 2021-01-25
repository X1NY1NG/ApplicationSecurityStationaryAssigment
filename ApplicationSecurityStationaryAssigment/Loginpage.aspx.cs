using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationSecurityStationaryAssigment
{
    public partial class Loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public class MyObject
        {
            public string success { get; set; }
            public List<string> ErrorMessage { get; set; }
        }
        public bool ValidateCaptcha()
        {
            bool result = true;
            string captchaResponse = Request.Form["g-recaptcha-response"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=6LeEuRAaAAAAACrdAGEPHsNy-Ftz_XMUOyK_c2ti &response=" + captchaResponse);

            try
            {
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();
                        

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        MyObject jsonObject = js.Deserialize<MyObject>(jsonResponse);
                        result = Convert.ToBoolean(jsonObject.success);
                    }
                }
                return result;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            if (ValidateCaptcha())
            {
                string password = tbpassword.Text;
                string emailid = tbemail.Text;
                SHA512Managed hashing = new SHA512Managed();
                string dbHash = getDBHash(emailid);
                string dbSalt = getDBSalt(emailid);
                try
                {
                    if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
                    {
                        string pwdWithSalt = password + dbSalt;
                        byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                        string userHash = Convert.ToBase64String(hashWithSalt);
                        if (userHash.Equals(dbHash))
                        {
                            Session["LoggedIn"] = tbemail.Text;
                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;

                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            Response.Redirect("successpage.aspx", false);

                        }
                        else
                        {
                            lbfeedback.Text = "Userid or password is not valid. Please try again.";
                        }
                    }
                    else
                    {
                        lbfeedback.Text = "Userid or password is not valid. Please try again.";

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally { }
            }

            
        }
        protected string getDBHash(string emailid)

        {
            string h = null;
            string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select Passwordhash FROM thedetails WHERE EmailAddress=@emailid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@emailid", emailid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        
                        if (reader["Passwordhash"] != null)
                        {
                            if (reader["Passwordhash"] != DBNull.Value)
                            {
                                h = reader["Passwordhash"].ToString();
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("ermalamak");
            }
            finally { connection.Close(); }
            return h;
        } 
        protected string getDBSalt(string emailid)
        {
            string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            string s = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select Passwordsalt FROM thedetails WHERE EmailAddress=@emailid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@emailid", emailid);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Passwordsalt"] != null)
                        {
                            if (reader["Passwordsalt"] != DBNull.Value)
                            {
                                s = reader["Passwordsalt"].ToString();
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
            return s;
        }
    }
}