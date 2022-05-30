using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class Journal
    {
        [DisplayName("REF NO")]
        public float ref_no {get; set;}

        [DisplayName("DATE/TIME")]
        public DateTime date {get; set;}

        [DisplayName("ACCOUNT TITLE AND EXPLANATION")]
        public string Action {get; set;}

        [DisplayName("TYPE")]
        public string Type {get; set;}

        [DisplayName("DEBIT")]
        public float Debit {get; set;}

        [DisplayName("CREDIT")]
        public float Credit {get; set;}

        [DisplayName("TRUCK ID")]
        public string Truck_id {get; set;}
    }
}