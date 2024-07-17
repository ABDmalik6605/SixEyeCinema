using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace SixEyeCinema1._3.Controllers
{
    [Bind]
    public class HomeController : Controller
    {
        // [Bind]
        public string Uname { get; set; }
        public static string server { get; set; } = "Server=192.168.100.6;";
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        //  public char phone[11] { get; set; }
        public DateTime dob { get; set; }
        public string tId { get; set; }
        public string scid { get; set; }
        public string tick { get; set; }

        public string Mname { get; set; }

        public class CombinedViewModel
        {
            public DataTable DataFromFirstProcedure { get; set; }
            public DataTable DataFromSecondProcedure { get; set; }
        }

        public ActionResult Logout()
        {

            Session["name"] = null;
            Session["email"] = null;
            Session["age"] = null;
            Session["username"] = null;
            Session["pass"] = null;

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            string firstProcedure = "showshow";
            DataTable firstTable = new DataTable();

            string secondProcedure = "comingshow";
            DataTable secondTable = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                SqlCommand com1 = new SqlCommand(firstProcedure, sqlcon);
                com1.CommandType = CommandType.StoredProcedure;
                sqlcon.Open();
                SqlDataReader dr1 = com1.ExecuteReader();
                firstTable.Load(dr1);

                SqlCommand com2 = new SqlCommand(secondProcedure, sqlcon);
                com2.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr2 = com2.ExecuteReader();
                secondTable.Load(dr2);
            }
            var combinedData = new CombinedViewModel
            {
                DataFromFirstProcedure = firstTable,
                DataFromSecondProcedure = secondTable
            };
            //ViewData["DataFromFirstProcedure"] = firstTable;
            //ViewData["DataFromSecondProcedure"] = secondTable;

            return View(combinedData);
        }

        public ActionResult movies()
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "movieshow";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }
        [HttpPost]
        public ActionResult movies(string gen)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "searchmovies";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@gen", gen);
            com.ExecuteNonQuery();
            //com = new SqlCommand("seriesshow", sqlcon);
            //com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult series()
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "seriesshow";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return View(dt);
        }
        [HttpPost]
        public ActionResult series(string gen)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "searchseries";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@gen", gen);
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult anime()
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "animeshow";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return View(dt);
        }
        [HttpPost]
        public ActionResult anime(string gen)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "searchanimes";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@gen", gen);
            com.ExecuteNonQuery();
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult InterBook(string data)
        //{

        //    String constring = "Server=192.168.43.134;Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
        //    //@UId int, @mid int, @scd char(5),@sid char(5),@amt int
        //    SqlConnection sqlcon = new SqlConnection(constring);
        //    sqlcon.Open();
        //    SqlCommand com = new SqlCommand("getInfo", sqlcon);

        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@mname",  );
        //    SqlDataReader dr = com.ExecuteReader();
        //    dt = new DataTable();
        //    dt.Load(dr);


        //    return View();
        //}


        public void split(string main, ref string s1, ref string s2, ref string s3)
        {
            int ind = 0;
            for (int i = 0; main[i] != ' '; i++)
            {
                if (main[i] == '/')
                    s1 += '-';
                else
                    s1 += main[i];
                ind = i;
            }
            ++ind;
            for (int i = ++ind; main[i] != ';'; i++)
                ind = i;
            ++ind;
            for (int i = ++ind; main[i] != ':'; i++)
            {
                s2 += main[i];
                ind = i;
            }
            ind++;
            for (int i = ++ind; i < main.Length; i++)
            {
                s3 += main[i];
            }
        }
        public ActionResult booking(string data)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            //@UId int, @mid int, @scd char(5),@sid char(5),@amt int
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand com = new SqlCommand("getInfo", sqlcon);

            com.CommandType = CommandType.StoredProcedure;
            if (data != null)
                com.Parameters.AddWithValue("@mname", data);
            else
                com.Parameters.AddWithValue("@mname", "");

            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
             com = new SqlCommand("getReview", sqlcon);

            com.CommandType = CommandType.StoredProcedure;
            if (data != null)
                com.Parameters.AddWithValue("@mname", data);
            else
                com.Parameters.AddWithValue("@mname", "");

           dr = com.ExecuteReader();
           DataTable dt2 = new DataTable();
            dt2.Load(dr);
            if (data != null)
            {
                if (!data.Contains(":"))
                {
                    Session["Mname"] = data;
                    ViewData["Screen"] = "1";
                }
                else
                {
                    string date = "", screen = "", time = "";
                    split(data, ref date, ref screen, ref time);
                    Session["Mdate"] = date;
                    Session["Screen"] = screen;
                    Session["time"] = time;
                }
            }
            ViewData["Uname"] = "%";
            ViewData["Email"] = "%";

            ViewData["Tickets"] = "%";

            var combinedData = new CombinedViewModel
            {
                DataFromFirstProcedure = dt,
                DataFromSecondProcedure = dt2
            };

            return View(combinedData);
        }

        [HttpPost]
        public ActionResult booking(string movie, string user, string email, string date, string Screen, string tim, string amt)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            //@UId int, @mid int, @scd char(5),@sid char(5),@amt int
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "Book";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@mid", movie);
            com.Parameters.AddWithValue("@scd", Screen);
            com.Parameters.AddWithValue("@sid", tim);
            com.Parameters.AddWithValue("@amt", Convert.ToInt16(amt));
            com.Parameters.AddWithValue("@date", date);
            com.ExecuteNonQuery();
            com = new SqlCommand("getBook", sqlcon);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@scr", Screen);
            com.Parameters.AddWithValue("@tim", tim);
            com.Parameters.AddWithValue("@user", email);
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);

            string fromAddress = "SixEyecinema@gmail.com";
            string password2 = "buvnan-xyghog-jeFxa8";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential(fromAddress, password2);
            smtp.Credentials = nc;
            MailMessage msg = new MailMessage();
            msg.Subject = "Hello " + user + ", Thanks for Booking at Six Eye Cinema";
            msg.Body = "Your Booking Details : \n";
            msg.Body += "Movie Name : " + movie + "\nScreen Id : " + Screen + "\nTime Slot : " + tim + "\nNo. Of Tickets : " + amt + "\nDate : " + date + "\n";
            msg.Body += " MAke Sure you are on time for the movie , for any queries kindly visit our website . Thank You :)";
            msg.To.Add(new MailAddress(email));
            msg.From = new MailAddress(fromAddress, "Six Eye Cinema");
            try
            {
                smtp.Send(msg);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
            }
            //ViewData["Date"] = date.ToString("yyyy-MM-dd");
            return View(dt);
        }


        ///// <summary>
        ///// ///////////////////////////////////////
        ///// </summary>
        ///// <param name="mname"></param>
        ///// <returns></returns>
        public DataTable dateGet(string mname)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            String pname = "getDates";
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mid", mname);
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            return dt;

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Register(string name, string dateOfBirth, string email, string password, string Phone)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "signup";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@DOB", dateOfBirth);
            com.Parameters.AddWithValue("@mail", email);
            com.Parameters.AddWithValue("@pass", password);
            com.Parameters.AddWithValue("@phone", Phone);

            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@outputMessage";
            outputParameter.SqlDbType = SqlDbType.NVarChar;
            outputParameter.Size = 100;
            outputParameter.Direction = ParameterDirection.Output;
            com.Parameters.Add(outputParameter);

            SqlParameter outputParameter2 = new SqlParameter();
            outputParameter2.ParameterName = "@ID";
            outputParameter2.SqlDbType = SqlDbType.Int;
            outputParameter2.Direction = ParameterDirection.Output;
            com.Parameters.Add(outputParameter2);
            com.ExecuteNonQuery();

            string messageFromStoredProcedure = outputParameter.Value.ToString();
            string messageFromStoredProcedure2 = outputParameter2.Value.ToString();
            sqlcon.Close();
            string fromAddress = "SixEyecinema@gmail.com.com";
            string password2 = "buvnan-xyghog-jeFxa8";
            if (messageFromStoredProcedure == "Congratulations you are a member now")
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential(fromAddress, password2);
                smtp.Credentials = nc;
                MailMessage msg = new MailMessage();
                msg.Subject = "Hello " + name + ", Thanks for Registering at Six Eye Cinema";
                msg.Body = "Hi " + name + ", Thanks For becoming a member of our community.Here is your ID number " + messageFromStoredProcedure2 + ".Use this to sign-in. We will Provide You With the Latest movies,series and animes Thanks";
                msg.To.Add(new MailAddress(email));
                msg.From = new MailAddress(fromAddress, "Six Eye Cinema");
                try
                {
                    smtp.Send(msg);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to send email: " + ex.Message);
                    Console.WriteLine("Stack trace: " + ex.StackTrace);
                }
            }

            ViewBag.result = messageFromStoredProcedure;
            return View();
        }
        public ActionResult sign_in()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sign_in(string name, string email, int age, string username, string password)
        {

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "matchSign";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@pass", password);
            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@outputMessage"; // Assuming your stored procedure returns a message in an output parameter named @outputMessage
            outputParameter.SqlDbType = SqlDbType.NVarChar;
            outputParameter.Size = 100; // Adjust the size as per your requirement
            outputParameter.Direction = ParameterDirection.Output;
            com.Parameters.Add(outputParameter);

            com.ExecuteNonQuery();
            ViewData["msg"] = null;
            string message = outputParameter.Value.ToString();
            if (message == "1")
            {


                Session["name"] = name;
                Session["email"] = email;
                Session["age"] = age;
                Session["username"] = username;
                Session["pass"] = password;
            }
            else if (message == "0")
            {
                ViewData["msg"] = "Your are not a member";
            }
            else
            {
                ViewData["msg"] = "Invalid Password";
            }
            return View();
        }

        DataTable dt { get; set; }
        public ActionResult Admin()
        {
            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getShow";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            //if (TempData.TryGetValue("dt", out object value))
            //{
            //    dt=(DataTable)value;
            //}
            //else
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }

        [HttpPost]
        public ActionResult Admin(string Mid, string Mid2, string Screen2, string date2, string slot2, string Screen, string date, string slot)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            if (Mid == null && (Mid2 == null || Screen2 == null || date2 == null || slot2 == null))
            {
                String pname = "delshow";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@scd", Screen);
                com.Parameters.AddWithValue("@Mdate", date);
                com.Parameters.AddWithValue("@tmid", slot);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getShow", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else if (Mid2 == null || Screen2 == null || date2 == null || slot2 == null)
            {
                String pname = "setShow";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Mid", Mid);
                com.Parameters.AddWithValue("@scd", Screen);
                com.Parameters.AddWithValue("@dt", date);
                com.Parameters.AddWithValue("@timeid", slot);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getShow", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            //  ViewBag.result = "Record Has Been Saved Successfully";
            // TempData["dt"] = TempData["dt"];

            else
            {
                String pname = "editshow";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@scd", Screen);
                com.Parameters.AddWithValue("@Mdate", date);
                com.Parameters.AddWithValue("@timeid", slot);
                com.Parameters.AddWithValue("@Mid2", Mid2);
                com.Parameters.AddWithValue("@scd2", Screen2);
                com.Parameters.AddWithValue("@Mdate2", date2);
                com.Parameters.AddWithValue("@timeid2", slot2);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getShow", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            sqlcon.Close();
            return RedirectToAction("Admin","Home");
        }

        public ActionResult AdminDel()
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";

            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getShow";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();

            dt = new DataTable();

            //if (TempData.TryGetValue("dt", out object value))
            //{
            //    dt=(DataTable)value;
            //}
            //else
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult AdminDel(string Screen, string date, string slot)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "setShow";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@scd", Screen);
            com.Parameters.AddWithValue("@dt", date);
            com.Parameters.AddWithValue("@timeid", slot);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.result = "Incorrect Data Entered";
            }

            ViewBag.result = "Record Has Been Saved Successfully";
            TempData["dt"] = TempData["dt"];
            com = new SqlCommand("getShow", sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }



        public ActionResult Account(string data)
        {

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getHistory";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", (string)Session["email"]);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (data == "1")
            {
                ViewData["flag"] = "1";
            }
            else
                ViewData["flag"] = "=";
            return View(dt);

        }

        [HttpPost]

        public ActionResult Account(string user, string email, string phone)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "updateInfo";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@user", (string)Session["email"]);
            Session["email"] = email;
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@ph", phone);
            com.ExecuteNonQuery();
            pname = "getHistory";
            com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", (string)Session["email"]);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            //sqlcon.close();
            dt.Load(dr);
            return View(dt);
        }

        public ActionResult Rating(string data)
        {
            Session["movie"] = data;


            return View();
        }

        [HttpPost]

        public ActionResult Rating(string rating, string comment)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "AddRating";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mname", (string)Session["movie"]);
            com.Parameters.AddWithValue("@rating", Convert.ToInt16(rating));
            com.Parameters.AddWithValue("@comment", comment);
            com.Parameters.AddWithValue("@email", (string)Session["email"]);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.result = "You have already reviewed this movie";
            }
            return View();
        }

        public ActionResult AdminLogin()
        {

            return View();
        }

        [HttpPost]

        public ActionResult AdminLogin(string name, string email, string username, string password)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "matchAdmin";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@pass", password);
            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@outputMessage"; // Assuming your stored procedure returns a message in an output parameter named @outputMessage
            outputParameter.SqlDbType = SqlDbType.NVarChar;
            outputParameter.Size = 100; // Adjust the size as per your requirement
            outputParameter.Direction = ParameterDirection.Output;
            com.Parameters.Add(outputParameter);

            com.ExecuteNonQuery();
            ViewData["msg"] = null;
            string message = outputParameter.Value.ToString();
            if (message == "1")
            {


                Session["Aname"] = name;
                Session["Aemail"] = email;
                Session["Ausername"] = username;
                Session["Apass"] = password;

              

            }
            else if (message == "0")
            {
                ViewData["msg"] = "Your are not a member";
            }
            else
            {
                ViewData["msg"] = "Invalid Password";
            }
            return View();
        }


        public ActionResult Adminusers()
        {
            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getusers";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Adminusers(string UID1)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "deluser";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@uid1", Convert.ToInt16(UID1));
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.result = "Incorrect Data Entered";
            }
            com = new SqlCommand("getusers", sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }


        public ActionResult Adminmovies()
        {

            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getmovies";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Adminmovies(string Mid1, string Mid, string mname, string gen, string age, string pic)
        {



            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            if (Mid1 == null && (mname == null || gen == null || age == null || pic == null))
            {
                String pname = "delmovie";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@mid1", Convert.ToInt16(Mid));
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getmovies", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else if (Mid1 == null)
            {
                String pname = "setmovie";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Mid", Convert.ToInt16(Mid));
                com.Parameters.AddWithValue("@mname", mname);
                com.Parameters.AddWithValue("@gen", gen);
                com.Parameters.AddWithValue("@agr", age);
                com.Parameters.AddWithValue("@pic", pic);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getmovies", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else
            {
                String pname = "editmovie";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Mid1", Convert.ToInt16(Mid1));
                com.Parameters.AddWithValue("@Mid", Convert.ToInt16(Mid));
                com.Parameters.AddWithValue("@mname", mname);
                com.Parameters.AddWithValue("@gen", gen);
                com.Parameters.AddWithValue("@agr", age);
                com.Parameters.AddWithValue("@pic", pic);
                ViewBag.result = "Data has been Entered";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getmovies", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult Admincoming()
        {

            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getcoming";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Admincoming(string Cid1, string Cid, string mname, string gen, string age, string pic)
        {


            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);

            ViewBag.result = "Data has been enetered";
            if (Cid1 == null && (mname == null || gen == null || age == null || pic == null))
            {
                String pname = "delcoming";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@cid1", Convert.ToInt16(Cid));
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getcoming", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else if (Cid1 == null)
            {
                String pname = "setcoming";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Cid", Convert.ToInt16(Cid));
                com.Parameters.AddWithValue("@mname", mname);
                com.Parameters.AddWithValue("@gen", gen);
                com.Parameters.AddWithValue("@agr", age);
                com.Parameters.AddWithValue("@pic", pic);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getcoming", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else
            {
                String pname = "editcoming";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Cid1", Convert.ToInt16(Cid1));
                com.Parameters.AddWithValue("@Cid", Convert.ToInt16(Cid));
                com.Parameters.AddWithValue("@mname", mname);
                com.Parameters.AddWithValue("@gen", gen);
                com.Parameters.AddWithValue("@agr", age);
                com.Parameters.AddWithValue("@pic", pic);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getcoming", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult Adminscreen()
        {
            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getscreen";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Adminscreen(string sid1, string sid, string tseats, string price)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            if (sid1 == null && (tseats == null || price == null))
            {
                String pname = "delscreen";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                ViewBag.result = "Data has been Deleted";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sid1", sid);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getscreen", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else if (sid1 == null)
            {
                String pname = "setscreen";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                ViewBag.result = "Data has been Inserted";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sid", (sid));
                com.Parameters.AddWithValue("@tseats", Convert.ToInt16(tseats));
                com.Parameters.AddWithValue("@price", Convert.ToInt16(price));
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getscreen", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else
            {
                String pname = "editscreen";
                sqlcon.Open();
                ViewBag.result = "Data has been edited";
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sid1", sid1);
                com.Parameters.AddWithValue("@sid", (sid));
                com.Parameters.AddWithValue("@tseats", Convert.ToInt16(tseats));
                com.Parameters.AddWithValue("@price", Convert.ToInt16(price));
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getscreen", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult Adminbooking()
        {
            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getbooking";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Adminadd(string aid1, string aid, string add, string price)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            if (aid1 == null && (add == null || price == null))
            {
                String pname = "deladd"; ViewBag.result = "Data has been Deleted";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@aid1", aid);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getadd", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else if (aid1 == null)
            {
                String pname = "setadd";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@aid", (aid));
                com.Parameters.AddWithValue("@add", add);
                com.Parameters.AddWithValue("@price", Convert.ToInt16(price));
                ViewBag.result = "Data has been Entered";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getadd", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else
            {
                String pname = "editadd";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@aid1", aid1);
                com.Parameters.AddWithValue("@aid", (aid));
                com.Parameters.AddWithValue("@add", add);
                com.Parameters.AddWithValue("@price", Convert.ToInt16(price));
                ViewBag.result = "Data has been Edited";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("getadd", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            sqlcon.Close();
            return View(dt);
        }
        public ActionResult Adminadd()
        {

            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }

            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "getadd";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }




        public ActionResult Admintiming()
        {
            if ((string)Session["Aname"] == null)
            {
                return RedirectToAction("AdminLogin", "Home");
            }
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "gettiming";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            TempData["dt"] = dt;
            return View(dt);
        }
        [HttpPost]
        public ActionResult Admintiming(string tid1, string tid, string time)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            if (tid1 == null && time == null)
            {
                String pname = "deltiming";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@tid1", tid);
                ViewBag.result = "Data has been Deleted";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("gettiming", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else if (tid1 == null)
            {
                String pname = "settiming";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@tid", (tid));
                com.Parameters.AddWithValue("@time", time);
                ViewBag.result = "Data has been Entered";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("gettiming", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            else
            {
                String pname = "edittiming";
                sqlcon.Open();
                SqlCommand com = new SqlCommand(pname, sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@tid1", tid1);
                com.Parameters.AddWithValue("@tid", (tid));
                com.Parameters.AddWithValue("@time", time);
                ViewBag.result = "Data has been Edited";
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ViewBag.result = "Incorrect Data Entered";
                }
                com = new SqlCommand("gettiming", sqlcon);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
            }
            sqlcon.Close();
            return View(dt);
        }

        public ActionResult LogoutAdmin()
        {
            Session["Aname"] = null;
            Session["Aemail"] = null;
            Session["Ausername"] = null;
            Session["Apass"] = null;

            return RedirectToAction("AdminLogin", "Home");
        }


        [HttpPost]
        public ActionResult Adminbooking(string SN)
        {
            String constring = server + "Database=Six_Eye_Cinema;User ID=sa;Password=VeryStr0ngP@ssw0rd;Integrated Security=False;Trusted_Connection=False";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "delbooking";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SN", Convert.ToInt16(SN));
            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@outputMessage"; // Assuming your stored procedure returns a message in an output parameter named @outputMessage
            outputParameter.SqlDbType = SqlDbType.NVarChar;
            outputParameter.Size = 100; // Adjust the size as per your requirement
            outputParameter.Direction = ParameterDirection.Output;
            com.Parameters.Add(outputParameter);

            com.ExecuteNonQuery();

            string messageFromStoredProcedure = outputParameter.Value.ToString();
            ViewBag.result = messageFromStoredProcedure;

            com.ExecuteNonQuery();
            com = new SqlCommand("getbooking", sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            sqlcon.Close();
            return View(dt);
        }
    }
}