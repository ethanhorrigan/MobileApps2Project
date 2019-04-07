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
         * API Details
         */
        string apiKey = "a95634e82cmshc9d9f478728c886p14c5f5jsn5725ed7973e3";
        string host = "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com";
        static string query = "butter";
        string url = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/food/ingredients/substitutes?ingredientName="+query+"";

        /* 
         * User Variables
         */
        private int age;
        private double weight;
        private double calories;



        public MainPage()
        {
            InitializeComponent();
        }


        /* Search Method
         * Allowing the user to input a subsititue query
         */
        private void Button_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("clicked");
            GetProduct();
        }

        /*
         * GetProduct() Method
         * Creating a new HttpClient to allow for requests to the Spoonacular API
         * Finally, converting from JSON
         */
        private async void GetProduct()
        {

            //Creating a Http client
            HttpClient client = new HttpClient();
            //Adding 2 Custom Defualt Headers
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);

  
            string response = await client.GetStringAsync(url);
            // Parsing into JSON
            var data = JsonConvert.DeserializeObject<RootObject>(response);

            // Debug 
            System.Diagnostics.Debug.WriteLine(data.ingredient);
            System.Diagnostics.Debug.WriteLine(data.message);
            System.Diagnostics.Debug.WriteLine(data.status);

            for (int i = 0; i < data.substitutes.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(data.substitutes[i]);
            }
        }

        /*
         * CalculateBMR Function which calculates BMR (Basal Metabolic Rate)
         * Resulting in calorie intake per day depending on gender, weight & age
         */
        private double CalculateBMR(int a, double w)
        {
            double bmr = 0;

            //Female Calculations
            if(age >= 10 || age <= 17)
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

            return bmr;
        }

    }
}
