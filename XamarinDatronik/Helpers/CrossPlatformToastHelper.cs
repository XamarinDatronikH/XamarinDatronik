using System;
using XamarinDatronik.ViewModels;

namespace XamarinDatronik.Helpers
{
    public static class CrossPlatformToastHelper
    {
        #region FIELDS

        private static CrossPlatformToastViewModel _crossPlatformToastViewModel;

        #endregion

        #region EVENTS

        public static event Action<string, double> ToastRequest = delegate { };

        #endregion

        #region PROPERTIES

        public static CrossPlatformToastViewModel CrossPlatformToastViewModel
        {
            get
            {
                if (_crossPlatformToastViewModel == null)
                    _crossPlatformToastViewModel = new CrossPlatformToastViewModel();

                return _crossPlatformToastViewModel;
            }
        }

        #endregion

        #region METHODS

        public static void RequestToast(string text, double seconds = 3) =>
            ToastRequest(text, seconds);

        #endregion
    }
}
