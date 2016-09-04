using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace iRecover_Provider
{
    [Activity(Label = "iRecover_Provider", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button1 = FindViewById<Button>(Resource.Id.btnCall);
            Button button2 = FindViewById<Button>(Resource.Id.btnWebsite);
            Button button3 = FindViewById<Button>(Resource.Id.btnEmail);
            Button button4 = FindViewById<Button>(Resource.Id.btnGPS);

            
            button1.Click += (Object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Pressing this button will start a call to the provider", ToastLength.Long).Show();
            };

            button2.Click += (Object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Pressing this button will open the provider website", ToastLength.Long).Show();
            };

            button3.Click += (Object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Pressing this button will open email page to contact provider", ToastLength.Long).Show();
            };

            button4.Click += (Object sender, EventArgs e) =>
            {
                Toast.MakeText(this, "Pressing this button will open GPS application with directions to provider", ToastLength.Long).Show();
            }; 
        }
    }
}

