using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class DynamicCircularImage : ContentView
    {
        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
            nameof(IconSource), typeof(string), typeof(DynamicCircularImage));

        public DynamicCircularImage()
        {
            InitializeComponent();
        }

        public string IconSource
        {
            get => (string)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        void ParentContainerSizeChanged(object sender, EventArgs e)
        {
            var width = Width - Padding.HorizontalThickness;
            var height = Height - Padding.VerticalThickness;

            if (width < 1 || height < 1) return;

            if (width > height)
            {
                MainFrame.WidthRequest = height;
                MainFrame.HorizontalOptions = LayoutOptions.Center;
                MainFrame.VerticalOptions = LayoutOptions.Fill;
                MainFrame.CornerRadius = (float)height / 2;
            }
            else if (height > width)
            {
                MainFrame.HeightRequest = width;
                MainFrame.VerticalOptions = LayoutOptions.Center;
                MainFrame.HorizontalOptions = LayoutOptions.Fill;
                MainFrame.CornerRadius = (float)width / 2;
            }
            else
                MainFrame.CornerRadius = (float)width / 2;
        }
    }
}