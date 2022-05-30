using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class Invoice
    {
        [DisplayName("PO NUMBER")]
        public float po_number {get; set;}

        [DisplayName("PAYMENT NUMBER")]
        public string Payment_NO {get; set;}

        [DisplayName("INVOICE DATE")]
        public string invoice_date {get; set;}

        [DisplayName("CUSTOMER ID")]
        public float customer_id {get; set;}

        [DisplayName("CUSTOMER NAME")]
        public string customer_name {get; set;}

        [DisplayName("TAXPAYER ID")]
        public string taxpayer_id {get; set;}

        [DisplayName("INVOICE NO")]
        public string Invoice_no {get; set;}

        [DisplayName("CUSTOMER ADDRESS")]
        public string customer_address {get; set;}

        [DisplayName("TYPE")]
        public string pretrol_type {get; set;}

        [DisplayName("PRICE/LITRE")]
        public float Price_Litres {get; set;}

        [DisplayName("QTY")]
        public float Litres {get; set;}

        [DisplayName("AMOUNT")]
        public float Price {get; set;}
    }
}