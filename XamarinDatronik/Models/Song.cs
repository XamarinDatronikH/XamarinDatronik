using System;
using MvvmHelpers;

namespace XamarinDatronik.Models
{
    public class Song : ObservableObject
    {
        private bool _isFavorite;

        public string Title { get; set; }

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
