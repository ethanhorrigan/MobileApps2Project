using MobileApps2Project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApps2Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Plan : ContentPage
    {
        /*
   * API Details
   */
        static string apiKey = "a95634e82cmshc9d9f478728c886p14c5f5jsn5725ed7973e3";
        static string host = "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com";

        static string cal;

        public Plan()
        {
            InitializeComponent();
        }



        public static async void GetProduct(double c)
        {
            MainPage.calories = c;
            string url = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/mealplans/generate?timeFrame=day&targetCalories=" + MainPage.calories + "";
            System.Diagnostics.Debug.WriteLine("hello");
            //Creating a Http client
            HttpClient client = new HttpClient();
            //Adding 2 Custom Defualt Headers
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);

            string request = await client.GetStringAsync(url);
            // Parsing into JSON
            //var data = JsonConvert.DeserializeObject<RootObject>(response);
            var response = JsonConvert.DeserializeObject<RootObject>(request);

            // Debug 


            for (int i = 0; i < response.meals.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(response.meals[i].title);
                System.Diagnostics.Debug.WriteLine(response.meals[i].readyInMinutes);


            }

            System.Diagnostics.Debug.WriteLine(response.nutrients.calories);
            System.Diagnostics.Debug.WriteLine(response.nutrients.protein);
            System.Diagnostics.Debug.WriteLine(response.nutrients.fat);
            System.Diagnostics.Debug.WriteLine(response.nutrients.carbohydrates);

            cal = Convert.ToString(response.nutrients.calories);
            System.Diagnostics.Debug.WriteLine(cal);
            Populate();
        }

        private static void Populate()
        {
            //nCal.Text = cal;
        }
    }
}