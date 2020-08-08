using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinDatronik.Helpers;

namespace XamarinDatronik.Views
{
    public partial class DynamicCircularImageDemo
    {
        public DynamicCircularImageDemo()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            CrossPlatformToastHelper.RequestToast("tesgiytuausutatduuatstduttesgiytuausutatduuatstduttesgiytuausutatduuatstdut", 4);
        }
    }
}
