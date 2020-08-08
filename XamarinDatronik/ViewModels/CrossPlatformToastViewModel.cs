using System;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinDatronik.Helpers;

namespace XamarinDatronik.ViewModels
{
    public class CrossPlatformToastViewModel : BaseViewModel
    {
        #region FIELDS

        private int _currentToastCount;

        #endregion

        #region CONSTRUCTOR

        public CrossPlatformToastViewModel()
        {
            Toasts = new ObservableCollection<string>();
            CrossPlatformToastHelper.ToastRequest += OnToastRequest;
        }

        #endregion

        #region PROPERTIES

        public ObservableCollection<string> Toasts { get; }

        #endregion

        #region METHODS

        private void OnToastRequest(string text, double seconds)
        {
            Toasts.Clear();

            Toasts.Add(text);

            _currentToastCount++;

            var toastId = _currentToastCount;


            Device.StartTimer(TimeSpan.FromSeconds(seconds), () =>
            {
                if (_currentToastCount == toastId)
                    Toasts.Clear();

                return false;
            });
        }

        #endregion
    }
}
