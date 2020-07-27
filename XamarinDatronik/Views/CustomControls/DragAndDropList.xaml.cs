using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.Views
{
    public partial class DragAndDropList
    {
        #region FIELDS

        public static readonly BindableProperty ItemBackgroundColorProperty =
            BindableProperty.Create(nameof(ItemBackgroundColor), typeof(string), typeof(DragAndDropList));

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<DragAndDropListItem>), typeof(DragAndDropList), null, propertyChanged: OnItemsSourceChanged);

        private int _currentItemIndex;

        private int _currentPositionIndex;

        private bool _originalPosition;

        #endregion

        #region EVENTS

        public event Action<int, int> OrderChanged = delegate { };

        #endregion

        #region CONSTRUCTOR

        public DragAndDropList()
        {
            InitializeComponent();
        }

        #endregion

        #region PROPERTIES

        public string ItemBackgroundColor
        {
            get => (string)GetValue(ItemBackgroundColorProperty);
            set => SetValue(ItemBackgroundColorProperty, value);
        }

        public IEnumerable<DragAndDropListItem> ItemsSource
        {
            get => (IEnumerable<DragAndDropListItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        #endregion

        #region METHODS

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue != null && newValue is IEnumerable<DragAndDropListItem> items && bindable is DragAndDropList diz)
                BindableLayout.SetItemsSource(diz, items);
        }

        private void OnPanStarted(Grid element)
        {
            for (int i = 0; i < Container.Children.Count; i++)
            {
                if (Container.Children[i] == element)
                {
                    _currentItemIndex = i;

                    element.Scale = .85;
                    element.Opacity = .5;

                    Container.RaiseChild(element);
                    return;
                }
            }
        }

        private void OnPanStopped(Grid element)
        {
            var count = 0;

            // Reset visual stack order
            foreach (var child in Container.Children.ToList())
            {
                if (count == _currentItemIndex)
                    Container.RaiseChild(element);

                if (child != element)
                    Container.RaiseChild(child);

                count++;
            }

            element.Scale = 1;
            element.Opacity = 1;
            element.TranslationY = 0;

            if (!_originalPosition)
                OrderChanged(_currentItemIndex, _currentPositionIndex);
        }

        private void OnOngoingPan(Grid element, PanUpdatedEventArgs e)
        {
            element.TranslationY = e.TotalY;

            var startY = element.Y + e.TotalY;
            var endY = startY + element.Height;

            _originalPosition = true;

            var count = -1;

            foreach(var child in Container.Children)
            {
                count++;

                if (child == element)
                    continue;

                var childStartY = child.Y;
                var childEndY = childStartY + child.Height;

                if(startY < childEndY && startY > childStartY)
                {
                    _currentPositionIndex = count;
                    _originalPosition = false;
                }
                else if(endY > childStartY && endY < childEndY)
                {
                    _currentPositionIndex = count;
                    _originalPosition = false;
                }
            }
        }

        void ParentGridPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var element = sender as Grid;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    OnPanStarted(element);
                    return;
                case GestureStatus.Running:
                    OnOngoingPan(element, e);
                    return;
                default:
                    OnPanStopped(element);
                    return;
            }
        }

        #endregion
    }
}
