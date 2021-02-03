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
using System.Drawing;
using System.Text.RegularExpressions;

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
                
                

                DateTime thetimenow = DateTime.Now;
                string xMYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
                SqlConnection xconnection = new SqlConnection(xMYDBConnectionString);
                string xsql = "UPDATE thedetails SET status=@parastatus where @paraaccountlocktime>accountendlocktime ";
                SqlCommand xcommand = new SqlCommand(xsql, xconnection);
                xcommand.Parameters.AddWithValue("@parastatus", "enabled");
                xcommand.Parameters.AddWithValue("@paraaccountlocktime", thetimenow);
                xconnection.Open();
                int xresult = xcommand.ExecuteNonQuery();
                xconnection.Close();

                
                var executeaction=verifying();
                if (executeaction == "true") {





                    string password = tbpassword.Text;
                    string emailid = tbemail.Text;

                    string h = null;
                    string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
                    SqlConnection connection = new SqlConnection(MYDBConnectionString);
                    string sql = "select status FROM thedetails WHERE EmailAddress=@emailid";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@emailid", emailid);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                if (reader["status"] != null)
                                {
                                    if (reader["status"] != DBNull.Value)
                                    {
                                        h = reader["status"].ToString();
                                    }
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        lbfeedback.Text = "Error";
                    }
                    finally { connection.Close(); }
                    if (h != "locked")
                    {
                        SHA512Managed hashing = new SHA512Managed();
                        string dbHash = getDBHash(emailid);
                        string dbSalt = getDBSalt(emailid);
                        string answer = getverified(emailid);
                        System.Diagnostics.Debug.WriteLine(answer);
                        try
                        {

                            if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
                            {
                                string pwdWithSalt = password + dbSalt;
                                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                                string userHash = Convert.ToBase64String(hashWithSalt);
                                if (userHash.Equals(dbHash))
                                {
                                    if (answer == "Yes")
                                    {
                                        Session["LoggedIn"] = tbemail.Text;
                                        string guid = Guid.NewGuid().ToString();
                                        Session["AuthToken"] = guid;

                                        Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                                        Response.Redirect("successpage.aspx", false);
                                    }
                                    else
                                    {
                                        lbfeedback.Text = "Please Verify Your Email Address First";
                                    }








                                }
                                else
                                {


                                    String thecounter = "";
                                    string MYDBConnectionStringg = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
                                    SqlConnection connectiong = new SqlConnection(MYDBConnectionStringg);
                                    string sqlg = "select failedattempts FROM thedetails WHERE EmailAddress=@emailid";
                                    SqlCommand commandg = new SqlCommand(sqlg, connectiong);
                                    commandg.Parameters.AddWithValue("@emailid", emailid);
                                    try
                                    {
                                        connectiong.Open();
                                        using (SqlDataReader reader = commandg.ExecuteReader())
                                        {

                                            while (reader.Read())
                                            {

                                                if (reader["failedattempts"] != null)
                                                {
                                                    if (reader["failedattempts"] != DBNull.Value)
                                                    {
                                                        thecounter = reader["failedattempts"].ToString();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                        throw new Exception(ex.ToString());
                                    }
                                    finally { connectiong.Close(); }

                                    string MYDBConnectionStringx = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
                                    SqlConnection connectionx = new SqlConnection(MYDBConnectionStringx);
                                    string sqlx = "UPDATE thedetails SET failedattempts=@paraattempts  WHERE EmailAddress=@emailid";
                                    SqlCommand commandx = new SqlCommand(sqlx, connectionx);
                                    commandx.Parameters.AddWithValue("@paraattempts", Convert.ToInt32(thecounter) + 1);
                                    commandx.Parameters.AddWithValue("@emailid", emailid);

                                    connectionx.Open();
                                    int resultx = commandx.ExecuteNonQuery();
                                    connectionx.Close();



                                    if (Convert.ToInt32(thecounter) + 1 == 3)
                                    {
                                        DateTime localDate = DateTime.Now;
                                        System.Diagnostics.Debug.WriteLine(localDate);
                                        DateTime endoflockout = localDate.AddMinutes(15);
                                        System.Diagnostics.Debug.WriteLine(endoflockout);

                                        string MYDBConnectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
                                        SqlConnection connections = new SqlConnection(MYDBConnectionStrings);
                                        string sqls = "UPDATE thedetails SET status=@parastatus,accountendlocktime=@paraendtime WHERE EmailAddress=@emailid";
                                        SqlCommand commands = new SqlCommand(sqls, connections);
                                        commands.Parameters.AddWithValue("@parastatus", "locked");
                                        commands.Parameters.AddWithValue("paraendtime", endoflockout);
                                        commands.Parameters.AddWithValue("@emailid", emailid);
                                        connections.Open();
                                        int results = commands.ExecuteNonQuery();
                                        connections.Close();
                                        lbfeedback.Text = "Your Account has been locked , Please try again later";
                                    }
                                    else if (Convert.ToInt32(thecounter) + 1 > 3)
                                    {
                                        lbfeedback.Text = "Your Account has been locked , Please try again later after 15 minutes";
                                    }
                                    else
                                    {
                                        var theattemptleft = 3 - (Convert.ToInt32(thecounter) + 1);
                                        lbfeedback.Text = "Login attempt failed" + theattemptleft + " attempts left";
                                        System.Diagnostics.Debug.WriteLine("helloworld");
                                    }



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
                    else
                    {
                        lbfeedback.Text = "Your Account has been locked ,too bad";
                    }

                }
                else
                {

                }
                

                
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
        protected string getverified(string emailid)
        {
            string MYDBConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            string M = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionStr);
            string sql = "select VerifiedAccount FROM thedetails WHERE EmailAddress=@emailid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@emailid", emailid);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["VerifiedAccount"] != null)
                        {
                            if (reader["VerifiedAccount"] != DBNull.Value)
                            {
                                M = reader["VerifiedAccount"].ToString();
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
            return M;
        }
        protected string verifying()
        {
            lbfeedback.Text = String.Empty;
            if (String.IsNullOrEmpty(tbemail.Text))
            {
                lbfeedback.Text = lbfeedback.Text + "Email Field is required" + "<br/>"; ;
                lbfeedback.ForeColor = Color.Red;
            }
            else
            {
                if (Regex.IsMatch(tbemail.Text, @"^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}|\d+)$"))
                {

                }
                else
                {
                    lbfeedback.Text = lbfeedback.Text + "Please Enter Valid Email" + "<br/>"; ;

                }
            }
            if (String.IsNullOrEmpty(tbpassword.Text))
            {
                lbfeedback.Text = lbfeedback.Text + "Password Field is required" + "<br/>"; ;
                lbfeedback.ForeColor = Color.Red;
            }
            else
            {
                
                if (Regex.IsMatch(tbpassword.Text, "['<>&#\"]"))
                {
                    lbfeedback.Text = lbfeedback.Text + "Please Enter Valid Password" + "<br/>"; 
                }
                else
                {
                   

                }
            }
            if (String.IsNullOrEmpty(lbfeedback.Text))
            {
                return "true";
            }
            else
            {
                return "false";
            }


        }

    }
}