using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp.Dispatcher;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp.Dispatcher
{
    [Activity(Label = "DispatcherLocationView")]
    public class DispatcherLocationView : MvxActivity<DispatcherLocationViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DispatcherLocationView);
        }
    }
}
