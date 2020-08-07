using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinDatronik.Droid.Renderers;
using XamarinDatronik.Views;

[assembly: ExportRenderer(typeof(GradientBackgroundView), typeof(GradientBackgroundViewRenderer))]
namespace XamarinDatronik.Droid.Renderers
{
    public class GradientBackgroundViewRenderer : ViewRenderer
    {
        public GradientBackgroundViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                CreateNativeControl();
        }

        protected override Android.Views.View CreateNativeControl()
        {
            var nativeView = new Android.Views.View(Context);

            var gradient = new GradientDrawable();

            gradient.SetColors(new int[]
            {
                    Xamarin.Forms.Color.LightGray.ToAndroid(),
                    Xamarin.Forms.Color.Black.ToAndroid()
            });

            nativeView.Background = gradient;

            return nativeView;
        }
    }
}
