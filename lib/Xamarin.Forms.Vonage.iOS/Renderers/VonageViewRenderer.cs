using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;

namespace Xamarin.Forms.Vonage.iOS.Renderers
{
    [Preserve(AllMembers = true)]
    public abstract class VonageViewRenderer : ViewRenderer
    {
        private UIView _defaultView;

        protected VonageView VonageView => Element as VonageView;

        protected virtual UIView DefaultView => _defaultView ??= new UIView();

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
                view.RemoveFromSuperview();
                SetNativeControl(view);
            }
        }

        protected abstract UIView GetNativeView();

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
                _defaultView = null;
            }
        }
    }
}