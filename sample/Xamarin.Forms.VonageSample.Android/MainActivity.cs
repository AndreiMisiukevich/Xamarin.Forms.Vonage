using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Permission = Android.Content.PM.Permission;
using Xamarin.Forms.Vonage.Android;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.VonageSample.Droid
{
    [Activity(Label = "Xamarin.Forms.VonageSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        LaunchMode = LaunchMode.SingleTop,
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            PlatformVonage.Init(this);
            Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}