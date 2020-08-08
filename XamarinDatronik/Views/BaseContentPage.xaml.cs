using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Content.Opacity = 0;

            var animation = new Animation()
            {
                { 0, 1, new Animation(v => Content.Opacity = v, 0, 1) }
            };

            animation.Commit(this, "test", 16, 500, easing: Easing.Linear);
        }
    }
}
