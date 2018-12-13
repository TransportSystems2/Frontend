using MvvmCross.Binding.BindingContext;
using TransportSystems.Frontend.App.ViewModels.SignIn;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignIn
{
    public partial class SignInPhoneView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<SignInPhoneView, SignInPhoneViewModel>();
            set.Bind(CountryCodeField).To(vm => vm.CountryCode);
            set.Bind(PhoneNumberField).To(vm => vm.PhoneNumber);
            set.Bind(GetCodeButton).To(vm => vm.GetCodeCommand);
            set.Apply();
        }
    }
}