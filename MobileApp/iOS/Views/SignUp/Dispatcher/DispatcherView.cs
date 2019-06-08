using MvvmCross.Binding.BindingContext;
using TransportSystems.Frontend.App.ViewModels.SignUp;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.SignUp.Dispatcher
{
    public partial class DispatcherView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<DispatcherView, DispatcherViewModel>();
            set.Bind(FirstNameTextField).To(vm => vm.FirstName);
            set.Bind(LastNameTextField).To(vm => vm.LastName);
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
        }
    }
}