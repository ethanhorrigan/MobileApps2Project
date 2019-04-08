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
        /* 
        * User Variables
        */
        private bool gender = false;
        private double age;
        private double weight;
        public static double calories;


        Dictionary<string, int> gend = new Dictionary<string, int> {
            { "Male", 0 },
            { "Female", 1 }
        };

        /*
         * API Details
         */
        string apiKey = "a95634e82cmshc9d9f478728c886p14c5f5jsn5725ed7973e3";
        string host = "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com";





        public MainPage()
        {
            InitializeComponent();
            AddGenderPicker();
        }

        /*
         * GetProduct() Method
         * Creating a new HttpClient to allow for requests to the Spoonacular API
         * Finally, converting from JSON
         */


            private void AddGenderPicker()
        {
            Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker picker = new Picker
            {
                Title = "Color",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string gender in gend.Keys)
            {
                picker.Items.Add(gender);
            }

            // Create BoxView for displaying picked Color
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            {
                if (picker.SelectedIndex == -1)
                {
                    boxView.Color = Color.Default;
                }
                else
                {
                    //string genderType = picker.Items[picker.SelectedIndex];
                    //boxView = nameToColor[genderType];
                }
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
            {
                header,
                picker,
                boxView
            }
            };

        }



        /*
         * CalculateBMR Function which calculates BMR (Basal Metabolic Rate)
         * Resulting in calorie intake per day depending on gender, weight & age
         */
        private double CalculateBMR(double a, double w)
        {
            double bmr = 0;

            if (gender == false)
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
                if (age >= 10 || age <= 17)
                {
                    bmr = 17.7 * weight + 657;
                }
                //18 - 29 years BMR: 15.1 x weight +692
                else if (age >= 18 || age <= 29)
                {
                    bmr = 15.1 * weight + 692;
                }
                //30-59 years BMR: 11.5 x weight + 873
                else
                {
                    bmr = 11.5 * weight + 873;
                }
            }


            return bmr;
        }

        private void AgeEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WeightEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GenerateBtn_Clicked(object sender, EventArgs e)
        {
            // age = (Convert.ToDouble(ageEntry.Text));
            // weight = (Convert.ToDouble(weightEntry.Text));
            calories = CalculateBMR(age, weight);
            System.Diagnostics.Debug.WriteLine("Calorie Intake: " + CalculateBMR(age, weight) + "");
            Plan.GetProduct(calories);
            Navigation.PushAsync(new Plan());
        }
    }
}
