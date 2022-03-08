using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Xamarin.Forms.Vonage
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class BaseVonageService : IVonageService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event Action<string> Error;

        public event Action<string> MessageReceived;

        public event EventHandler<VonageErrorOccurredEventArgs> ErrorOccurred;

        public event EventHandler<VonageTextMessageReceivedEventArgs> TextMessageReceived;

        public event NotifyCollectionChangedEventHandler StreamIdCollectionChanged;

        public abstract ReadOnlyObservableCollection<string> StreamIdCollection { get; }

        private readonly object _propertiesLocker = new object();

        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public VonagePermission Permissions
        {
            get => GetValue(VonagePermission.All);
            set => SetValue(value);
        }

        public VonagePublisherVideoType PublisherVideoType
        {
            get => GetValue(VonagePublisherVideoType.Camera);
            set => SetValue(value);
        }

        public VonageVideoScaleStyle PublisherVideoScaleStyle
        {
            get => GetValue(VonageVideoScaleStyle.Fill);
            set => SetValue(value);
        }

        public VonageVideoScaleStyle SubscriberVideoScaleStyle
        {
            get => GetValue(VonageVideoScaleStyle.Fill);
            set => SetValue(value);
        }

        public bool IsVideoPublishingEnabled
        {
            get => GetValue(true);
            set => SetValue(value);
        }

        public bool IsAudioPublishingEnabled
        {
            get => GetValue(true);
            set => SetValue(value);
        }

        public bool IsVideoSubscriptionEnabled
        {
            get => GetValue(true);
            set => SetValue(value);
        }

        public bool IsAudioSubscriptionEnabled
        {
            get => GetValue(true);
            set => SetValue(value);
        }

        public string ApiKey
        {
            get => GetValue(string.Empty);
            set => SetValue(value);
        }

        public string SessionId
        {
            get => GetValue(string.Empty);
            set => SetValue(value);
        }

        public string UserToken
        {
            get => GetValue(string.Empty);
            set => SetValue(value);
        }

        public bool IsSessionStarted
        {
            get => GetValue(false);
            set => SetValue(value);
        }

        public bool IsPublishingStarted
        {
            get => GetValue(false);
            set => SetValue(value);
        }

        public VonagePublisherCameraResolution PublisherCameraResolution
        {
            get => GetValue(VonagePublisherCameraResolution.High);
            set => SetValue(value);
        }

        public string PublisherName
        {
            get => GetValue("XamarinVonage");
            set => SetValue(value);
        }

        public abstract bool CheckPermissions();

        public abstract bool TryStartSession();

        public abstract bool TrySendMessage(string message, string messageType);

        public abstract void EndSession();

        public abstract void CycleCamera();

        protected void RaiseErrorOccurred(string message)
        {
            ErrorOccurred?.Invoke(this, new VonageErrorOccurredEventArgs(message));
#pragma warning disable
            Error?.Invoke(message);
#pragma warning restore
        }

        protected void RaiseMessageReceived(string message, string messageType)
        {
            TextMessageReceived?.Invoke(this, new VonageTextMessageReceivedEventArgs(message, messageType));
#pragma warning disable
            MessageReceived?.Invoke(message);
#pragma warning restore
        }

        protected void OnSubscriberStreamIdsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            => StreamIdCollectionChanged?.Invoke(sender, e);

        private T GetValue<T>(T defaultValue, [CallerMemberName] string name = null)
        {
            lock (_propertiesLocker)
            {
                return (T)(_properties.TryGetValue(name, out object value) ? value : defaultValue);
            }
        }

        private void SetValue<T>(T value, [CallerMemberName] string name = null)
        {
            lock (_propertiesLocker)
            {
                if (_properties.ContainsKey(name) && EqualityComparer<T>.Default.Equals((T)_properties[name], value))
                {
                    return;
                }
                _properties[name] = value;
            }
            RaisePropertyChanged(name);
        }

        private void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
