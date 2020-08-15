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

        public SpotifyDemo()
        {
            InitializeComponent();
        }

        #endregion

        #region PROPERTIES

        public bool ShowTempShuffleBtn
        {
            get => (bool)GetValue(ShowTempShuffleBtnProperty);
            set => SetValue(ShowTempShuffleBtnProperty, value);
        }

        #endregion

        #region METHODS

        void Grid_SizeChanged(System.Object sender, System.EventArgs e) =>
            ScrollViewMarginView.HeightRequest = (TopContainer.Height / 2) - TopNavigation.Height - 2;

        void OnMainScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            var threshold = ScrollViewMarginView.Height - 25;

            if(e.ScrollY >= threshold)
                ShowTempShuffleBtn = true;
            else
            {
                ShowTempShuffleBtn = false;

                var artistInfoY = ArtistInfoContainer.Y - ArtistInfoContainer.Height;

                var spaceBetween = threshold - artistInfoY;

                if (e.ScrollY >= artistInfoY)
                    TempArtistTitle.Opacity = Math.Min((e.ScrollY - spaceBetween) / spaceBetween, 1);
                else
                    TempArtistTitle.Opacity = 0;

            }
        }

        #endregion
    }
}
