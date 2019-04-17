using MobileApps2Project.Classes;
using MobileApps2Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps2Project.ViewModel
{
    class NutrientViewModel : BaseViewModel
    {
        private double bmr { get; set; }

        private RootObject _results;
        public RootObject Result
        {
            get { return _results; }
            set { SetValue(ref _results, value); }

        }

        private List<Meal> _meals;
        public List<Meal> Meals
        {
            get { return _meals; }
            set { SetValue(ref _meals, value); }

        }

        private readonly IPageService _pageService;

        public NutrientViewModel(IPageService pageService, double bmr)
        {
            _pageService = pageService;
            this.bmr = bmr;
            getMealPlan();
        }

        /*
         * This method creates the query for the API Call to the Spoonacular API, bmr is used to make the call depending on the BMR that was calculated
         * Images are created from the image links given in the call.
         * catches an error if the API call cannot be made (e.g. no internet access)
         */
        private void getMealPlan()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    string url = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/mealplans/generate?timeFrame=day&targetCalories=" + bmr + "";

                    Result = Utils.GetApiData<RootObject>(url);
                    Meals = Result.meals;


                    /*API call did not give direct link to image, so using the Documentation for the API I could get image from the Meal ID 
                    // https://spoonacular.com/food-api/docs/show-images*/

                    for (int i = 0; i < Meals.Count; ++i)
                    {
                        Meals[i].image = "https://spoonacular.com/recipeImages/"+Meals[i].id+"-556x370.jpg";
                    }

                }
                catch (Exception)
                {
                    _pageService.DisplayAlert("Error", "Error Connecting..", "Continue", "Quit");
                }
            });
        }


    }
}
