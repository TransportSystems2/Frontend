using System;
using MvvmCross.Binding.BindingContext;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.SignUp
{
    public partial class FinishedSignUpView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<FinishedSignUpView, FinishedSignUpViewModel>();

            set.Bind(CongratulationsLabel).To(vm => vm.CongratulationsLabel);
            set.Bind(DescriptionLabel).To(vm => vm.DescriptionLabel);
        }
    }
}