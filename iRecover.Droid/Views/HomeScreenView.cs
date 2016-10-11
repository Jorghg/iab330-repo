using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;
using Android.Content;


namespace iRecover.Droid.Views
{
	[Activity(Label = "iRecover", MainLauncher = true, Icon = "@drawable/icon")]
	public class HomeScreenView : MvxActivity
	{
		//int count = 1;

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
			//Toast.MakeText(this, ContactkUs.Text, ToastLength.Short).Show();
			ContactUs.Click += (object sender, System.EventArgs e) =>
			{
				//Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
				//ContactUsActivity cta = new ContactUsActivity( savedInstanceState);
				contactusPage();
			};

			Button claimbtn = FindViewById<Button>(Resource.Id.claimBtn);
			//Toast.MakeText(this, ContactkUs.Text, ToastLength.Short).Show();
			claimbtn.Click += (object sender, System.EventArgs e) =>
			{
				//Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
				//ContactUsActivity cta = new ContactUsActivity( savedInstanceState);
				makeaclaim();
			}; Button usagebtn = FindViewById<Button>(Resource.Id.usageBtn);
			//Toast.MakeText(this, ContactkUs.Text, ToastLength.Short).Show();
			usagebtn.Click += (object sender, System.EventArgs e) =>
			{
				//Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
				//ContactUsActivity cta = new ContactUsActivity( savedInstanceState);
				MyUsage();
			};

			Button historybtn = FindViewById<Button>(Resource.Id.HistoryBtn);
			//Toast.MakeText(this, ContactkUs.Text, ToastLength.Short).Show();
			historybtn.Click += (object sender, System.EventArgs e) =>
			{
				//Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
				//ContactUsActivity cta = new ContactUsActivity( savedInstanceState);
				History();
			};


		}

		public override void OnBackPressed()
		{
			homePage();
		}


		private void contactusPage()
		{
			SetContentView(Resource.Layout.Contactus);
			// Get our button from the layout resource,
			// and attach an event to it

			Button button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += (object sender, System.EventArgs e) =>
			{
				// make a call to the provider 
				Android.Net.Uri number = Android.Net.Uri.Parse("tel:" + "0431015184");
				Intent dialintent = new Intent(Intent.ActionView,number);
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

		}
		private void makeaclaim()
		{
			SetContentView(Resource.Layout.Contactus);
			// Get our button from the layout resource,
			// and attach an event to it

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