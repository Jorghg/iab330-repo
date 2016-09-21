using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace iRecover.Droid.Views
{
    [Activity(Label = "View for Homescreen")]
    public class HomeScreenView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeScreenView);
        }
    }
}
