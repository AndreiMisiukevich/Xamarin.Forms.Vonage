using Android.App;
using Xamarin.Forms.Vonage.Android.Renderers;
using Xamarin.Forms.Vonage.Android.Services;

namespace Xamarin.Forms.Vonage.Android
{
    public static class PlatformVonage
    {
        internal static Activity Activity { get; private set; }

        public static PlatformVonageService Current => CrossVonage.Current as PlatformVonageService;

        public static void Init(Activity activity)
        {
            Activity = activity;
            VonagePublisherViewRenderer.Preserve();
            VonageSubscriberViewRenderer.Preserve();
            CrossVonage.Init<PlatformVonageService>();
        }
    }
}
