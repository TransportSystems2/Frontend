using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignIn;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp
{
    [Activity(Label = "SignUpView")]
    public class SignInPhoneView : MvxActivity<SignInPhoneViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignInPhoneView);
        }
    }
}
