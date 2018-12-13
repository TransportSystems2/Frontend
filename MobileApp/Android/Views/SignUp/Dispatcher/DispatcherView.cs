using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp.Dispatcher;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp.Dispatcher
{
    [Activity(Label = "DispatcherView")]
    public class DispatcherView : MvxActivity<DispatcherViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DispatcherView);
        }
    }
}
