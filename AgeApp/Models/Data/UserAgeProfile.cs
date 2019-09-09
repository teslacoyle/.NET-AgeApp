using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.Models.Data
{
    public class UserAgeProfile
    {
        public int UserAgeProfileID { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}