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

        private void getMealPlan()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    string url = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/mealplans/generate?timeFrame=day&targetCalories=" + bmr + "";

                    Result = Utils.GetApiData<RootObject>(url);

                    System.Diagnostics.Debug.WriteLine(Result.nutrients.calories);

                }
                catch (Exception)
                {
                    _pageService.DisplayAlert("Error", "Error loading", "OK", "Quit");
                }
            });
        }


    }
}
