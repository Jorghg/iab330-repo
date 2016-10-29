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

            VisitWebsite.Click += (object sender, System.EventArgs e) =>
            {
                var uri = Android.Net.Uri.Parse("http://www.suncorp.com.au/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
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