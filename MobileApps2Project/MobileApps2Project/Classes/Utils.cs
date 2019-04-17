using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using unirest_net.http;
using unirest_net.request;

namespace MobileApps2Project.Classes
{
    class Utils
    {
        private const string apiKey = "a95634e82cmshc9d9f478728c886p14c5f5jsn5725ed7973e3";
        private const string host = "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com";


        public static T GetApiData<T>(string URL)
        {
            HttpRequest request = Unirest.get(URL).header("X-RapidAPI-Key", apiKey);
            HttpResponse<string> response = request.asString();
           
            T result = JsonConvert.DeserializeObject<T>(response.Body);

            

            return result;
        }
    }
}
