using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.SignUp;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp
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
