using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApps2Project.Models
{

    /*
     * Model for Meal Plan 
     */
    public class Meal
    {
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public string image { get; set; }
        public List<string> imageUrls { get; set; }
    }

    public class Nutrients
    {
        public double calories { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public double carbohydrates { get; set; }
    }

    public class RootObject
    {
        public List<Meal> meals { get; set; }
        public Nutrients nutrients { get; set; }
    }

}
