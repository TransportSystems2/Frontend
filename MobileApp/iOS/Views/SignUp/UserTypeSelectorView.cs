using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TransportSystems.Frontend.App.ViewModels.SignUp;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class UserTypeSelectorView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<UserTypeSelectorView, UserTypeSelectorViewModel>();
            set.Bind(DispatcherButton).To(vm => vm.SelectDispatcherCommand);
            set.Bind(DispatcherCaptionLabel).To(vm => vm.DispatcherCaption);
            set.Bind(DispatcherDescriptionLabel).To(vm => vm.DispatcherDescription);

            set.Bind(DriverButton).To(vm => vm.SelectDriverCommand);
            set.Bind(DriverCaptionLabel).To(vm => vm.DriverCaption);
            set.Bind(DriverDescriptionLabel).To(vm => vm.DriverDescription);
            set.Apply();
        }
    }
}

