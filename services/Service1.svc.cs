using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
namespace facebookfinal.Views.Home
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.

    public class Service1 : IService1
    {


        public void DoWork()
        {
        }
        public string Login(string X_uname, string X_passwd)
        {
            SqlConnection con = new SqlConnection("Data Source=KUTTYCHATTAN-PC\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from Userlogin";
            //  cmd.Dispose();
            //con.Close();
            SqlDataReader rdr = cmd.ExecuteReader();
            Logginuser logg = new Logginuser();
            logg.Username = X_uname;
            logg.Password = X_passwd;
            try
            {
                while (rdr.Read())
                {
                    if ((logg.Username.Equals(rdr["username"].ToString())) && (logg.Password.Equals(rdr["supPassword"].ToString())))
                    {
                        logg.Firstname = rdr["Firstname"].ToString();
                        logg.Lastname = rdr["Surname"].ToString();
                        logg.Username = rdr["Username"].ToString();
                        logg.LoginID = Convert.ToInt32(rdr["LogginId"].ToString());
                        logg.X_LoginID = logg.LoginID.ToString();
                        logg.Profilepic = rdr["Profilepic"].ToString();
                        string str = "LoginId:" + logg.LoginID + "Firstname:" + logg.Firstname + "Surname:" + logg.Lastname + "Profilpic:" + logg.Profilepic + "Responsecode:200 Message:success";
                        return str;


                    }

                    else if ((logg.Username.Equals(rdr["username"].ToString())) && (!(logg.Password.Equals(rdr["suppassword"].ToString()))))
                    {
                        logg.Firstname = rdr["Firstname"].ToString();
                        logg.Lastname = rdr["Surname"].ToString();
                        logg.Username = rdr["Username"].ToString();
                        logg.LoginID = Convert.ToInt32(rdr["LogginId"].ToString());
                        logg.X_LoginID = logg.LoginID.ToString();
                        logg.Profilepic = rdr["Profilepic"].ToString();
                        string str = "Responsecode;404 Message;Password incorrect";
                        return str;
                    }
                    else if (!(logg.Username.Equals(rdr["Username"].ToString())) && (!(logg.Password.Equals(rdr["supPassword"].ToString()))))
                    {
                        logg.Firstname = rdr["Firstname"].ToString();
                        logg.Lastname = rdr["Surname"].ToString();
                        logg.Username = rdr["Username"].ToString();
                        logg.LoginID = Convert.ToInt32(rdr["LogginId"].ToString());
                        logg.X_LoginID = logg.LoginID.ToString();
                        logg.Profilepic = rdr["Profilepic"].ToString();
                        string str = "Username:" + logg.Username + "Responsecode;500 Message;Email id doesnot exist";
                        return str;
                    }
                }
            }
            catch (Exception ec)
            {
                errorlogin.SendError(ec);
            }

            return null;

        }

        public string Signupmethod(string X_Firstname, string X_Surname, string X_Email, string X_propic,string X_supPassword, DateTime DT_SUPdob, string x_Gender)
        {
            FileUpload FL1 = new FileUpload();
            String myprofpic = "D:\\profpic\\" + X_propic;
            FL1.SaveAs(myprofpic);
            
            SqlConnection con = new SqlConnection("Data Source=KUTTYCHATTAN-PC\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            string str;
            con.Open();
            signup sign = new signup();
            sign.Firstname = X_Firstname;
            sign.Lastname = X_Surname;
            sign.Email = X_Email;
            sign.Profilepic =myprofpic;
            sign.supPassword = X_supPassword;
            sign.DT_dob = DT_SUPdob;
            sign.Gender = x_Gender;
            str = "insert into Userlogin(Firstname,Surname,Profilepic,Email,supPassword,DT_dob,Gender) values('" + sign.Firstname + "', '" + sign.Lastname + "','"+sign.Profilepic+"','" + sign.Email + "', '" + sign.supPassword + "' ,'" + sign.DT_dob + "', '" + sign.Gender + "')";
            SqlCommand snd = new SqlCommand(str, con);
            int res = snd.ExecuteNonQuery();
            if (res > 0)
            {


                sendmail();



                return ("success");
            }
            else
            {
                return ("fail");
            }
            con.Close();
            snd.Dispose();
            return null;
        }

        public void sendmail()
        {



            //string mail = Frommail.Text;
            // string fun = Tomail.Text;
            //string sub = Subjectmail.Text;
            // string bdy = documail.Text;


            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("snehasne517@gmail.com");
            msg.To.Add("snehasne517@gmail.com");
            //msg.Subject = sub;
            // msg.Body = bdy;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("snehasne517@gmail.com", "snehaanil");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
            }




            catch (Exception ex)
            {

            }
        }


    }


    }



