using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Capstonetest1.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Capstonetest1.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "data source=MB-COMPUTER; database=CapsDatabase; integrated security= SSPI";
        }
        [HttpPost]
        public IActionResult Verify(UserProfile model)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[UserProfile] WHERE username='"+model.username+"' AND password='"+model.password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("~/Views/DayDashboard/index.cshtml");
            }
            else
            {
                con.Close();
                return View("error");
            }
        }
    }
}