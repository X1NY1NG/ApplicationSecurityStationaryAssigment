using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationSecurityStationaryAssigment
{
    public partial class changepassword : System.Web.UI.Page
    {
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
        static string finalHash;
        static string salt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {

                }
                else
                {
                    Response.Redirect("Loginpage.aspx", false);
                }
            }
            else
            {
                Response.Redirect("Loginpage.aspx", false);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pwd = currentpassword.Text.ToString();
            string userid = (String)Session["LoggedIn"];
            SHA512Managed hashing = new SHA512Managed();
            string dbHash = getDBHash(userid);
            string dbSalt = getDBSalt(userid);

            try
            {
                if(dbSalt!=null && dbSalt.Length>0 && dbHash!=null && dbHash.Length > 0)
                {
                    string pwdwithSalt = pwd + dbSalt;
                    byte[] hashWithSalt = hashing.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pwdwithSalt));
                    string userHash = Convert.ToBase64String(hashWithSalt);
                    if (userHash.Equals(dbHash))
                    {
                        DateTime thedatenow = DateTime.Now;
                        DateTime theminage = Convert.ToDateTime(retrieveminpwdage(userid));
                        if (thedatenow > theminage)
                        {
                            string newpwd = newpassword.Text.ToString();
                            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                            byte[] saltByte = new byte[8];
                            rng.GetBytes(saltByte);
                            salt = Convert.ToBase64String(saltByte);
                            SHA512Managed newhashing = new SHA512Managed();
                            string newpwdwithsalt = newpwd + salt;
                            byte[] plainHash = hashing.ComputeHash(System.Text.Encoding.UTF8.GetBytes(newpwd));
                            string stringplainHash = Convert.ToBase64String(plainHash);

                            byte[] newhashWithSalt = hashing.ComputeHash(System.Text.Encoding.UTF8.GetBytes(newpwdwithsalt));
                            finalHash = Convert.ToBase64String(newhashWithSalt);

                            string passwordlist = getPasswordlist(userid);
                            

                            string newpasswordlist = passwordlist + stringplainHash + ",";

                            string[] splittingtime = passwordlist.Split(',');
                            int thecount = splittingtime.Length;
                            if (thecount > 2)
                            {
                                if (thecount >= 3)
                                {
                                    if (stringplainHash == splittingtime[thecount - 3])
                                    {
                                        Label2.Text = "Please do not reuse the passwords";
                                    }
                                    else
                                    {
                                        DateTime thetime = DateTime.Now;
                                        DateTime endoflockout = thetime.AddMinutes(5);
                                        DateTime maxage = thetime.AddMinutes(15);
                                        SqlConnection connections = new SqlConnection(MYDBConnectionString);
                                        string sqls = "UPDATE thedetails SET Passwordhash=@parapasswordhash,Passwordsalt=@parapasswordsalt,listofpasswords=@paralistpwds,minimumpasswordage=@paraminage,maximumpasswordage=@paramaxage ";
                                        SqlCommand commands = new SqlCommand(sqls, connections);
                                        commands.Parameters.AddWithValue("@parapasswordhash", finalHash);
                                        commands.Parameters.AddWithValue("@parapasswordsalt", salt);
                                        commands.Parameters.AddWithValue("@paralistpwds", newpasswordlist);
                                        commands.Parameters.AddWithValue("@paraminage", endoflockout);
                                        commands.Parameters.AddWithValue("@paramaxage", maxage);

                                        connections.Open();
                                        int results = commands.ExecuteNonQuery();
                                        connections.Close();
                                        Response.Redirect("successpage.aspx", false);
                                    }
                                }else if (thecount >= 4)
                                {
                                    if (stringplainHash == splittingtime[thecount - 3] || stringplainHash == splittingtime[thecount - 4])
                                    {
                                        Label2.Text = "Please do not reuse the passwords";
                                    }
                                    else
                                    {
                                        DateTime thetime = DateTime.Now;
                                        DateTime endoflockout = thetime.AddMinutes(5);
                                        DateTime maxage = thetime.AddMinutes(15);
                                        SqlConnection connections = new SqlConnection(MYDBConnectionString);
                                        string sqls = "UPDATE thedetails SET Passwordhash=@parapasswordhash,Passwordsalt=@parapasswordsalt,listofpasswords=@paralistpwds,minimumpasswordage=@paraminage,maximumpasswordage=@paramaxage ";
                                        SqlCommand commands = new SqlCommand(sqls, connections);
                                        commands.Parameters.AddWithValue("@parapasswordhash", finalHash);
                                        commands.Parameters.AddWithValue("@parapasswordsalt", salt);
                                        commands.Parameters.AddWithValue("@paralistpwds", newpasswordlist);
                                        commands.Parameters.AddWithValue("@paraminage", endoflockout);
                                        commands.Parameters.AddWithValue("@paramaxage", maxage);

                                        connections.Open();
                                        int results = commands.ExecuteNonQuery();
                                        connections.Close();
                                        Response.Redirect("successpage.aspx", false);
                                    }
                                }
                             
                                
                                else
                                {
                                    DateTime thetime = DateTime.Now;
                                    DateTime endoflockout = thetime.AddMinutes(5);
                                    DateTime maxage = thetime.AddMinutes(15);
                                    SqlConnection connections = new SqlConnection(MYDBConnectionString);
                                    string sqls = "UPDATE thedetails SET Passwordhash=@parapasswordhash,Passwordsalt=@parapasswordsalt,listofpasswords=@paralistpwds,minimumpasswordage=@paraminage,maximumpasswordage=@paramaxage ";
                                    SqlCommand commands = new SqlCommand(sqls, connections);
                                    commands.Parameters.AddWithValue("@parapasswordhash", finalHash);
                                    commands.Parameters.AddWithValue("@parapasswordsalt", salt);
                                    commands.Parameters.AddWithValue("@paralistpwds", newpasswordlist);
                                    commands.Parameters.AddWithValue("@paraminage", endoflockout);
                                    commands.Parameters.AddWithValue("@paramaxage", maxage);

                                    connections.Open();
                                    int results = commands.ExecuteNonQuery();
                                    connections.Close();
                                    Response.Redirect("successpage.aspx", false);
                                }

                            }
                            else if (splittingtime.Contains(stringplainHash))
                            {
                                Label2.Text = "Please do not reuse the passwords?";
                            }
                            else{
                                DateTime thetime = DateTime.Now;
                                DateTime endoflockout = thetime.AddMinutes(5);
                                DateTime maxage = thetime.AddMinutes(15);
                                SqlConnection connections = new SqlConnection(MYDBConnectionString);
                                string sqls = "UPDATE thedetails SET Passwordhash=@parapasswordhash,Passwordsalt=@parapasswordsalt,listofpasswords=@paralistpwds,minimumpasswordage=@paraminage,maximumpasswordage=@paramaxage ";
                                SqlCommand commands = new SqlCommand(sqls, connections);
                                commands.Parameters.AddWithValue("@parapasswordhash", finalHash);
                                commands.Parameters.AddWithValue("@parapasswordsalt", salt);
                                commands.Parameters.AddWithValue("@paralistpwds", newpasswordlist);
                                commands.Parameters.AddWithValue("@paraminage", endoflockout);
                                commands.Parameters.AddWithValue("@paramaxage", maxage);

                                connections.Open();
                                int results = commands.ExecuteNonQuery();
                                connections.Close();
                                Response.Redirect("successpage.aspx", false);
                            }

                            
                        }
                        else
                        {
                            Label2.Text = "Unable to change password , you can only change at"+ retrieveminpwdage(userid);
                        }

                        




                    }
                    else
                    {
                        Label2.Text = "Password is Incorrect";
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }


        }
        protected string getDBHash(string userid)
        {
            string h = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select Passwordhash FROM thedetails WHERE EmailAddress=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);
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
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { connection.Close(); }
            return h;
        }

        protected string getDBSalt(string userid)
        {
            string s = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select Passwordsalt FROM thedetails WHERE EmailAddress=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

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
        protected string getPasswordlist(string userid)
        {
            string P = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select listofpasswords FROM thedetails WHERE EmailAddress=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["listofpasswords"] != null)
                        {
                            if (reader["listofpasswords"] != DBNull.Value)
                            {
                                P = reader["listofpasswords"].ToString();
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
            return P;
        }
        protected string retrieveminpwdage(string userid)
        {
            string G = null;
            SqlConnection connection = new SqlConnection(MYDBConnectionString);
            string sql = "select minimumpasswordage FROM thedetails WHERE EmailAddress=@USERID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@USERID", userid);


            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["minimumpasswordage"] != null)
                        {
                            if (reader["minimumpasswordage"] != DBNull.Value)
                            {
                                G = reader["minimumpasswordage"].ToString();
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