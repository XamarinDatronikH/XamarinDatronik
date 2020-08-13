using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinDatronik.Helpers;

namespace XamarinDatronik.Views.CustomControls
{
    public partial class CrossPlatformToast : ContentView
    {
        public CrossPlatformToast()
        {
            InitializeComponent();
            BindingContext = CrossPlatformToastHelper.CrossPlatformToastViewModel;
        }
    }
}
