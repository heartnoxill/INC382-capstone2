using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class PurchaseOrder
    {
        [DisplayName("PO NUMBER")]
        public string po_number {get; set;}

        [DisplayName("PAYMENT NUMBER")]
        public string Payment_NO {get; set;}

        [DisplayName("DATE")]
        public string date {get; set;}

        [DisplayName("CUSTOMER ID")]
        public float customer_id {get; set;}

        [DisplayName("CUSTOMER NAME")]
        public string customer_name {get; set;}

        [DisplayName("TAXPAYER ID")]
        public string taxpayer_id {get; set;}

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