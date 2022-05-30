using System;
using System.ComponentModel;

namespace Capstonetest1.Models
{
    public class UserProfile
    {
        public float User_id {get; set;}

        [DisplayName("USERNAME")]
        public string username {get; set;}

        public string password {get; set;}

        [DisplayName("NAME")]
        public string name {get; set;}
    }
}