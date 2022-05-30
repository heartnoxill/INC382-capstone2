using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class Recon
    {
        [DisplayName("DATE")]
        public DateTime recon_date {get; set;}

        [DisplayName("PO NO")]
        public float po_number {get; set;}

        [DisplayName("PAYENT NO")]
        public string Payment_NO {get; set;}

        [DisplayName("INVOICE NO")]
        public string Invoice_no {get; set;}

        [DisplayName("TRUCK NO")]
        public string truck_no {get; set;}

        [DisplayName("PATROL TYPE")]
        public string type {get; set;}

        [DisplayName("QTY")]
        public float litres {get; set;}

        [DisplayName("AMOUNT")]
        public float Price {get; set;}

        [DisplayName("CUSTOMER NAME")]
        public string customer_name {get; set;}
    }
}