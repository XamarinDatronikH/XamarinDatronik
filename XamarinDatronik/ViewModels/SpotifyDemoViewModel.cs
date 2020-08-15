using System;
using System.Collections.Generic;
using MvvmHelpers;
using XamarinDatronik.Models;

namespace XamarinDatronik.ViewModels
{
    public class SpotifyDemoViewModel : BaseViewModel
    {
        #region FIELDS



        #endregion

        #region CONSTRUCTOR

        public SpotifyDemoViewModel()
        {
            InitPopularSongs();
        }

        private void InitPopularSongs()
        {
            PopularSongs = new List<Song>
            {
                new Song
                {
                    Plays = "173,132,140",
                    Title = "Trainz have feelings too",
                    AlbumCover = "nature.jpg",
                    PopularityRank = 1
                },
                new Song
                {
                    Plays = "167,909,498",
                    Title = "Me, my rail and I",
                    AlbumCover = "train.jpg",
                    PopularityRank = 2
                },
                new Song
                {
                    Plays = "112,258,275",
                    Title = "Trainz for lajf",
                    AlbumCover = "nature.jpg",
                    PopularityRank = 3
                },
                new Song
                {
                    Plays = "87,275,602",
                    Title = "How to save a train",
                    AlbumCover = "train.jpg",
                    PopularityRank = 4
                },
                new Song
                {
                    Plays = "34,359,140",
                    Title = "Boatz & Trainz",
                    AlbumCover = "nature.jpg",
                    PopularityRank = 5
                }
            };
        }

        #endregion

        #region PROPERTIES

        public List<Song> PopularSongs { get; set; }

        #endregion

        #region METHODS



        #endregion
    }
}
