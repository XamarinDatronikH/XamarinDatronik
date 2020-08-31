using System;
using MvvmHelpers;

namespace XamarinDatronik.Models
{
    public class Song : ObservableObject
    {
        private bool _isFavorite;

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Plays { get; set; }

        public string AlbumCover { get; set; }

        public string AlbumName { get; set; }

        public int PopularityRank { get; set; }

        public string Artist { get; set; }

        public int Length { get; set; }

        public bool IsFavorite
        {
            get => _isFavorite;
            set => SetProperty(ref _isFavorite, value);
        }
    }
}
