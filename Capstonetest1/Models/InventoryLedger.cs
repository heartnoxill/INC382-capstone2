using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class InventoryLedger
    {
        [DisplayName("DATE")]
        public DateTime date {get; set;}

        [DisplayName("EXPLANATION")]
        public string Explaination {get; set;}

        [DisplayName("REF NO")]
        public string ref_no {get; set;}

        [DisplayName("DEBIT")]
        public float Debit {get; set;}

        [DisplayName("CREDIT")]
        public float Credit {get; set;}

        [DisplayName("BALANCE")]
        public float Balance {get; set;}
    }
}