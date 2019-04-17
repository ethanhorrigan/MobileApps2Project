using MobileApps2Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps2Project
{
    public partial class MainPage : ContentPage
    {

        public static double calories = 0;

        /* 
        * User Variables
        */
        private bool gender = false;


        Dictionary<string, int> gend = new Dictionary<string, int> {
            { "Male", 0 },
            { "Female", 1 }
        };


        public MainPage()
        {
            InitializeComponent();
            AddGenderPicker();
        }



        private void AddGenderPicker()
        {
            foreach (string gender in gend.Keys)
            {
                 genPicker.Items.Add(gender);
            }

        }

        /*
         * CalculateBMR Function which calculates BMR (Basal Metabolic Rate)
         * Resulting in calorie intake per day depending on gender, weight & age
         */
        private double CalculateBMR(double age, double weight)
        {
            double bmr = 0;

            if (gender == true)
            {
                //Female Calculations
                if (age >= 10 || age <= 17)
                {
                    bmr = 13.4 * weight + 692;
                }
                //18-29 years BMR: 14.8 x weight + 487
                else if (age >= 18 || age <= 29)
                {
                    bmr = 14.8 * weight + 487;
                }
                //30 - 59 years BMR: 8.3 x weight +846
                else
                {
                    bmr = 8.3 * weight + 846;
                }
            }

            else
            {

                //Male Calculations
                //BMR: 17.7 x weight + 657
                if (age >= 10 && age <= 17)
                {
                    bmr = 17.7 * weight + 657;
                    System.Diagnostics.Debug.WriteLine("[Male]: 10 - 17: " + bmr + "");
                }
                //18 - 29 years BMR: 15.1 x weight +692
                else if (age >= 18 && age <= 29)
                {
                    bmr = 15.1 * weight + 692;
                    System.Diagnostics.Debug.WriteLine("[Male]: 18 - 29: " + bmr + "");
                }
                //30-59 years BMR: 11.5 x weight + 873
                else
                {
                    bmr = 11.5 * weight + 873;
                    System.Diagnostics.Debug.WriteLine("[Male]: 30 - 59: " + bmr + "");
                }
            }


            return bmr;
        }


        private void GenerateBtn_Clicked(object sender, EventArgs e)
        {
             double age = (Convert.ToDouble(ageEntry.Text));
             double weight = (Convert.ToDouble(weightEntry.Text));
             calories = CalculateBMR(age, weight);
             Navigation.PushAsync(new Plan(calories));
        }
    }
}
