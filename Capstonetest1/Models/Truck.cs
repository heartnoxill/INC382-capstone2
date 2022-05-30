using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class Truck
    {
        [DisplayName("PO NUMBER")]
        public float po_no {get; set;}

        [DisplayName("TRUCK ID")]
        public string truck_id {get; set;}

        [DisplayName("STATION NAME")]
        public string Station_name {get; set;}

        [DisplayName("DATE IN")]
        public DateTime Date_in {get; set;}

        [DisplayName("TIME IN")]
        public string Time_in {get; set;}

        [DisplayName("SERVICE TIME")]
        public float Service_time {get; set;}

        [DisplayName("DATE OUT")]
        public DateTime Date_out {get; set;}

        [DisplayName("TIME OUT")]
        public string Time_out {get; set;}
    }
}