using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp
{
    [Activity(Label = "VehicleView")]
    public class VehicleView : MvxActivity<VehicleViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VehicleView);
        }
    }
}
