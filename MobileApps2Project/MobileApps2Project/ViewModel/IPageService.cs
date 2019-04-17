using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps2Project.ViewModel
{
 
        public interface IPageService
        {
            Task PushAsync(Page page);
            Task<bool> DisplayAlert(string t, string m, string v, string q);
        }
}
