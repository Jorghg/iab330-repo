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
	[Activity(Label = "MakeClaimPage")]
	public class MakeClaimPage : MvxActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			makeClaimPage();
			// Create your application here
		}

		private void CreateDirectoryForPictures()
		{
			App._dir = new File(
				Android.OS.Environment.GetExternalStoragePublicDirectory(
					Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
			if (!App._dir.Exists())
			{
				App._dir.Mkdirs();
			}
		}

		public static readonly int PickImageId = 1000;
	

		public void makeClaimPage()
		{
			SetContentView(Resource.Layout.MakeClaim);
			// Get our button from the layout resource,
			// and attach an event to it
			CreateDirectoryForPictures();
			Button button1 = FindViewById<Button>(Resource.Id.button1);

			button1.Click += TakeAPicture;

			Button button2 = FindViewById<Button>(Resource.Id.button2);

			button2.Click += (object sender, System.EventArgs e) =>
			{
				Intent = new Intent();
				Intent.SetType("image/*");
				Intent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(Intent, "Select Pickture"), PickImageId);
			};

		}
		private void claimPage(Android.Net.Uri inputImageUri)
		{
			SetContentView(Resource.Layout.Submit);
			ImageView img = FindViewById<ImageView>(Resource.Id.imageView1);
			if (inputImageUri != null)
			{
				img.SetImageURI(inputImageUri);
			}
			else {
				img = _imageView;
			}


		}

		private bool IsThereAnAppToTakePictures()
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			IList<ResolveInfo> availableActivities =
				PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
			return availableActivities != null && availableActivities.Count > 0;
		}
		private void TakeAPicture(object sender, EventArgs eventArgs)
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
			intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(App._file));
			StartActivityForResult(intent, 0);
		}



		private ImageView _imageView;
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (requestCode == PickImageId && resultCode == Result.Ok && data != null)
			{
				Android.Net.Uri claimImageUri = data.Data;
				claimPage(claimImageUri);
			}

			Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
			Uri contentUri = Uri.FromFile(App._file);


			mediaScanIntent.SetData(contentUri);
			SendBroadcast(mediaScanIntent);

			// Display in ImageView. We will resize the bitmap to fit the display.
			// Loading the full sized image will consume to much memory
			// and cause the application to crash.

			int height = Resources.DisplayMetrics.HeightPixels;
			int width = _imageView.Height;
			App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
			if (App.bitmap != null)
			{
				_imageView.SetImageBitmap(App.bitmap);
				App.bitmap = null;
			}

			// Dispose of the Java side bitmap.
			GC.Collect();
			claimPage(null);

		}

	}

	public static class App
	{
		public static File _file;
		public static File _dir;
		public static Bitmap bitmap;
	}
	public static class BitmapHelpers
	{
		public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
		{
			// First we get the the dimensions of the file on disk
			BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
			BitmapFactory.DecodeFile(fileName, options);

			// Next we calculate the ratio that we need to resize the image by
			// in order to fit the requested dimensions.
			int outHeight = options.OutHeight;
			int outWidth = options.OutWidth;
			int inSampleSize = 1;

			if (outHeight > height || outWidth > width)
			{
				inSampleSize = outWidth > outHeight
								   ? outHeight / height
								   : outWidth / width;
			}

			// Now we will load the image and have BitmapFactory resize it for us.
			options.InSampleSize = inSampleSize;
			options.InJustDecodeBounds = false;
			Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

			return resizedBitmap;
		}
	}


}
