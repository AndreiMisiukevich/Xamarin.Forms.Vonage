using Xamarin.Forms;
using UIKit;
using Foundation;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms.Vonage.iOS.Renderers;
using Xamarin.Forms.Vonage;

[assembly: ExportRenderer(typeof(VonageSubscriberView), typeof(VonageSubscriberViewRenderer))]
namespace Xamarin.Forms.Vonage.iOS.Renderers
{
    [Preserve(AllMembers = true)]
    public class VonageSubscriberViewRenderer : VonageViewRenderer
    {
        public static void Preserve() { }

        protected VonageSubscriberView VonageSubscriberView => VonageView as VonageSubscriberView;

        protected override UIView GetNativeView()
        {
            var streamId = VonageSubscriberView?.StreamId;
            var subscribers = PlatformVonage.Current.Subscribers;
            return (streamId != null
                ? subscribers.FirstOrDefault(x => x.Stream?.StreamId == streamId)
                : subscribers.FirstOrDefault())?.View;
        }

        protected override void SubscribeResetControl() => PlatformVonage.Current.SubscriberUpdated += ResetControl;

        protected override void UnsubscribeResetControl() => PlatformVonage.Current.SubscriberUpdated -= ResetControl;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch(e.PropertyName)
            {
                case nameof(VonageSubscriberView.StreamId):
                    ResetControl();
                    break;
            }
        }
    }
}
