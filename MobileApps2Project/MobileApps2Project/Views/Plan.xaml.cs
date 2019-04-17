using MobileApps2Project.Models;
using MobileApps2Project.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Plan(double bmr)
        {
            InitializeComponent();
            this.BindingContext = new NutrientViewModel(new PageService(), bmr);
        }

    }
}