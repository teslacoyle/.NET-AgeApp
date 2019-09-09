using AgeApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeApp.Models.View
{
    public class AgeViewModel
    {
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public int[] AgeFrequencies { get; set; }

        public UserAgeProfile UserProfile { get; set; }
    }
}