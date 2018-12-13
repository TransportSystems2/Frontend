using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.Cargo;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Cargo
{
    [Activity(Label = "CargoView")]
    public class CargoView : MvxActivity<CargoViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CargoView);
        }
    }
}
