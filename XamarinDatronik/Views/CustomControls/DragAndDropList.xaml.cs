using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            BindableProperty.Create(nameof(ItemsSource), typeof(ObservableCollection<DragAndDropListItem>), typeof(DragAndDropList), null, propertyChanged: OnItemsSourceChanged);

        public static readonly BindableProperty IsEditModeProperty =
            BindableProperty.Create(nameof(IsEditMode), typeof(bool), typeof(DragAndDropList));

        private int _currentItemIndex;

        private int _currentPositionIndex;

        private bool _originalPosition;

        #endregion

        #region EVENTS

        public event EventHandler OrderChanged = delegate { };

        #endregion

        #region CONSTRUCTOR

        public DragAndDropList()
        {
            InitializeComponent();
            //ContainerScrollView.Scrolled += OnContainerScrollViewScrolled;
        }

        private async void OnContainerScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            if (!IsEditMode)
                return;

            await TryScrollDownAsync();
        }

        private async Task TryScrollDownAsync()
        {
            if (IntersectsScrollDown())
            {

            }
                //await ContainerScrollView.ScrollToAsync(0, ContainerScrollView.ScrollY + 150, false);
        }

        #endregion

        #region PROPERTIES

        private bool IntersectsScrollDown()
        {
            var bottom = (Container.Children[_currentItemIndex] as Grid).Children[0].Bounds.Y;
            return ScrollDown.Bounds.Bottom > bottom && ScrollDown.Bounds.Top < bottom;
        }

        private bool IntersectsScrollUp =>
            ScrollUp.Bounds.Contains(Container.Children[_currentItemIndex].Bounds);

        public string ItemBackgroundColor
        {
            get => (string)GetValue(ItemBackgroundColorProperty);
            set => SetValue(ItemBackgroundColorProperty, value);
        }

        public bool IsEditMode
        {
            get => (bool)GetValue(IsEditModeProperty);
            set => SetValue(IsEditModeProperty, value);
        }

        public ObservableCollection<DragAndDropListItem> ItemsSource
        {
            get => (ObservableCollection<DragAndDropListItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        #endregion

        #region METHODS

        void Container_ChildAdded(System.Object sender, Xamarin.Forms.ElementEventArgs e)
        {
            if(e.Element is Grid child)
            {
                var animation = new Animation
                {
                    { 0, .5, new Animation(v => child.Scale = v, 1, 1.1) },
                    { .55, 1, new Animation(v => child.Scale = v, 1.1, 1) },

                };

                foreach(var c in Container.Children)
                {
                    if (c == child)
                        continue;

                    animation.Add(0, .5, new Animation(v => c.Scale = v, 1, .9));
                    animation.Add(.55, 1, new Animation(v => c.Scale = v, .9, 1));
                }

                animation.Commit(this, "sksk", 16, 500, easing: Easing.Linear);
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue != null && newValue is IEnumerable<DragAndDropListItem> items && bindable is DragAndDropList diz)
                BindableLayout.SetItemsSource(diz.Container, items);
        }

        private Grid _currentItem;

        void ParentGridPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (!IsEditMode)
                return;

            if (_currentItem != null && sender != _currentItem)
                return;

            if (!(sender is Grid parent))
                return;

            var element = parent.Children[0] as Grid;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    OnPanStarted(parent, element);
                    return;
                case GestureStatus.Running:
                    OnOngoingPan(element, parent, e);
                    return;
                default:
                    OnPanStopped(parent, element);
                    return;
            }
        }

        private void OnPanStarted(Grid parent, Grid element)
        {
            _currentItem = parent;

            for (int i = 0; i < Container.Children.Count; i++)
            {
                if (Container.Children[i] == parent)
                {
                    _currentItemIndex = i;

                    //parent.Scale = 1.2;
                    //parent.Opacity = .75;

                    /*
                    var animation = new Animation()
                    {
                        { 0, 1, new Animation(v => element.ScaleY = v, 1, 1.2) },
                        { 0, 1, new Animation(v => parent.ScaleY = v, 1, 1.2) }
                    };

                    animation.Commit(this, "asdas", easing: Easing.Linear);
                    */

                    Container.RaiseChild(parent);
                    return;
                }
            }
        }

        private void OnOngoingPan(Grid element, Grid parent, PanUpdatedEventArgs e)
        {
            element.TranslationY = e.TotalY;

            var startY = parent.Y + e.TotalY;
            var endY = startY + parent.Height;

            _originalPosition = true;

            var count = -1;

            foreach(var child in Container.Children)
            {
                //will always be last item and should not be compared to.
                if (child == parent) return;

                count++;

                if (count == _currentItemIndex)
                    count++;

                var childStartY = child.Y;
                var childEndY = childStartY + child.Height;

                //Debug.WriteLine($"item: {_currentItemIndex}; child: {count}; Y: {startY}; endY: {endY}; childY:{childStartY}; childEndY{childEndY}");

                if (startY < childEndY && count < _currentItemIndex)
                {
                    child.TranslationY = child.Height;

                    if(startY > childStartY)
                    {
                        _currentPositionIndex = count;
                        _originalPosition = false;
                    }
                }
                else if (endY > childStartY && count > _currentItemIndex)
                {
                    child.TranslationY = -child.Height;

                    if(endY < childEndY)
                    {
                        _currentPositionIndex = count;
                        _originalPosition = false;
                    }
                }
                else
                    child.TranslationY = 0;

                TryScrollDownAsync();

            }
        }

        private void OnPanStopped(Grid parent, Grid element)
        {
            var count = 0;

            // Reset visual stack order
            foreach (var child in Container.Children.ToList())
            {
                if (count == _currentItemIndex)
                    Container.RaiseChild(parent);

                if (child != parent)
                    Container.RaiseChild(child);

                child.TranslationY = 0;
                child.Scale = 1;
                child.Opacity = 1;

                count++;
            }

            element.TranslationY = 0;

            if (!_originalPosition)
                OnOrderChanged();

            _currentItem = null;
        }

        private void OnOrderChanged()
        {
            /*
             *  if (ItemsSource is ObservableCollection<DragAndDropListItem> items)
                {
                    var item = items[_currentItemIndex];

                    items.Remove(item);
                    items.Insert(_currentPositionIndex, item);

                    OrderChanged?.Invoke(this, EventArgs.Empty);
            *   };
            */
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                if (ItemsSource is ObservableCollection<DragAndDropListItem> items)
                {
                    var item = items[_currentItemIndex];

                    //items.Move(_currentItemIndex, _currentPositionIndex);
                    items.Remove(item);
                    items.Insert(_currentPositionIndex, item);

                    OrderChanged?.Invoke(this, EventArgs.Empty);
                };
                return false;
            });
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            //ContainerScrollView.InputTransparent = !ContainerScrollView.InputTransparent;
            IsEditMode = !IsEditMode;
        }

        #endregion
    }
}
