using System;
using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinDatronik.Droid.Renderers;
using XamarinDatronik.Views.CustomControls;

[assembly: ExportRenderer(typeof(TouchReactiveGrid), typeof(TouchGridRenderer))]
namespace XamarinDatronik.Droid.Renderers
{
    public class TouchGridRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<Grid, Android.Views.View>
    {
        private TouchReactiveGrid _xamarinGrid;

        public TouchGridRenderer(Context context) : base (context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Grid> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                _xamarinGrid = e.NewElement as TouchReactiveGrid;
                Touch += TouchGridRendererTouch;
            }
        }

        private void TouchGridRendererTouch(object sender, TouchEventArgs e)
        {
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    _xamarinGrid.Opacity = 0.6;
                    _xamarinGrid.Scale = 0.97;
                    break;
                case MotionEventActions.Up:
                    _xamarinGrid.Opacity = 1;
                    _xamarinGrid.Scale = 1;
                    _xamarinGrid.ExecuteCommand();
                    break;
                case MotionEventActions.Cancel:
                    _xamarinGrid.Opacity = 1;
                    _xamarinGrid.Scale = 1;
                    break;
            }
        }
    }
}
