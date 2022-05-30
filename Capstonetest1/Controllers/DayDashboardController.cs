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
    public class DayDashboardController : Controller
    {
        SqlCommand com = new SqlCommand();
        // SqlDataReader dr;
        SqlConnection con = new SqlConnection();

        private readonly ILogger<DayDashboardController> _logger;
        public DayDashboardController(ILogger<DayDashboardController> logger)
        {
            _logger = logger;
            con.ConnectionString = "data source=(local)\\sqlexpress; database=Fintest1; integrated security= SSPI";
        }

        public IActionResult Index(DateTime selDate)
        {
            return View();
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
