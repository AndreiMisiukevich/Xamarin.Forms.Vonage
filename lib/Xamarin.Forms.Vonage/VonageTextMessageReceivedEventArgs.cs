using System;

namespace Xamarin.Forms.Vonage
{
    public sealed class VonageTextMessageReceivedEventArgs : EventArgs
    {
        public VonageTextMessageReceivedEventArgs(string message, string messageType)
        {
            Message = message;
            MessageType = messageType;
        }

        public string Message { get; }

        public string MessageType { get; }
    }
}
