using Xamarin.Forms;
using Android.Content;
using AView = Android.Views.View;
using Android.Runtime;
using System.ComponentModel;
using System.Linq;
using SystemIntPtr = System.IntPtr;
using AndroidRuntimeJniHandleOwnership = Android.Runtime.JniHandleOwnership;
using Xamarin.Forms.Vonage.Android.Renderers;
using Xamarin.Forms.Vonage;

[assembly: ExportRenderer(typeof(VonageSubscriberView), typeof(VonageSubscriberViewRenderer))]
namespace Xamarin.Forms.Vonage.Android.Renderers
{
    [Preserve(AllMembers = true)]
    public class VonageSubscriberViewRenderer : VonageViewRenderer
    {
        public VonageSubscriberViewRenderer(Context context) : base(context)
        {
        }

#pragma warning disable
        public VonageSubscriberViewRenderer(SystemIntPtr p0, AndroidRuntimeJniHandleOwnership p1) : this(PlatformVonage.Activity)
        {
        }
#pragma warning restore

        public static void Preserve() { }

        protected VonageSubscriberView VonageSubscriberView => VonageView as VonageSubscriberView;

        protected override AView GetNativeView()
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
            switch (e.PropertyName)
            {
                case nameof(VonageSubscriberView.StreamId):
                    ResetControl();
                    break;
            }
        }
    }
}