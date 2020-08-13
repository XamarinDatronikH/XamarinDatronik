using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDatronik.Views;

namespace XamarinDatronik
{
    public partial class App : Application
    {

        public App()
        {
            Device.SetFlags(new[] { "Brush_Experimental" } );
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
