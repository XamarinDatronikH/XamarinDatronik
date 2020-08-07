using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace XamarinDatronik.Views
{
    public partial class ShapesDemo : ContentPage
    {
        public ShapesDemo()
        {
            InitializeComponent();
        }

        void PanGestureRecognizer_PanUpdated(System.Object sender, Xamarin.Forms.PanUpdatedEventArgs e)
        {
            var path = sender as Grid;
            var child = path.Children[0] as Frame;

            child.TranslationY = e.TotalY;
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if(sender is Grid g)
            {
                if (g.Children[0] == childOne)
                    g.RaiseChild(childOne);
                else
                    g.RaiseChild(childTwo);
            }
        }

        void PanGestureRecognizer_PanUpdated_1(System.Object sender, Xamarin.Forms.PanUpdatedEventArgs e)
        {
            if(sender is Grid g)
            {
                childOne.TranslationY = e.TotalY;

                if (e.TotalY < 100)
                    MainGrid.Children.Remove(g);
            }
        }
    }
}
