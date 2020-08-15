using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class SpotifyBasePage : ContentPage
    {
        public SpotifyBasePage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new SpotifyDemo());
        }
    }
}
