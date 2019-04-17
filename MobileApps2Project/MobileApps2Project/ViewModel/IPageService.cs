﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps2Project.ViewModel
{
 
        public interface IPageService
        {
            // Method declarations 
            Task PushAsync(Page page);
            Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        }
}