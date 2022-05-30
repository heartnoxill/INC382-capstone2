using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class AccountPayable
    {
        [DisplayName("ID")]
        public float id {get; set;}

        [DisplayName("DATE")]
        public DateTime date {get; set;}
        
        [DisplayName("ACTION")]
        public string Action {get; set;}

        [DisplayName("TYPE")]
        public string type {get; set;}

        [DisplayName("DEBIT")]
        public float Debit {get; set;}

        [DisplayName("CREDIT")]
        public float Credit {get; set;}

        [DisplayName("REF NO")]
        public string ref_no {get; set;}
    }
}