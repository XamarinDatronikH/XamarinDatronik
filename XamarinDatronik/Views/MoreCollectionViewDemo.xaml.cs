using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class MoreCollectionViewDemo
    {
        public MoreCollectionViewDemo()
        {
            InitializeComponent();
        }

        void Frame_SizeChanged(System.Object sender, System.EventArgs e)
        {
            if (sender is Frame frame)
                frame.HeightRequest = frame.Width;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            ColorsTest.Opacity = 0;
            ColorsTest.TranslationY = 500;
            ColorsTest.IsVisible = true;

            var animation = new Animation
            {
                {
                    0,
                    1,
                    new Animation(v => ColorsTest.TranslationY = v, 500, 0)
                },
                {
                    0,
                    .5,
                    new Animation(v => ColorsTest.Opacity = v, 0, 1)
                }
            };

            animation.Commit(this, "SlideIn", length: 500, easing: Easing.Linear);
            
        }
    }
}
