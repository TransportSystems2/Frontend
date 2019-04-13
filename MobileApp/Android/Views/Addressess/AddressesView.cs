using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.Address;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Addressess
{
    [Activity(Label = "Addresses")]
    public class AddressesView : MvxActivity<AddressesViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddressessView);
        }
    }
}