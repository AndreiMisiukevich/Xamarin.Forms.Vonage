using UIKit;
using Xamarin.Forms.Vonage.iOS.Renderers;
using Xamarin.Forms.Vonage.iOS.Services;

namespace Xamarin.Forms.Vonage.iOS
{
    public static class PlatformVonage
    {
        public static PlatformVonageService Current => CrossVonage.Current as PlatformVonageService;

        public static void Init(UIApplicationDelegate _)
        {
            VonagePublisherViewRenderer.Preserve();
            VonageSubscriberViewRenderer.Preserve();
            CrossVonage.Init<PlatformVonageService>();
        }
    }
}
