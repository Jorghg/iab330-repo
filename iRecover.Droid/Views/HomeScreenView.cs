using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace iRecover.Droid.Views
{
    [Activity(Label = "iRecover",  Icon = "@drawable/icon")]
    //public class HomeScreenView : MvxActivity
    public class HomeScreenView : MvxActivity, IOnMapReadyCallback
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
                contactUsPage();
            };

            Button claimbtn = FindViewById<Button>(Resource.Id.claimBtn);
			//Toast.MakeText(this, ContactkUs.Text, ToastLength.Short).Show();
			claimbtn.Click += (object sender, System.EventArgs e) =>
			{
                //Toast.MakeText(this, "claim button pressed", ToastLength.Short).Show();
                //ContactUsActivity cta = new ContactUsActivity( savedInstanceState);
                MakeAClaim();
			};

            Button usagebtn = FindViewById<Button>(Resource.Id.usageBtn);
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


        private void contactUsPage()
        {
            SetContentView(Resource.Layout.Contactus);
            // Get our button from the layout resource,
            // and attach an event to it
             Button CallBtn = FindViewById<Button>(Resource.Id.button2);

             CallBtn.Click += (object sender, System.EventArgs e) =>
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

            Button SearchProvider = FindViewById<Button>(Resource.Id.button4);
            SearchProvider.Click += (object sender, System.EventArgs e) =>
            {
                SearchProviderPage();
            };
        }
        private void MakeAClaim()
		{
			SetContentView(Resource.Layout.MakeClaim);
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

        private void SearchProviderPage()
        {
            SetContentView(Resource.Layout.SearchProvider);
            
var spinner = FindViewById<Spinner>(Resource.Id.spinner);
            string firstItem = spinner.SelectedItem.ToString();
            spinner.ItemSelected += (s,e) =>
            {  
                if (firstItem.Equals(spinner.SelectedItem.ToString()))
                {
                    // To do when first item is selected
                }
                else
                {
                    ProviderInfoPage();
                    //Toast.MakeText(this, "You have selected: " + e.Parent.GetItemIdAtPosition(e.Position).ToString(), ToastLength.Long).Show();
                }
            };
        }


        private GoogleMap mMap;
        private Button btnNormal;
        private Button btnHybrid;
        private Button btnSatellite;
        private Button btnTerrain;

        private void ProviderInfoPage()
        {
            SetContentView(Resource.Layout.ProviderInfo);

            //Contact Provider Buttons
            Button CallProvider = FindViewById<Button>(Resource.Id.btnCall);
            Button EmailProvider = FindViewById<Button>(Resource.Id.btnEmail);
            Button VisitWebsite = FindViewById<Button>(Resource.Id.btnWebsite);
            Button NavigateProvider = FindViewById<Button>(Resource.Id.btnDirections);

            CallProvider.Click += (object sender, System.EventArgs e) =>
            {
                // make a call to the provider 
                Android.Net.Uri number = Android.Net.Uri.Parse("tel:" + "1800775020");
                Intent dialintent = new Intent(Intent.ActionView, number);
                StartActivity(dialintent);
            };

            VisitWebsite.Click += (object sender, System.EventArgs e) =>
            {
                var uri = Android.Net.Uri.Parse("http://www.suncorp.com.au/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };

            NavigateProvider.Click += (object sender, System.EventArgs e) =>
            {
                var geoUri = Android.Net.Uri.Parse("geo:-27.4675634, 153.0244959");
                var mapIntent = new Intent(Intent.ActionView, geoUri);
                StartActivity(mapIntent);
            };

            // GOOGLE MAPS
            btnNormal = FindViewById<Button>(Resource.Id.btnNormal);
            btnHybrid = FindViewById<Button>(Resource.Id.btnHybrid);
            btnSatellite = FindViewById<Button>(Resource.Id.btnSatellite);
            btnTerrain = FindViewById<Button>(Resource.Id.btnTerrain);

            btnNormal.Click += btnNormal_Click;
            btnHybrid.Click += btnHybrid_Click;
            btnSatellite.Click += btnSatellite_Click;
            btnTerrain.Click += btnTerrain_Click;

            SetUpMap();

            // GOOGLE MAPS END

        } // End ProviderInfoPage

        private void btnNormal_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeNormal; 
        }

        private void btnHybrid_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeHybrid;
        }

        private void btnSatellite_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeSatellite;
        }

        private void btnTerrain_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeTerrain;
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            //throw new NotImplementedException();
            mMap = googleMap;
            LatLng latlng = new LatLng(-27.4675634, 153.0244959); // Suncorp Brisbane
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            mMap.MoveCamera(camera);

            //Marker 1
            MarkerOptions options = new MarkerOptions()
                .SetPosition(latlng)
                .SetTitle("Suncorp")
                .SetSnippet("Brisbane City")
                .Draggable(true);

           mMap.AddMarker(options);

           mMap.MarkerDragEnd += mMap_MarkerDragEnd;
        }
        void mMap_MarkerDragEnd(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            LatLng pos = e.Marker.Position;
            Console.WriteLine(pos.ToString());
        }
    } // END CLASS
} // END namespace