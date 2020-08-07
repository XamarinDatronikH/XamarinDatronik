using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.ViewModels
{
    public class DragAndDropDemoViewModel : BaseViewModel
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTOR

        public DragAndDropDemoViewModel()
        {
            Tasks = new ObservableRangeCollection<DragAndDropListItem>();

            for (int i = 0; i < 55; i++)
            {
                Tasks.Add(new DragAndDropListItem($"Task {i}"));
            }

            OrderChangedCommand = new Command(WhenOrderChanged);
        }

        private void WhenOrderChanged()
        {
            // Save to database or whatever when order changed etc.
        }

        #endregion

        #region PROPERTIES

        public ObservableRangeCollection<DragAndDropListItem> Tasks { get; }

        public ICommand OrderChangedCommand { get; }

        #endregion
    }
}
