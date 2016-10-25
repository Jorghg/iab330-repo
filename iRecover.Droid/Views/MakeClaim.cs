
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Droid.Views;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace iRecover.Droid
{
	[Activity(Label = "iRecover", MainLauncher = true, Icon = "@drawable/icon")]
	public class MakeClaim : MvxActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
		}
	}


}
