using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDatronik.Views;

[assembly: ExportFont("lineto-circular-black.ttf", Alias = "SpotifyFontBold")]
[assembly: ExportFont("lineto-circular-pro-medium.ttf", Alias = "SpotifyFontMedium")]
[assembly: ExportFont("lineto-circular-pro-book.ttf", Alias = "SpotifyFont")]
namespace XamarinDatronik
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            Device.SetFlags(new[] { "Brush_Experimental" });
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
