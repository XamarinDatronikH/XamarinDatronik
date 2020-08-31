using System;
using MvvmHelpers;

namespace XamarinDatronik.Models
{
    public class CurrentlyPlayingSong : ObservableObject
    {
        private int _timeElapsed;

        private bool _isPlaying;

        private Song _song;

        public CurrentlyPlayingSong(Song song) =>
            Song = song;

        public Song Song
        {
            get => _song;
            set => SetProperty(ref _song, value);
        }

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
