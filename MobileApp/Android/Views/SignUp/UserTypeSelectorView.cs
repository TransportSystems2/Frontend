using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp
{
    [Activity(Label = "UserTypeSelectorView")]
    public class UserTypeSelectorView : MvxActivity<UserTypeSelectorViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.UserTypeSelectorView);
        }
    }
}
