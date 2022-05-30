using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstonetest1.Models
{
    public class Transac
    {
        public int Trans_ID {get; set;}
        public DateTime Trans_date {get; set;}
        public string Action {get; set;}
        public string Type {get; set;}
        public float Volume {get; set;}
        public float Amount {get; set;}
        public float VAT {get; set;}
        public float TotalSale {get; set;}
    }
}