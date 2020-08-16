using System;
using MvvmHelpers;

namespace XamarinDatronik.Models
{
    public class CurrentlyPlayingSong : ObservableObject
    {
        private int _timeElapsed;

        private bool _isPlaying;

        public CurrentlyPlayingSong(Song song) =>
            Song = song;

        public Song Song { get; set; }

        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        public int TimeElapsed
        {
            get => _timeElapsed;
            set => SetProperty(ref _timeElapsed, value);
        }
    }
}
