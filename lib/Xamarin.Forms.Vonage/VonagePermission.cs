using System;

namespace Xamarin.Forms.Vonage
{
    [Flags]
    public enum VonagePermission
    {
        /// <summary>
        /// Disable all permissions.
        /// </summary>
        None = 0,

        /// <summary>
        /// If your app does not use the default video capturer and does not access the camera, you can remove this permission.
        /// </summary>
        Camera = 1,

        /// <summary>
        /// If your app does not does not write to external storage, you can remove this permission.
        /// </summary>
        /// this is obsolete with Android 13, will always get false
        WriteExternalStorage = 2,

        /// <summary>
        /// If your app does not use the default audio device and does not access the microphone, you can remove this permission.
        /// </summary>
        RecordAudio = 4,

        /// <summary>
        /// If your app does not use the default audio device and does not access the microphone, you can remove this permission.
        /// </summary>
        ModifyAudioSettings = 8,

        /// <summary>
        /// The default audio device supports Bluetooth audio. If your app does not use the default audio device and does not use Bluetooth, you can remove this permission.
        /// </summary>
        Bluetooth,
        ReadMediaAudio,
        ReadMediaImages,
        ReadMediaVideo,

        /// <summary>
        /// Camera & WriteExternalStorage & RecordAudio & ModifyAudioSettings & Bluetooth
        /// </summary>
        //All = Camera | WriteExternalStorage | RecordAudio | ModifyAudioSettings | Bluetooth | ReadMediaAudio | ReadMediaImages | ReadMediaVideo
        All = Camera | RecordAudio | ModifyAudioSettings | Bluetooth | ReadMediaAudio | ReadMediaImages | ReadMediaVideo
    }
}
