using System;
using MvvmHelpers;
using Xamarin.Forms;

namespace XamarinDatronik.ViewModels
{
    public class ConverterDemoViewModel : BaseViewModel
    {
        #region FIELDS

        private int _elapsedSeconds;

        private int _elapsedSecondsSinceEvent;

        private DateTime _eventTime;

        #endregion

        #region CONSTRUCTOR

        public ConverterDemoViewModel()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), TimeTick);
            _eventTime = new DateTime(2015, 12, 23);
        }

        #endregion

        #region PROPERTIES

        public int ElapsedSeconds
        {
            get => _elapsedSeconds;
            set => SetProperty(ref _elapsedSeconds, value);
        }

        public int ElapsedSecondsSinceEvent
        {
            get => _elapsedSecondsSinceEvent;
            set => SetProperty(ref _elapsedSecondsSinceEvent, value);
        }

        #endregion

        #region METHODS

        private bool TimeTick()
        {
            //ElapsedSeconds++;
            ElapsedSeconds = (int)(DateTime.Now - _eventTime).TotalSeconds;
            return true;
        }

        #endregion
    }
}
