using System;
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
            Tasks = new ObservableRangeCollection<DragAndDropListItem>
            {
                new DragAndDropListItem("Task one"),
                new DragAndDropListItem("Task two"),
                new DragAndDropListItem("Task three"),
                new DragAndDropListItem("Task four"),
                new DragAndDropListItem("Task five"),
            };

            OrderChangedCommand = new Command(DoOrderChanged);
        }

        private void DoOrderChanged(object obj)
        {
            var x = obj;
            var y = 0;
        }

        #endregion

        #region PROPERTIES

        public ObservableRangeCollection<DragAndDropListItem> Tasks { get; }

        public ICommand OrderChangedCommand { get; }

        #endregion

        #region METHODS

        public void SetOrder(int itemIndex, int newPositionIndex)
        {
            var task = Tasks[itemIndex];

            Tasks.Remove(task);
            Tasks.Insert(newPositionIndex, task);
        }

        #endregion
    }
}
