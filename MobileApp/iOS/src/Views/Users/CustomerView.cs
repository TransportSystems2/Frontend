using System;
using MvvmCross.Binding.BindingContext;
using TransportSystems.Frontend.App.ViewModels.Customer;
using UIKit;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.Users
{
    public partial class CustomerView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<CustomerView, CustomerViewModel>();
            set.Bind(NameTextField).To(vm => vm.Name);
            set.Bind(PhoneTextField).To(vm => vm.Phone);
            set.Bind(NextButton).To(vm => vm.NextCommand);
            set.Apply();
        }
    }
}

