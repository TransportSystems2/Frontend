using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.SignIn;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignIn
{
    [Activity(Label = "SignInView")]
    public class VerifyCodeView : MvxActivity<VerifyCodeViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VerifyCodeView);
        }
    }
}
