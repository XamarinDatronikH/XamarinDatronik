using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.Views
{
    public partial class SpotifyDemo : ContentPage
    {
        #region FIELDS

        public static readonly BindableProperty ShowTempShuffleBtnProperty =
            BindableProperty.Create(nameof(ShowTempShuffleBtn), typeof(bool), typeof(SpotifyDemo));

        #endregion

        #region CONSTRUCTOR

        public SpotifyDemo() => InitializeComponent();

        #endregion

        #region PROPERTIES

        public bool ShowTempShuffleBtn
        {
            get => (bool)GetValue(ShowTempShuffleBtnProperty);
            private set => SetValue(ShowTempShuffleBtnProperty, value);
        }

        #endregion

        #region METHODS

        void OnCurrentlyPlayingTitleSizeChanged(object sender, EventArgs e)
        {
            if (CurrentlyPlayingTitle.Width > 0)
                InitAnimation();
        }

        private void InitAnimation()
        {
            var translationXMin = (CurrentlyPlayingTitle.Width - CurrentlyPlayingTitleSecondLabel.Width - 10) * -1;

            var animation = new Animation
            {
                { 0, .95, new Animation(v => CurrentlyPlayingTitle.TranslationX = v, 10, translationXMin) }
            };

            animation.Commit(this, "TitleSlide", length: 10000, repeat: () => true);
        }

        void Grid_SizeChanged(object sender, EventArgs e) =>
            ScrollViewMarginView.HeightRequest = (TopContainer.Height / 2) - TopNavigation.Height - 2;

        void OnMainScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            var threshold = ScrollViewMarginView.Height - 25;

            if(e.ScrollY >= threshold)
            {
                ShowTempShuffleBtn = true;
                TopNavigationBackground.Opacity = 0;
                TopNavigationBackBackground.Opacity = 1;
                TempArtistTitle.Opacity = 1;
            }
            else
            {
                ShowTempShuffleBtn = false;

                TopNavigationBackBackground.Opacity = 0;

                FadedLayer.TranslationY = -(e.ScrollY);

                var multiplier = 0.2 / threshold;

                var artistInfoY = ArtistInfoContainer.Y - ArtistInfoContainer.Height;

                var spaceBetween = threshold - artistInfoY;

                ArtistImage.Scale = 1.2 - multiplier * e.ScrollY;

                if (e.ScrollY >= artistInfoY)
                {
                    TempArtistTitle.Opacity = Math.Min((e.ScrollY - spaceBetween) / spaceBetween, 1);
                    TopNavigationBackground.Opacity = Math.Min((e.ScrollY - spaceBetween) / spaceBetween, 1);
                }
                else
                {
                    TempArtistTitle.Opacity = 0;
                    TopNavigationBackground.Opacity = 0;
                }
            }
        }
        #endregion
    }
}
