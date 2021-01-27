using System;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Android.Gms.Common;
using System.Collections.Generic;

namespace MobeyeApplication.Droid
{
    [Activity(Label = "MobeyeApplication", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;
        TextView msgText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Log.Debug(TAG, "google app id: " + GetString(Resource.String.google_app_id));
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FirebaseOptions options = new FirebaseOptions.Builder()
            .SetApplicationId("1:753403340611:android:10e7b58cda81f244f7b1f6")
            .SetApiKey("AIzaSyDKOCY9oU9_3QKSyhWhpICf1H3Aj9-FUZI")
            .SetGcmSenderId("753403340611")
            .Build();

            bool hasBeenInitialized = false;
            IList<FirebaseApp> firebaseApps = FirebaseApp.GetApps(Application.Context);
            foreach (FirebaseApp app in firebaseApps)
            {
                if (app.Name.Equals(FirebaseApp.DefaultAppName))
                {
                    hasBeenInitialized = true;
                    FirebaseApp firebaseApp = app;
                }
            }

            if (!hasBeenInitialized)
            {
                FirebaseApp firebaseApp = FirebaseApp.InitializeApp(Application.Context, options);
            }
            LoadApplication(new App());

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }
            IsPlayServicesAvailable();
            CreateNotificationChannel();

        }
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Debug(TAG, GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Debug(TAG, "This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                Log.Debug(TAG, "Google Play Services is available.");
                return true;
            }
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}