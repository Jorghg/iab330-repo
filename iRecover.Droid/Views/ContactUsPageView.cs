using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;
using Android.Content;


namespace iRecover.Droid.Views
{
    [Activity(Label = "iRecover",  Icon = "@drawable/icon")]
    public class ContactUsView : MvxActivity
    {

        /* protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Contactus);
            //contactUs();
        } 

        private void contactUs()
        {
            //SetContentView(Resource.Layout.Contactus);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button2 = FindViewById<Button>(Resource.Id.button2);

            button2.Click += (object sender, System.EventArgs e) =>
            {
                // make a call to the provider 
                Android.Net.Uri number = Android.Net.Uri.Parse("tel:" + "0431015184");
                Intent dialintent = new Intent(Intent.ActionView, number);
                StartActivity(dialintent);
            };

            Button button3 = FindViewById<Button>(Resource.Id.button3);

            button3.Click += (object sender, System.EventArgs e) =>
            {
                // Find us button is to allowed users to find one of Soncorp branches
                Android.Net.Uri gegoUri = Android.Net.Uri.Parse("geo:27.4705939,153.0301227");
                Intent mapIntent = new Intent(Intent.ActionView, gegoUri);
                StartActivity(mapIntent);

                //Toast.MakeText(this, "Find us Function allws users to find the Location of their provider", ToastLength.Short).Show();
            };

            Button searchProvider = FindViewById<Button>(Resource.Id.searchProvider);
            searchProvider.Click += (object sender, System.EventArgs e) => {
                SetContentView(Resource.Layout.SearchProvider);
            };
        } */
    } // END PUBLIC CLASS
} // END NAMESPACE