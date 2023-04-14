# Vonage library for Xamarin.Forms
https://tokbox.com/
https://www.vonage.com/

## Setup
* Available on NuGet: [Xamarin.Forms.Vonage](http://www.nuget.org/packages/Xamarin.Forms.Vonage) [![NuGet](https://img.shields.io/nuget/v/Xamarin.Forms.Vonage.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.Forms.Vonage)

|Platform|Version|
| ------------------- | ------------------- |
|Xamarin.iOS|9.0+|
|Xamarin.Android|19+|

* Add ```Xamarin.Forms.Vonage``` nuget package to Xamarin.Forms shared project and to all platform-specific projects (iOS & Android)

### iOS

* Set "Minimum system version" to "9.0" or higher in Info.plist (!)

* Setup Vonage by calling ```PlatformVonage.Init(this)``` in AppDelegate
```csharp
public partial class AppDelegate : FormsApplicationDelegate
{
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        PlatformVonage.Init(this); // Setup Vonage
        Forms.Init();
        LoadApplication(new App());
        return base.FinishedLaunching(app, options);
    }
}
```

* Add messages for requesting permissions to Info.plist file
```xml
	<key>NSCameraUsageDescription</key>
	<string>Use camera to start video call</string>
	<key>NSMicrophoneUsageDescription</key>
	<string>Use microphone to start video call</string>
```

### Android

* Setup Vonage by calling ```PlatformVonage.Init(this)``` in MainActivity
```csharp
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    PlatformVonage.Init(this); // Setup Vonage
    Forms.Init(this, savedInstanceState);
    LoadApplication(new App());
}
```

* Add permissions to Manifest file.
```xml
	<uses-permission android:name="android.permission.RECORD_AUDIO" />
	<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
	<uses-permission android:name="android.permission.CAMERA" />
	<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
	<uses-permission android:name="android.permission.INTERNET" />
	<uses-permission android:name="android.permission.MODIFY_AUDIO_SETTINGS" />
	<uses-permission android:name="android.permission.BLUETOOTH" />
	<uses-permission android:name="android.permission.READ_PHONE_STATE" />
    	<uses-permission android:name="android.permission.READ_MEDIA_AUDIO" />
	<uses-permission android:name="android.permission.READ_MEDIA_IMAGES" />
	<uses-permission android:name="android.permission.READ_MEDIA_VIDEO" />
```

* checking for permission "WRITE_EXTERNAL_STORAGE" will return false from Android13 and not required.
* add READ_MEDIA_AUDIO, READ_MEDIA_IMAGES, READ_MEDIA_VIDEO from Android 13

## Samples

**SAMPLE VIDEO: https://twitter.com/Andrik_Just4Fun/status/1151799321223995392**

Please open ```Xamarin.Forms.Vonage.sln``` if you want learn more about this library or run sample app

Use **CrossVonage.Current** for accessing Vonage service.

Full api you can find here: https://github.com/AndreiMisiukevich/Xamarin.Forms.Vonage/blob/main/lib/Xamarin.Forms.Vonage/IVonageService.cs

Firstly you should set up Vonage
```csharp
CrossVonage.Current.ApiKey = "{YOUR_API_KEY}"; // Vonage API key from your account
CrossVonage.Current.SessionId = "{YOUR_SESSION_ID}"; // Id of session for connecting
CrossVonage.Current.UserToken = "{YOUR_USER_TOKEN}"; // User's token
```

Then check wheather you have enough permissions for starting a call and if everything is fine it will start a session.
```csharp
if(!CrossVonage.Current.TryStartSession())
{
    return;
}
//Session is starting, you may show Chat Page
```

Use **VonagePublisherView** and **VonageSubscriberView** for showing video from your camera and for recieving video from another chat participant. Just put them to any laouyt you prefer. When session is started, they will recieve video/audio streams.

```xaml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vonage="clr-namespace:Xamarin.Forms.Vonage;assembly=Xamarin.Forms.Vonage"
             x:Class="Xamarin.Forms.VonageSample.ChatRoomPage"
             BackgroundColor="White">
    
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="80" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        
        <vonage:VonageSubscriberView Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="3" />
        <vonage:VonagePublisherView Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="3" />
        
    </Grid>
</ContentPage>
```
Check source code for more info or just ask me =)

## License
The MIT License (MIT) see [License file](LICENSE)

## Contribution
Feel free to create issues and PRs 😃
