using System;
using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinDatronik.Droid.Renderers;
using XamarinDatronik.Views.CustomControls;

[assembly: ExportRenderer(typeof(TouchReactiveFrame), typeof(TouchFrameRenderer))]
namespace XamarinDatronik.Droid.Renderers
{
    public class TouchFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        private TouchReactiveFrame _xamarinFrame;

        public TouchFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                _xamarinFrame = e.NewElement as TouchReactiveFrame;
                Touch += TouchFrameRendererTouch;
            }
        }

        private void TouchFrameRendererTouch(object sender, TouchEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Event.Action);
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    _xamarinFrame.Opacity = 0.95;
                    _xamarinFrame.Scale = 0.95;
                    break;
                case MotionEventActions.Up:
                    _xamarinFrame.Opacity = 1;
                    _xamarinFrame.Scale = 1;
                    _xamarinFrame.ExecuteCommand();
                    break;
                case MotionEventActions.Cancel:
                    _xamarinFrame.Opacity = 1;
                    _xamarinFrame.Scale = 1;
                    break;
            }
        }
    }
}
