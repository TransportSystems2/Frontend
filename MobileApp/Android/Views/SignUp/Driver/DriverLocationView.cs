using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp.Driver;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp.Driver
{
    [Activity(Label = "DriverLocationView")]
    public class DriverLocationView : MvxActivity<DriverLocationViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DriverLocationView);
        }
    }
}
