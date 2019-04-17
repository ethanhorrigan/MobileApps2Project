using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps2Project.ViewModel
{
        public class PageService : IPageService
        {
            // Method to get the current page and pass in the new page to be pushed onto the navigation stack
            // This can be used throughout the model views
            public async Task PushAsync(Page page)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }

            public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
            {
                return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
            }
        }
    }
