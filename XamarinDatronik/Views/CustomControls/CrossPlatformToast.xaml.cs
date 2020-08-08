using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinDatronik.Helpers;

namespace XamarinDatronik.Views
{
    public partial class CrossPlatformToast
    {
        public CrossPlatformToast()
        {
            InitializeComponent();
            BindingContext = CrossPlatformToastHelper.CrossPlatformToastViewModel;
        }
    }
}
