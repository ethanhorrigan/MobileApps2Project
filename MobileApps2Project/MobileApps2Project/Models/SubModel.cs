using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApps2Project.Models
{

    /*
     * Model for Ingredients Subsitute 
     */
    public class RootObject
    {
        public string status { get; set; }
        public string ingredient { get; set; }
        public List<string> substitutes { get; set; }
        public string message { get; set; }
    }

}
