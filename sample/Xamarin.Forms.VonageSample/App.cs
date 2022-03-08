using Xamarin.Forms.Vonage;

namespace Xamarin.Forms.VonageSample
{
    public class App : Application
    {
        public App()
            => MainPage = new NavigationPage(new StartPage());

        protected override void OnStart()
        {
            CrossVonage.Current.ApiKey = "46727832";
            CrossVonage.Current.UserToken = "T1==cGFydG5lcl9pZD00NjcyNzgzMiZzaWc9ZWRmNjdlYjQ5MmQ5MWI2ZjhhODA1M2I5Y2EzZjBkMWMxMTI1NjAxYjpzZXNzaW9uX2lkPTFfTVg0ME5qY3lOemd6TW41LU1UVTRPRGszTlRJME1qQTROMzVQV2pSNE1uZHlhbGR2TTJGU05VdHRORTlhUWxGWllWWi1mZyZjcmVhdGVfdGltZT0xNTg4OTc1MzE5Jm5vbmNlPTAuNTc4NDIwMzQ3NTU0NDQwNSZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTg4OTc4OTE5JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";
            CrossVonage.Current.SessionId = "1_MX40NjcyNzgzMn5-MTU4ODk3NTI0MjA4N35PWjR4MndyaldvM2FSNUttNE9aQlFZYVZ-fg";
            CrossVonage.Current.ErrorOccurred += (sender, args) => MainPage.DisplayAlert("ERROR", args.Message, "OK");
        }
    }
}
