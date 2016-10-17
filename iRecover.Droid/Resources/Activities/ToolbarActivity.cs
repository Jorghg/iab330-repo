using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace iRecover.Droid.Resources.Activities
{
    [Activity(Label = "ToolbarActivity")]
    public class ToolbarActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            [Activity(MainLauncher = true)]
        public class PostsView : MvxAppCompatActivity<PostsViewModel> // : MvxActivity<PostsViewModel>
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);

                SetContentView(Resource.Layout.View_Posts);
            }
        }
    }
    }
}