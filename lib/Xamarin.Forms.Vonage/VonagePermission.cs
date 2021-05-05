using System;

namespace Xamarin.Forms.Vonage
{
    [Flags]
    public enum VonagePermission
    {
        None = 0,
        Camera = 1,
        WriteExternalStorage = 2,
        RecordAudio = 4,
        ModifyAudioSettings = 8,
        All = Camera | WriteExternalStorage | RecordAudio | ModifyAudioSettings
    }
}
