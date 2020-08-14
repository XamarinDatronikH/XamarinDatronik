using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinDatronik.Views.CustomControls
{
    public partial class ResizableContainer : ContentView
    {
        #region FIELDS

        private const string ContentName = "ContentContainer";

        private const string WidthSliderName = "WidthSlider";

        private const string HeightSliderName = "HeightSlider";

        private ContentPresenter _contentPresenter;

        private Slider _widthSlider;

        private Slider _heightSlider;

        private Frame _contentContainer;

        #endregion

        #region CONSTRUCTOR

        public ResizableContainer()
        {
            InitializeComponent();
        }

        #endregion

        #region PROPERTIES



        #endregion

        #region METHODS

        void SliderChanged(object sender, ValueChangedEventArgs e)
        {
            if(_contentContainer == null)
            {
                _contentContainer = GetTemplateChild(ContentName) as Frame;

                _widthSlider = GetTemplateChild(WidthSliderName) as Slider;
                _widthSlider.Maximum = Width / 2;
                _widthSlider.Minimum = 5;

                _heightSlider = GetTemplateChild(HeightSliderName) as Slider;
                _heightSlider.Maximum = Height / 2;
                _heightSlider.Minimum = 5;
            }

            if (_contentContainer != null)
                _contentContainer.Margin = new Thickness(_widthSlider.Value, _heightSlider.Value);
        }

        #endregion
    }
}
