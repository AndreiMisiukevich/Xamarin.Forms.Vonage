using Com.Opentok.Android;

namespace Xamarin.Forms.Vonage.Android.Services
{
    internal sealed class VonageSessionOptions : Session.SessionOptions
    {
        public override bool IsCamera2Capable => true;

        public override bool UseTextureViews() => true;
    }
}
