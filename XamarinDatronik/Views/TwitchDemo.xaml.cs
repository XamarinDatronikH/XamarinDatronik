using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinDatronik.Views
{
    public partial class TwitchDemo
    {
        public TwitchDemo()
        {
            InitializeComponent();
        }

        void ScrollViewSizeChanged(System.Object sender, System.EventArgs e)
        {
            if(sender is ScrollView sv)
            {
                InitialListContent.WidthRequest = sv.Width;
                HiddenListContent.WidthRequest = sv.Width;
            }
        }

        void ScrollViewScrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            var percentage = e.ScrollX / InitialListContent.Width;
            TabIndicator.TranslationX = TabIndicator.Width * percentage;
        }
    }
}
