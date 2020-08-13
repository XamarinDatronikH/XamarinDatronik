using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class GradientDemo : ContentPage
    {
        public GradientDemo()
        {
            InitializeComponent();

            var a = new Animation
            {
                { 0, .5, new Animation(v => UpperBlack.Offset = (float)v, 0.0, 0.4) },
                { .55, 1, new Animation(v => UpperBlack.Offset = (float)v, 0.4, 0.0) },
                { 0, .5, new Animation(v => LowerBlack.Offset = (float)v, 1.0, 0.6) },
                { .55, 1, new Animation(v => LowerBlack.Offset = (float)v, 0.6, 1.0) }
            };
            a.Commit(this, "GradientAnimation", length: 10000, repeat: () => true);
        }
    }
}
