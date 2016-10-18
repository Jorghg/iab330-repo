using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;

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

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetActionBar (toolbar);
            //ActionBar.Title = "My Toolbar";
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.HomeScreen);
			ImageView img = FindViewById<ImageView>(Resource.Id.mainImage);
			img.SetImageResource(Resource.Drawable.suncorplogo);

			Button ContactkUs = FindViewById<Button>(Resource.Id.contactBtn);
			//Toast.MakeText(this, ContactkUs.Text, ToastLength.Short).Show();
			ContactkUs.Click += (object sender, System.EventArgs e) =>
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
			Button btnbutton1 = FindViewById<Button>(Resource.Id.btnbutton1);

			btnbutton1.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
				//SetContentView(Resource.Layout.HomePage);
			};

			Button button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Call us Function allws users to Contact their provider directlly", ToastLength.Short).Show();
			};





			Button button3 = FindViewById<Button>(Resource.Id.button3);

			button3.Click += (object sender, System.EventArgs e) =>
			{

				Toast.MakeText(this, "Find us Function allws users to find the Location of their provider", ToastLength.Short).Show();
			};

		}
		private void makeaclaim()
		{
			SetContentView(Resource.Layout.Contactus);
			// Get our button from the layout resource,
			// and attach an event to it
			Button btnbutton1 = FindViewById<Button>(Resource.Id.btnbutton1);

			btnbutton1.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
				//SetContentView(Resource.Layout.HomePage);
			};

			Button button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Call us Function allws users to Contact their provider directlly", ToastLength.Short).Show();
			};

			Button button3 = FindViewById<Button>(Resource.Id.button3);

			button3.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Find us Function allws users to find the Location of their provider", ToastLength.Short).Show();
			};

		}

		private void MyUsage()
		{
		SetContentView(Resource.Layout.Contactus);
		 //Get our button from the layout resource,
		 //and attach an event to it
		Button btnbutton1 = FindViewById<Button>(Resource.Id.btnbutton1);

		btnbutton1.Click += (object sender, System.EventArgs e) =>
	{
				Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
		//SetContentView(Resource.Layout.HomePage);
			};

			Button button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Call us Function allws users to Contact their provider directlly", ToastLength.Short).Show();
			};

			Button button3 = FindViewById<Button>(Resource.Id.button3);

			button3.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Find us Function allws users to find the Location of their provider", ToastLength.Short).Show();
			};

		}

		private void History()
		{
			SetContentView(Resource.Layout.Contactus);
		 //Get our button from the layout resource,
		 //and attach an event to it
			Button btnbutton1 = FindViewById<Button>(Resource.Id.btnbutton1);

			btnbutton1.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Email us Function allws users to send an email to the provider", ToastLength.Short).Show();
		//SetContentView(Resource.Layout.HomePage);
			};

			Button button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Call us Function allws users to Contact their provider directlly", ToastLength.Short).Show();
			};

			Button button3 = FindViewById<Button>(Resource.Id.button3);

		//	button3.Click += (object sender, System.EventArgs e) =>
			{
				Toast.MakeText(this, "Find us Function allws users to find the Location of their provider", ToastLength.Short).Show();
			};

		}
	}


}