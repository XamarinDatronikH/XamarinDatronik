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

        private const string ContentPresenterName = "Content";

        private Slider _widthSlider;

        private Slider _heightSlider;

        private Frame _contentContainer;

        private ContentPresenter _contentPresenter;

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
                _heightSlider = GetTemplateChild(HeightSliderName) as Slider;
                _contentPresenter = GetTemplateChild(ContentPresenterName) as ContentPresenter;
            }

            if (_contentContainer != null && (_widthSlider ?? _heightSlider) != null)
            {
                var verticalMargin = (_contentContainer.Height / 2) * (_heightSlider.Value / 100);
                var horizontalMargin = (_contentContainer.Width / 2) * (_widthSlider.Value / 100);

                _contentPresenter.Margin = new Thickness(horizontalMargin, verticalMargin);
            }
        }

        #endregion
    }
}
