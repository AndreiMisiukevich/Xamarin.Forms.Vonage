using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Xamarin.Forms.Vonage
{
    [EditorBrowsable(EditorBrowsableState.Always)]
    public interface IVonageService : INotifyPropertyChanged
    {
        [Obsolete("Please use ErrorOccurred event instead")]
        public event Action<string> Error;

        [Obsolete("Please use TextMessageReceived event instead")]
        public event Action<string> MessageReceived;

        public event EventHandler<VonageErrorOccurredEventArgs> ErrorOccurred;

        public event EventHandler<VonageTextMessageReceivedEventArgs> TextMessageReceived;

        event NotifyCollectionChangedEventHandler StreamIdCollectionChanged;

        ReadOnlyObservableCollection<string> StreamIdCollection { get; }

        VonagePermission Permissions { get; set; }

        VonagePublisherVideoType PublisherVideoType { get; set; }

        VonageVideoScaleStyle PublisherVideoScaleStyle { get; set; }

        VonageVideoScaleStyle SubscriberVideoScaleStyle { get; set; }

        bool IsVideoPublishingEnabled { get; set; }

        bool IsAudioPublishingEnabled { get; set; }

        bool IsVideoSubscriptionEnabled { get; set; }

        bool IsAudioSubscriptionEnabled { get; set; }

        string ApiKey { get; set; }

        string SessionId { get; set; }

        string UserToken { get; set; }

        string PublisherName { get; set; }

        bool IsSessionStarted { get; set; }

        bool IsPublishingStarted { get; set; }

        VonagePublisherCameraResolution PublisherCameraResolution { get; set; }

        bool CheckPermissions();

        bool TryStartSession();

        bool TrySendMessage(string message, string messageType = null);

        void EndSession();

        void CycleCamera();
    }
}