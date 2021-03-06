﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDatronik.Helpers;

namespace XamarinDatronik.Views
{
    public partial class CrossPlatformToastDemo
    {
        public CrossPlatformToastDemo()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var ip = await GetPublicIpAddress();

            CrossPlatformToastHelper.RequestToast($"Your ip is: {ip}", 5);
        }

        private async Task<string> GetPublicIpAddress()
        {
            await Task.Delay(2000);

            return "100.67.86.94";
        }
    }
}
