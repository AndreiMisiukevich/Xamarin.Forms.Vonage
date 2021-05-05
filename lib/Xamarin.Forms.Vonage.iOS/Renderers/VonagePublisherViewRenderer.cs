using Xamarin.Forms;
using UIKit;
using Foundation;
using Xamarin.Forms.Vonage.iOS.Renderers;
using Xamarin.Forms.Vonage;

[assembly: ExportRenderer(typeof(VonagePublisherView), typeof(VonagePublisherViewRenderer))]
namespace Xamarin.Forms.Vonage.iOS.Renderers
{
    [Preserve(AllMembers = true)]
    public class VonagePublisherViewRenderer : VonageViewRenderer
    {
        public static void Preserve() { }

        protected override UIView GetNativeView() => PlatformVonage.Current.PublisherKit?.View;

        protected override void SubscribeResetControl() => PlatformVonage.Current.PublisherUpdated += ResetControl;

        protected override void UnsubscribeResetControl() => PlatformVonage.Current.PublisherUpdated -= ResetControl;
    }
}
