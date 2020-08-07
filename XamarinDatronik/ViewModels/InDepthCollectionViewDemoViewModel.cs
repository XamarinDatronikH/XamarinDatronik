using System;
using System.Collections.Generic;
using System.Reflection;
using MvvmHelpers;
using Xamarin.Forms;
using XamarinDatronik.Models;

namespace XamarinDatronik.ViewModels
{
    public class InDepthCollectionViewDemoViewModel : BaseViewModel
    {
        #region FIELDS



        #endregion

        #region CONSTRUCTOR

        public InDepthCollectionViewDemoViewModel()
        {
            Colors = new List<ColorGroup>()
            {
                new ColorGroup("Blue", GetBlueColors()),
                new ColorGroup("Red", GetRedColors()),
                new ColorGroup("Green", GetGreenColors())
            };
        }

        #endregion

        #region PROPERTIES

        public List<ColorGroup> Colors { get; }

        #endregion

        #region METHODS

        private List<string> GetBlueColors()
        {
            var colors = new List<string>();

            for (var i = 1; i <= 180; i += 30)
            {
                colors.Add(Color.FromRgb(i / 2, i / 2, 150).ToHex());
                colors.Add(Color.FromRgb((i / 3) * 2, (i / 3) * 2, 200).ToHex());
                colors.Add(Color.FromRgb(i, i, 255).ToHex());
            }

            return colors;
        }

        private List<string> GetGreenColors()
        {
            var colors = new List<string>()
            {
                Color.FromRgb(0, 255, 0).ToHex(),
                Color.FromRgb(0, 200, 0).ToHex(),
                Color.FromRgb(0, 150, 0).ToHex()
            };

            for (var i = 50; i <= 200; i += 20)
            {
                colors.Add(Color.FromRgb(i, 255, i).ToHex());
                colors.Add(Color.FromRgb(i, 255, 0).ToHex());
                colors.Add(Color.FromRgb(0, 255, i).ToHex());
            }

            return colors;
        }

        private List<string> GetRedColors()
        {
            var colors = new List<string>()
            {
                Color.FromRgb(255, 0, 0).ToHex(),
                Color.FromRgb(200, 0, 0).ToHex(),
                Color.FromRgb(150, 0, 0).ToHex()
            };

            for (var i = 50; i <= 200; i += 20)
            {
                colors.Add(Color.FromRgb(255, i, i).ToHex());
                colors.Add(Color.FromRgb(255, i, 0).ToHex());
                colors.Add(Color.FromRgb(255, 0, i).ToHex());
            }

            return colors;
        }

        private List<string> GetAllColors()
        {
            var colors = new List<string>();

            foreach (var field in typeof(Color).GetFields(BindingFlags.Static | BindingFlags.Public))
                if (field != null && !String.IsNullOrEmpty(field.Name))
                    colors.Add(field.Name);

            return colors;
        }

        #endregion
    }
}
