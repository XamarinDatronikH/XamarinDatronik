using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.ViewModels
{
    public class TwitchDemoViewModel : BaseViewModel
    {
        #region FIELDS

        private bool _isRefreshingCategories;

        #endregion

        #region CONSTRUCTOR

        public TwitchDemoViewModel()
        {
            Categories = InitTestCategories();
            RefreshCategoriesCommand = new Command(async () => await DoRefreshCategoriesAsync());
        }

        #endregion

        #region PROPERTIES

        public bool IsRefreshingCategories
        {
            get => _isRefreshingCategories;
            set => SetProperty(ref _isRefreshingCategories, value);
        }

        public ObservableRangeCollection<TwitchCategory> Categories { get; }

        #endregion

        #region COMMANDS

        public ICommand RefreshCategoriesCommand { get; }

        #endregion

        #region METHODS

        private async Task DoRefreshCategoriesAsync()
        {
            await Task.Delay(1000);
            IsRefreshingCategories = false;
        }

        private ObservableRangeCollection<TwitchCategory> InitTestCategories()
        {
            return new ObservableRangeCollection<TwitchCategory>
            {
                new TwitchCategory { },
                new TwitchCategory { },
                new TwitchCategory { },
                new TwitchCategory { },
                new TwitchCategory { },
                new TwitchCategory { },
            };
        }

        #endregion
    }
}
