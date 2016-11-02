using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;
using Android.Content;
using Java.IO;
using Android.Graphics;
using Android.Provider;
using System.Collections.Generic;
using Android.Content.PM;
using Uri = Android.Net.Uri;

namespace iRecover.Droid
                  
{
	[Activity(Label = "ContactUsPage")]
	public class ContactUsPage : MvxActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			page();
			// Create your application here
		}
		public void page()
		{
			SetContentView(Resource.Layout.Contactus);
			// Get our button from the layout resource,
			// and attach an event to it

			Button button1 = FindViewById<Button>(Resource.Id.button1);

			button1.Click += (object sender, System.EventArgs e) =>
			{
				var email = new Intent(Android.Content.Intent.ActionSend);
				email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "aaalhayiti@gmail.com" });
				email.PutExtra(Intent.ExtraSubject, "");
				email.PutExtra(Intent.ExtraText, "");
				email.SetType("message/rfc822");
				StartActivity(email);
			};
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


			};

		}


	}
}
