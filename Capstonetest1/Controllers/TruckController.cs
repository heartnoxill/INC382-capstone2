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
    public class TruckController : Controller
    {
        SqlCommand com = new SqlCommand();
        // SqlDataReader dr;
        SqlConnection con = new SqlConnection();

        private readonly ILogger<TruckController> _logger;
        public TruckController(ILogger<TruckController> logger)
        {
            _logger = logger;
            con.ConnectionString = "data source=MB-COMPUTER; database=CapsDatabase; integrated security= SSPI";
        }


        public IActionResult index(string? truck_search)
        {
            Console.WriteLine(truck_search);
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[SearchTruck] WHERE po_no ='"+truck_search+"'";
            Console.WriteLine(com.CommandText);
            // com.CommandText = " SELECT * FROM [Fintest1].[dbo].[Transac] WHERE date = CONVERT(DATETIME, '04/04/2022 00:00:00' , 111)";
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Truck> trucks = new List<Truck>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                trucks.Add(new Truck() {po_no = Convert.ToSingle(dr["po_no"])
                ,truck_id = Convert.ToString(dr["truck_id"])
                ,Station_name = Convert.ToString(dr["Station_name"])
                ,Date_in=Convert.ToDateTime(dr["Date_in"])
                ,Time_in=Convert.ToString(dr["Time_in"])
                ,Service_time=Convert.ToSingle(dr["Service_time"])
                ,Date_out=Convert.ToDateTime(dr["Date_out"])
                ,Time_out=Convert.ToString(dr["Time_out"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(trucks);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

