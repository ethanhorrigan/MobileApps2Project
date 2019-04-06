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

        private void IngSearch_SearchButtonPressed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Search Clicked");
        }


        /*
        static async Task<SubstituteRootObject> GetRootInfo() {
            HttpResponse<SubstituteRootObject> response = await Unirest.get("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/food/ingredients/substitutes?ingredientName=butter")
            .header("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com")
            .header("X-RapidAPI-Key", apiKey)
            .asJson();
            return response.Body;
        }

        const string _baseUrl = "http://api.themoviedb.org/3/";
        const string _pageString = "&page=";

        //GET Example
        public static async Task<ObservableCollection<SubstituteRootObject>> GetTopRatedMoviesAsync()
        {
            HttpClient client = new HttpClient();
            //_apiKey = themoviedb api key, page = page size 1 = first 20 movies;
            string topRatedUrl = _baseUrl + "movie/top_rated?" + _apiKey + _pageString + page;
            HttpResponseMessage result = await client.GetAsync(topRatedUrl, CancellationToken.None);

            if (result.IsSuccessStatusCode)
            {
                try
                {
                    string content = await result.Content.ReadAsStringAsync();
                    ObservableCollection<Movie> MovieList = GetJsonData(content);
                    //return a ObservableCollection to fill a list of top rated movies
                    return MovieList;

                }
                catch (Exception ex)
                {
                    //Model Error
                    Console.WriteLine(ex);
                    return null;
                }
            }
            //Server Error or no internet connection.
            return null;
        }
        */
    }
}
