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
    public class FinanceController : Controller
    {
        SqlCommand com = new SqlCommand();
        // SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        private readonly ILogger<FinanceController> _logger;
        public FinanceController(ILogger<FinanceController> logger)
        {
            _logger = logger;
            con.ConnectionString = "data source=MB-COMPUTER; database=CapsDatabase; integrated security= SSPI";
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Journal(DateTime? sel_date)
        {
            Console.WriteLine(sel_date);
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[Journal] WHERE date = CONVERT(DATETIME,'"+sel_date+"', 101)";
            Console.WriteLine(com.CommandText);
            // com.CommandText = " SELECT * FROM [Fintest1].[dbo].[Transac] WHERE date = CONVERT(DATETIME, '04/04/2022 00:00:00' , 111)";
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Journal> journals = new List<Journal>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                journals.Add(new Journal() {ref_no = Convert.ToSingle(dr["ref_no"])
                ,date = Convert.ToDateTime(dr["date"])
                ,Action = Convert.ToString(dr["Action"])
                ,Type=Convert.ToString(dr["Type"])
                ,Debit=Convert.ToSingle(dr["Debit"])
                ,Credit=Convert.ToSingle(dr["Credit"])
                ,Truck_id=Convert.ToString(dr["Truck_id"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(journals);
        }

        public IActionResult Inventory(){
            return View();
        }

        public IActionResult Invoice(string? invoice_search)
        {
            Console.WriteLine(invoice_search);
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[Invoice] WHERE Invoice_no = '"+invoice_search+"'";
            Console.WriteLine(com.CommandText);
            // com.CommandText = " SELECT * FROM [Fintest1].[dbo].[Transac] WHERE date = CONVERT(DATETIME, '04/04/2022 00:00:00' , 111)";
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Invoice> invoices = new List<Invoice>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                invoices.Add(new Invoice() {po_number = Convert.ToSingle(dr["po_number"])
                ,Payment_NO = Convert.ToString(dr["Payment_NO"])
                ,invoice_date = Convert.ToString(dr["invoice_date"])
                ,customer_id=Convert.ToSingle(dr["customer_id"])
                ,customer_name=Convert.ToString(dr["customer_name"])
                ,taxpayer_id=Convert.ToString(dr["taxpayer_id"])
                ,Invoice_no=Convert.ToString(dr["Invoice_no"])
                ,customer_address=Convert.ToString(dr["customer_address"])
                ,pretrol_type=Convert.ToString(dr["pretrol_type"])
                ,Price_Litres=Convert.ToSingle(dr["Price_Litres"])
                ,Litres=Convert.ToSingle(dr["Litres"])
                ,Price=Convert.ToSingle(dr["Price"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(invoices);
        }

        public IActionResult Ledger(){
            return View();
        }

        public IActionResult PurchaseOrder(string? purchase_search)
        {
            Console.WriteLine(purchase_search);
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[PurchaseOrder] WHERE po_number = '"+purchase_search+"'";
            Console.WriteLine(com.CommandText);
            // com.CommandText = " SELECT * FROM [Fintest1].[dbo].[Transac] WHERE date = CONVERT(DATETIME, '04/04/2022 00:00:00' , 111)";
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<PurchaseOrder> purchaseorders = new List<PurchaseOrder>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                purchaseorders.Add(new PurchaseOrder() {po_number = Convert.ToString(dr["po_number"])
                ,Payment_NO = Convert.ToString(dr["Payment_NO"])
                ,date = Convert.ToString(dr["date"])
                ,customer_id=Convert.ToSingle(dr["customer_id"])
                ,customer_name=Convert.ToString(dr["customer_name"])
                ,taxpayer_id=Convert.ToString(dr["taxpayer_id"])
                ,pretrol_type=Convert.ToString(dr["pretrol_type"])
                ,Price_Litres=Convert.ToSingle(dr["Price_Litres"])
                ,Litres=Convert.ToSingle(dr["Litres"])
                ,Price=Convert.ToSingle(dr["Price"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(purchaseorders);
        }

        public IActionResult Recon()
        {
            string v = "SELECT * FROM [CapsDatabase].[dbo].[ReconciliationSheet]";
            com.CommandText = v;
            Console.WriteLine(com.CommandText);
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<Recon> recons = new List<Recon>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                recons.Add(new Recon() {recon_date = Convert.ToDateTime(dr["recon_date"])
                ,po_number = Convert.ToSingle(dr["po_number"])
                ,Payment_NO = Convert.ToString(dr["Payment_NO"])
                ,Invoice_no = Convert.ToString(dr["Invoice_no"])
                ,truck_no = Convert.ToString(dr["truck_no"])
                ,type = Convert.ToString(dr["type"])
                ,litres = Convert.ToSingle(dr["litres"])
                ,Price = Convert.ToSingle(dr["Price"])
                ,customer_name = Convert.ToString(dr["customer_name"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(recons);
        }

        public IActionResult Statement(){
            return View();
        }

        public IActionResult AccountPayable(DateTime? pay_date)
        {
            Console.WriteLine(pay_date);
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[LedgerPayable] WHERE date = CONVERT(DATETIME,'"+pay_date+"', 101)";
            Console.WriteLine(com.CommandText);
            // com.CommandText = " SELECT * FROM [Fintest1].[dbo].[Transac] WHERE date = CONVERT(DATETIME, '04/04/2022 00:00:00' , 111)";
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<AccountPayable> payables = new List<AccountPayable>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                payables.Add(new AccountPayable() {id = Convert.ToSingle(dr["id"])
                ,date = Convert.ToDateTime(dr["date"])
                ,Action = Convert.ToString(dr["Action"])
                ,type = Convert.ToString(dr["type"])
                ,Debit = Convert.ToSingle(dr["Debit"])
                ,Credit = Convert.ToSingle(dr["Credit"])
                ,ref_no = Convert.ToString(dr["ref_no"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(payables);
        }

        public IActionResult AccountReceivable(DateTime? rec_date)
        {
            Console.WriteLine(rec_date);
            com.CommandText = "SELECT * FROM [CapsDatabase].[dbo].[LedgerReceivable] WHERE date = CONVERT(DATETIME,'"+rec_date+"', 101)";
            Console.WriteLine(com.CommandText);
            // com.CommandText = " SELECT * FROM [Fintest1].[dbo].[Transac] WHERE date = CONVERT(DATETIME, '04/04/2022 00:00:00' , 111)";
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<AccountReceivable> receivables = new List<AccountReceivable>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                receivables.Add(new AccountReceivable() {id = Convert.ToSingle(dr["id"])
                ,date = Convert.ToDateTime(dr["date"])
                ,Action = Convert.ToString(dr["Action"])
                ,type = Convert.ToString(dr["type"])
                ,Debit = Convert.ToSingle(dr["Debit"])
                ,Credit = Convert.ToSingle(dr["Credit"])
                ,ref_no = Convert.ToString(dr["ref_no"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(receivables);
        }

        public IActionResult Cash()
        {
            return View();
        }

        public IActionResult InventoryLedger()
        {
            string v = "SELECT * FROM [CapsDatabase].[dbo].[LedgerInventory]";
            com.CommandText = v;
            Console.WriteLine(com.CommandText);
            com.Connection = con;
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<InventoryLedger> inventoryledgers = new List<InventoryLedger>();
            foreach(DataRow dr in ds.Tables[0].Rows){
                inventoryledgers.Add(new InventoryLedger() {date = Convert.ToDateTime(dr["date"])
                ,Explaination = Convert.ToString(dr["Explaination"])
                ,ref_no = Convert.ToString(dr["ref_no"])
                ,Debit = Convert.ToSingle(dr["Debit"])
                ,Credit = Convert.ToSingle(dr["Credit"])
                ,Balance = Convert.ToSingle(dr["Balance"])
                });
            }
            con.Close();
            ModelState.Clear();
            return View(inventoryledgers);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
