using Xamarin.Forms.Vonage;

namespace Xamarin.Forms.VonageSample
{
    public class StartPage : ContentPage
    {
        public StartPage()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Button
                    {
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Text = "CLICK TO CHAT",
                        Command = new Command(() => {
                            if(!CrossVonage.Current.TryStartSession())
                            {
                                return;
                            }
                            Navigation.PushAsync(new ChatRoomPage());
                        })
                    }
                }
            };
        }
    }
}