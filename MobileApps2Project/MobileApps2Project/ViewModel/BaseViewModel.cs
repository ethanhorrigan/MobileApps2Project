﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileApps2Project.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string thisProperty = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(thisProperty));
        }
    }
}
