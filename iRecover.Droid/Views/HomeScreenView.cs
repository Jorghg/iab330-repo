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

namespace iRecover.Droid.Views
{
	
	[Activity(Label = "iRecover", MainLauncher = true, Icon = "@drawable/icon")]
	public class HomeScreenView : MvxActivity
	{


		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			homePage();

		}
		private void homePage()
		{

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.HomeScreenView);
			ImageView img = FindViewById<ImageView>(Resource.Id.mainImage);
			img.SetImageResource(Resource.Drawable.suncorplogo);

			Button ContactUs = FindViewById<Button>(Resource.Id.contactBtn);

			ContactUs.Click += (object sender, System.EventArgs e) =>
			{
				
				var intent = new Intent(this, typeof(ContactUsPage));
				StartActivity(intent);
			

			};

			Button claimbtn = FindViewById<Button>(Resource.Id.claimBtn);
		
			claimbtn.Click += (object sender, System.EventArgs e) =>
			{
				var intent = new Intent(this, typeof(MakeClaimPage));
				StartActivity(intent);

			}; 
			Button usagebtn = FindViewById<Button>(Resource.Id.usageBtn);

			usagebtn.Click += (object sender, System.EventArgs e) =>
			{
				
				MyUsage();
			};

			Button historybtn = FindViewById<Button>(Resource.Id.HistoryBtn);

			historybtn.Click += (object sender, System.EventArgs e) =>
			{

				History();
			};


		}

		public override void OnBackPressed()
		{
				homePage();
		}


		private void MyUsage()
		{
				SetContentView(Resource.Layout.Contactus);
		 //Get our button from the layout resource,
		 //and attach an event to it

		}

		private void History()
		{
			SetContentView(Resource.Layout.Contactus);
		 
		}
	}


}