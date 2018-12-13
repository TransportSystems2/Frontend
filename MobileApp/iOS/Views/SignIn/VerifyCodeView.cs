using MvvmCross.Binding.BindingContext;
using TransportSystems.Frontend.App.ViewModels.SignIn;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignIn
{
    public partial class VerifyCodeView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<VerifyCodeView, VerifyCodeViewModel>();
            set.Bind(PhoneNumberLabel).To(vm => vm.PhoneNumber);
            set.Bind(CodeTextField).To(vm => vm.Code);
            set.Bind(VerifyCodeButton).To(vm => vm.VerifyCodeCommand);
            set.Apply();
        }
    }
}

