using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinDatronik.Helpers;

namespace XamarinDatronik.ViewModels
{
    public class CrossPlatformToastViewModel
    {
        #region FIELDS

        private int _toastCount;

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

            _toastCount++;

            var toastId = _toastCount;

            Device.StartTimer(TimeSpan.FromSeconds(seconds), () =>
            {
                if(_toastCount == toastId)
                    Toasts.Clear();

                return false;
            });
        }

        #endregion
    }
}
