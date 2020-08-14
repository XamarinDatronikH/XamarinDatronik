using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class ConverterDemo
    {
        public ConverterDemo()
        {
            InitializeComponent();
        }

        async void Label_PropertyChanging(System.Object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            var label = sender as Label;
            if (e.PropertyName.Equals("Text"))
            {
                await label.FadeTo(0, 600);
                await label.FadeTo(1, 600);
            }
        }
    }
}
