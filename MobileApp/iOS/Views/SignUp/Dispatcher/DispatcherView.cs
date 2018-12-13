using MvvmCross.Binding.BindingContext;
using TransportSystems.Frontend.App.ViewModels.SignUp.Dispatcher;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp.Dispatcher
{
    public partial class DispatcherView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<DispatcherView, DispatcherViewModel>();
            set.Bind(FirstNameLabel).To(vm => vm.FirstNameLabel);
            set.Bind(FirstNameTextField).To(vm => vm.FirstName);
            set.Bind(LastNameLabel).To(vm => vm.LastNameLabel);
            set.Bind(LastNameTextField).To(vm => vm.LastName);
            set.Bind(NextButton).For("Title").To(vm => vm.NextButtonText);
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
        }
    }
}