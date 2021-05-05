using System;
using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Vonage;

namespace Xamarin.Forms.VonageSample
{
    public partial class ChatRoomPage : ContentPage
    {
        private bool _isRendererSet;

        public ChatRoomPage()
        {
            InitializeComponent();
            CrossVonage.Current.MessageReceived += OnMessageReceived;
        }

        private void OnEndCall(object sender, EventArgs e)
        {
            CrossVonage.Current.EndSession();
            CrossVonage.Current.MessageReceived -= OnMessageReceived;
            Navigation.PopAsync();
        }

        private void OnMessage(object sender, EventArgs e)
            => CrossVonage.Current.TrySendMessage($"Path.GetRandomFileName: {Path.GetRandomFileName()}");

        private void OnSwapCamera(object sender, EventArgs e)
            => CrossVonage.Current.CycleCamera();

        void OnShareScreen(object sender, EventArgs e)
        {
            CrossVonage.Current.PublisherVideoType = CrossVonage.Current.PublisherVideoType == VonagePublisherVideoType.Camera
                ? VonagePublisherVideoType.Screen
                : VonagePublisherVideoType.Camera;
        }

        private void OnMessageReceived(string message)
            => DisplayAlert("Random message received", message, "OK");

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == "Renderer")
            {
                _isRendererSet = !_isRendererSet;
                if(!_isRendererSet)
                {
                    OnEndCall(this, EventArgs.Empty);
                }
            }
        }
    }
}
