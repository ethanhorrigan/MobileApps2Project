using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps2Project.ViewModel
{
        public class PageService : IPageService
        {
            public async Task PushAsync(Page page)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }

            public async Task<bool> Alert(string t, string m, string v, string q)
            {
                return await Application.Current.MainPage.DisplayAlert(t, m, v, q);
            }
        }
    }
