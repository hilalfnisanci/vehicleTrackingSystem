using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trackingSystem.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace project1.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlDataAdapter vehicle_da;
        DataSet vehicle_ds = new DataSet();

        static int count = 0;

        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-BB1L05J\\SQLEXPRESS; database=vehicleTracking; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            Session["FalseCount"] = "false";

            connectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "select * from userTable where username='" + acc.Username + "' and password='" + acc.Password + "'";
            dr = com.ExecuteReader();
            
            if (dr.Read())
            {
                con.Close();
                da = new SqlDataAdapter("select * from userTable where username = '" + acc.Username.ToString() + "'", con);
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Session["UserID"] = int.Parse(row[0].ToString());
                    Session["Username"] = row[1].ToString();
                    Session["Firstname"] = row[2].ToString();
                    Session["Lastname"] = row[3].ToString();
                    Session["Mail"] = row[4].ToString();
                }

                vehicle_da = new SqlDataAdapter("select vehicleID from vehicleTable where vehicleUserID = " + Session["UserID"], con);
                vehicle_da.Fill(vehicle_ds);

                List<string> idList = new List<string>();
                foreach (DataRow row in vehicle_ds.Tables[0].Rows)
                {
                    idList.Add(row[0].ToString());
                }
                Session["CarIDs"] = idList;
                return View("~/Views/HomePage/HomePage.cshtml");
            }
            else
            {
                if(count == 3)
                {
                    Session["FalseCount"] = "true";
                    count = 0;
                }
                count++;
                con.Close();
                return View("~/Views/Login/Login.cshtml");
            }
        }
    }
}