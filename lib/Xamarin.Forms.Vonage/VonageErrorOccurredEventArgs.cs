using System;
namespace Xamarin.Forms.Vonage
{
    public sealed class VonageErrorOccurredEventArgs : EventArgs
    {
        public VonageErrorOccurredEventArgs(string message)
            => Message = message;

        public string Message { get; }
    }
}
