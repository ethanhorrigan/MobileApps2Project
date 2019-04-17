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

        
        /*
         * Initially I used C#'s HttpClient Class to make a request, but then Settled for UNIREST, as I found it better to makes calls
         * and Binding
         */
        public static T GetApiData<T>(string URL)
        {
            HttpRequest request = Unirest.get(URL).header("X-RapidAPI-Key", apiKey);
            HttpResponse<string> response = request.asString();
           
            T r = JsonConvert.DeserializeObject<T>(response.Body);

            return r;
        }
        
    }
}
