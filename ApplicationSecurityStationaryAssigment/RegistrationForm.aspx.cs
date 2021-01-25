using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationSecurityStationaryAssigment
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        byte[] Key;
        byte[] IV;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            tbbirthdate.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private int checkPassword(string password)
        {
            int score = 0;
            if (password.Length < 8)
            {
                lbfeedback.Text = "Password Length Must be at least 8 Characters";
                lbfeedback.ForeColor = Color.Red;
                return 1;
            }
            else
            {
                score = 1;
            }
            if (Regex.IsMatch(password, "[0-9]"))
            {
                score++;
            }
            else
            {
                lbfeedback.Text = "Password require at least 1 number ";
                lbfeedback.ForeColor = Color.Red;
                return score;
            }
            if (Regex.IsMatch(password, "[a-z]"))
            {
                score++;
            }
            else
            {
                lbfeedback.Text = "Password require at least 1 LowerCase ";
                lbfeedback.ForeColor = Color.Red;
                return score;

            }
            if (Regex.IsMatch(password, "[A-Z]"))
            {
                score++;
            }
            else
            {
                lbfeedback.Text = "Password require at least 1 UpperCase ";
                lbfeedback.ForeColor = Color.Red;
                return score;
            }
            
            if (Regex.IsMatch(password, "[^a-zA-Z0-9]"))
            {
                score++;
            }
            else
            {
                lbfeedback.Text = "Password require at least 1 Special Character ";
                lbfeedback.ForeColor = Color.Red;
                return score;
            }
            return score;
        }
        private bool ValidateInput()
        {
            bool result = true;
            Label3.Text = String.Empty;
            if (tbfirstname.Text == "")
            {
                Label3.Text = Label3.Text + "First name is required"+"<br/>";
                Label3.ForeColor = Color.Red;
               

            }
            if (String.IsNullOrEmpty(tblastname.Text))
            {
                Label3.Text = Label3.Text + "Last name is required" + "<br/>";
                Label3.ForeColor = Color.Red;
                
            }
            if (String.IsNullOrEmpty(tbemail.Text))
            {
                Label3.Text = Label3.Text + "Email Address is required" + "<br/>";
                Label3.ForeColor = Color.Red;
            }
            if (String.IsNullOrEmpty(tbbirthdate.Text))
            {
                Label3.Text = Label3.Text + "Birth date is required" + "<br/>"; ;
                Label3.ForeColor = Color.Red;
                
            }
            if (String.IsNullOrEmpty(tbcreditcardno.Text))
            {
                Label3.Text = Label3.Text + "Credit Card number is required" + "<br/>";
                Label3.ForeColor = Color.Red;
                
            }
            else
            {
                if(Regex.IsMatch(tbcreditcardno.Text, "[4][0-9]{3}[ ][0-9]{4}[ ][0-9]{4}[ ][0-9]{1}|[4][0-9]{3}[ ][0-9]{4}[ ][0-9]{4}[ ][0-9]{4}|[5][0-9]{3}[ ][0-9]{4}[ ][0-9]{4}[ ][0-9]{4}|[3][47\t]{1}[0-9]{2}[ ][0-9]{4}[ ][0-9]{4}[ ][0-9]{3}|[6][0-9]{3}[ ][0-9]{4}[ ][0-9]{4}[ ][0-9]{4}"))
                {
                    
                }
                else
                {
                    Label3.Text = Label3.Text+ "Please Enter Valid Credit Card Number" + "<br/>"; ;
                   
                }
            }
            if (String.IsNullOrEmpty(tbcvv.Text))
            {
                Label3.Text = Label3.Text + "CVV is required" + "<br/>"; ;
                Label3.ForeColor = Color.Red;
                
            }
            else
            {
                if (Regex.IsMatch(tbcvv.Text, "[0-9]{3,4}"))
                {

                }
                else
                {
                    Label3.Text = Label3.Text + "Please Enter Valid CVV" + "<br/>"; ;
                    
                }
            }
            if (String.IsNullOrEmpty(tbmonth.Text))
            {
                Label3.Text = Label3.Text + "Expiry date for month is required" + "<br/>"; ;
                Label3.ForeColor = Color.Red;
                
            }
            else
            {
                if (Regex.IsMatch(tbmonth.Text, "[1-9]{1}|[1][012\t]"))
                {

                }
                else
                {
                    Label3.Text = Label3.Text+ "Please Enter Valid Month Expiry Date" + "<br/>"; ;
                    
                }
            }
            if (String.IsNullOrEmpty(tbyear.Text))
            {
                Label3.Text = Label3.Text + "Expiry date for year is required" + "<br/>"; ;
                Label3.ForeColor = Color.Red;
                
            }
            else
            {
                if (Regex.IsMatch(tbyear.Text, "[2][0][2][1-9]")) 
                {

                }
                else
                {
                    Label3.Text = Label3.Text+ "Please Enter Valid Year Expiry Date" + "<br/>"; ;
                    
                }
            }
            if (String.IsNullOrEmpty(tbemail.Text))
            {
                Label3.Text = Label3.Text + "Email Field is required" + "<br/>"; ;
                Label3.ForeColor = Color.Red;
            }
            else
            {
                if (Regex.IsMatch(tbemail.Text, @"^\w+[\+\.\w-]*@([\w-]+\.)*\w+[\w-]*\.([a-z]{2,4}|\d+)$"))
                {

                }
                else
                {
                    Label3.Text = Label3.Text + "Please Enter Valid Email"  + "<br/>";;

                }
            }
            if (String.IsNullOrEmpty(tbnameoncard.Text))
            {
                Label3.Text = Label3.Text + "Name on credit card is required" + "<br/>"; ;
                Label3.ForeColor = Color.Red;
            }
            
            

            if (String.IsNullOrEmpty(Label3.Text))
            {
                if (Convert.ToInt32(DateTime.Now.Month.ToString()) > Convert.ToInt32(tbmonth.Text.ToString()) && Convert.ToInt32(DateTime.Now.Year.ToString())>= Convert.ToInt32(tbyear.Text.ToString()))
                {
                    Label3.Text = Label3.Text + "Please Do not enter expire credit card";
                    Label3.ForeColor = Color.Red;
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return false;
            }
            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ValidateCaptcha())
            {
                List<String> tdlist = new List<String>();
                bool validInput = ValidateInput();
                int scores = checkPassword(tbpassword.Text);
                if (scores == 5 && validInput == true)
                {

                    string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;

                    SqlConnection myConn = new SqlConnection(MYDBConnectionString);
                    string sqlstmt = "SELECT EmailAddress From thedetails";
                    SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int rec_cnt = ds.Tables[0].Rows.Count;
                    if (rec_cnt > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string email = row["EmailAddress"].ToString();
                            tdlist.Add(email);
                        }
                    }

                    if (tdlist.Contains(tbemail.Text))
                    {
                        Label3.Text = "Email Address already registered";
                    }
                    else
                    {

                        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                        byte[] saltByte = new byte[8];

                        rng.GetBytes(saltByte);
                        var salt = Convert.ToBase64String(saltByte);

                        SHA512Managed hashing = new SHA512Managed();
                        string pwdwithsalt = tbpassword.Text + salt;
                        byte[] hashwithsalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdwithsalt));
                        var finalhash = Convert.ToBase64String(hashwithsalt);

                        RijndaelManaged cipher = new RijndaelManaged();
                        cipher.GenerateKey();
                        Key = cipher.Key;
                        IV = cipher.IV;

                        try
                        {

                            using (SqlConnection con = new SqlConnection(MYDBConnectionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("INSERT INTO thedetails VALUES(@FirstName,@LastName,@Passwordhash,@Passwordsalt,@Dateofbirth,@IV,@Key,@Cardnumber,@EmailAddress,@Nameoncard,@CVV,@Monthexpiry,@yearexpiry) "))
                                {
                                    using (SqlDataAdapter sda = new SqlDataAdapter())
                                    {
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue("@FirstName", tbfirstname.Text);
                                        cmd.Parameters.AddWithValue("@LastName", tblastname.Text);
                                        cmd.Parameters.AddWithValue("@Passwordhash", finalhash);
                                        cmd.Parameters.AddWithValue("@Passwordsalt", salt);
                                        cmd.Parameters.AddWithValue("@Dateofbirth", tbbirthdate.Text);
                                        cmd.Parameters.AddWithValue("@IV", Convert.ToBase64String(IV));
                                        cmd.Parameters.AddWithValue("@Key", Convert.ToBase64String(Key));
                                        cmd.Parameters.AddWithValue("@Cardnumber", Convert.ToBase64String(encryptData(tbcreditcardno.Text)));

                                        cmd.Parameters.AddWithValue("@EmailAddress", tbemail.Text);
                                        cmd.Parameters.AddWithValue("@Nameoncard", Convert.ToBase64String(encryptData(tbnameoncard.Text)));
                                        cmd.Parameters.AddWithValue("@CVV", Convert.ToBase64String(encryptData(tbcvv.Text)));
                                        cmd.Parameters.AddWithValue("@Monthexpiry", Convert.ToBase64String(encryptData(tbmonth.Text)));
                                        cmd.Parameters.AddWithValue("@yearexpiry", Convert.ToBase64String(encryptData(tbyear.Text)));
                                        cmd.Connection = con;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        Response.Redirect("Loginpage.aspx", false);


                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Something went wrong, Please try again later");
                        }
                    }


                }
                else
                {

                }
            }
        }
        protected byte[] encryptData(string data)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                cipher.Key = Key;
                ICryptoTransform encryptTransform = cipher.CreateEncryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);



            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {

            }
            return cipherText;
        }
    }
}