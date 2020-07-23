using System;
using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class SlideInAnimationDemo
    {
        public SlideInAnimationDemo()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ImageOne.Opacity = 0;
            ImageTwo.Opacity = 0;
            ImageThree.Opacity = 0;

            var animation = new Animation
            {
                {
                    0,
                    .33,
                    new Animation(v => ImageOne.TranslationX = v, -300, 0)
                },
                {
                    0,
                    .33,
                    new Animation(v => ImageOne.Opacity = v, 0, 1)
                },
                {
                    .33,
                    .66,
                    new Animation(v => ImageTwo.TranslationX = v, 300, 0)
                },
                {
                    .33,
                    .66,
                    new Animation(v => ImageTwo.Opacity = v, 0, 1)
                },
                {
                    .66,
                    1,
                    new Animation(v => ImageThree.TranslationX = v, -300,0)
                },
                {
                    .66,
                    1,
                    new Animation(v => ImageThree.Opacity = v, 0,1)
                }
            };

            animation.Commit(this, "SlideIn", length: 1500, easing: Easing.Linear);
        }
    }
}
