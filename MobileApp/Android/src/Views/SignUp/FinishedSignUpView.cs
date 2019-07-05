using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp
{
    [Activity(Label = "FinishedSignUpView")]
    public class FinishedSignUpView : MvxActivity<FinishedSignUpViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FinishedSignUpView);
        }
    }
}
