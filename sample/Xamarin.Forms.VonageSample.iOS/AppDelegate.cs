using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Vonage.iOS;

namespace Xamarin.Forms.VonageSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            PlatformVonage.Init(this);
            Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
