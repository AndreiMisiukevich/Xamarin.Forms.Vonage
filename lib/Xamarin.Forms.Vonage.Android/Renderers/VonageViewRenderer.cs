using Xamarin.Forms.Platform.Android;
using Android.Content;
using AView = Android.Views.View;
using Android.Runtime;

namespace Xamarin.Forms.Vonage.Android.Renderers
{
    [Preserve(AllMembers = true)]
    public abstract class VonageViewRenderer : ViewRenderer
    {
        private AView _defaultView;

        protected VonageViewRenderer(Context context) : base(context)
        {
        }

        protected VonageView VonageView => Element as VonageView;

        protected virtual AView DefaultView => _defaultView ??= new AView(Context);

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            if (e.OldElement != null)
            {
                UnsubscribeResetControl();
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    ResetControl();
                }
                SubscribeResetControl();
            }
            base.OnElementChanged(e);
        }

        protected void ResetControl()
        {
            var view = GetNativeView();
            VonageView?.SetIsVideoViewRunning(view != null);
            view ??= DefaultView;
            if (Control != view)
            {
                view.RemoveFromParent();
                SetNativeControl(view);
            }
        }

        protected abstract AView GetNativeView();

        protected abstract void SubscribeResetControl();

        protected abstract void UnsubscribeResetControl();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                using (_defaultView)
                {
                    UnsubscribeResetControl();
                }
            }
        }
    }
}