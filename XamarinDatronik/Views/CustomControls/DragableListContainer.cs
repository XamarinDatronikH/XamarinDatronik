using System;
using Xamarin.Forms;

namespace XamarinDatronik.Views
{ 
    public class DragableListContainer : Grid
    {
        public static readonly BindableProperty ListObjectProperty = BindableProperty.Create(
            nameof(ListObject), typeof(object), typeof(DragableListContainer));

        public object ListObject
        {
            get => GetValue(ListObjectProperty);
            set => SetValue(ListObjectProperty, value);
        }
    }
}
