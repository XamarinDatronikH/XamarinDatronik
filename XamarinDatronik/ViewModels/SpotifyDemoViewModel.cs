using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.ViewModels
{
    public class SpotifyDemoViewModel : BaseViewModel
    {
        #region FIELDS

        private CurrentlyPlayingSong _currentlyPlaying;

        private float _currentlyPlayingProgress;

        #endregion

        #region CONSTRUCTOR

        public SpotifyDemoViewModel()
        {
            InitPopularSongs();
            InitPopularAlbums();
            CurrentlyPlaying = new CurrentlyPlayingSong(PopularSongs[0]);
            PlaySongCommand = new Command<Song>(DoPlaySong);
            ShufflePlayCommand = new Command(DoShufflePlay);
            ToggleIsPlayingCommand = new Command(DoToggleIsPlaying);

            InitPlayingTimer();
        }

        private void InitPlayingTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (CurrentlyPlaying.IsPlaying)
                {
                    CurrentlyPlaying.TimeElapsed++;

                    if (CurrentlyPlaying.TimeElapsed == CurrentlyPlaying.Song.Length)
                        DoShufflePlay();
                    else
                        CurrentlyPlayingProgress = Math.Min((float)CurrentlyPlaying.TimeElapsed / CurrentlyPlaying.Song.Length, 1);
                }
                return true;
            });
        }

        #endregion

        #region PROPERTIES

        public List<Song> PopularSongs { get; set; }

        public List<Album> PopularAlbums { get; set; }

        public CurrentlyPlayingSong CurrentlyPlaying
        {
            get => _currentlyPlaying;
            set => SetProperty(ref _currentlyPlaying, value, onChanged: OnCurrentlyPlayingChanged);
        }

        public float CurrentlyPlayingProgress
        {
            get => _currentlyPlayingProgress;
            set => SetProperty(ref _currentlyPlayingProgress, value);
        }

        public ICommand PlaySongCommand { get; }

        public ICommand ShufflePlayCommand { get; }

        public ICommand ToggleIsPlayingCommand { get; }

        #endregion

        #region METHODS

        private void DoToggleIsPlaying() =>
            CurrentlyPlaying.IsPlaying = !CurrentlyPlaying.IsPlaying;

        private void OnCurrentlyPlayingChanged()
        {
            CurrentlyPlaying.IsPlaying = true;
        }

        private void DoShufflePlay() =>
            CurrentlyPlaying = new CurrentlyPlayingSong(PopularSongs[2]);

        private void DoPlaySong(Song song) =>
            CurrentlyPlaying = new CurrentlyPlayingSong(song);

        private void InitPopularAlbums()
        {
            PopularAlbums = new List<Album>
            {
                new Album
                {
                    AlbumCover = "train.jpg",
                    AlbumName = "Album1",
                    ReleaseYear = 2000
                },
                new Album
                {
                    AlbumCover = "wreck.jpg",
                    AlbumName = "Album1",
                    ReleaseYear = 2001
                },
                new Album
                {
                    AlbumCover = "sunrise.jpg",
                    AlbumName = "Album1",
                    ReleaseYear = 2002
                },
                new Album
                {
                    AlbumCover = "station.jpg",
                    AlbumName = "Album1",
                    ReleaseYear = 2002
                },
            };
        }

        private void InitPopularSongs()
        {
            PopularSongs = new List<Song>
            {
                new Song
                {
                    Plays = "167,909,498",
                    Title = "Me, my rail and I",
                    AlbumCover = "sunrise.jpg",
                    PopularityRank = 1,
                    Artist = "The Trainz",
                    Length = 135
                },
                new Song
                {
                    Plays = "112,258,275",
                    Title = "Trainz for lajf",
                    AlbumCover = "train.jpg",
                    PopularityRank = 2,
                    Artist = "The Trainz",
                    Length = 145
                },
                new Song
                {
                    Plays = "173,132,140",
                    Title = "Right before we met",
                    AlbumCover = "station.jpg",
                    PopularityRank = 3,
                    Artist = "The Trainz",
                    Length = 25
                },
                new Song
                {
                    Plays = "87,275,602",
                    Title = "How to save a train",
                    AlbumCover = "wreck.jpg",
                    PopularityRank = 4,
                    Artist = "The Trainz",
                    Length = 45
                },
                new Song
                {
                    Plays = "34,359,140",
                    Title = "Boatz & Trainz",
                    AlbumCover = "train.jpg",
                    PopularityRank = 5,
                    Artist = "The Trainz",
                    Length = 35
                }
            };
        }

        #endregion
    }
}
