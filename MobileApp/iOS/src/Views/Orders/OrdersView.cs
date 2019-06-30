using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TransportSystems.Frontend.App.ViewModels.Orders;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.Orders
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Orders", TabIconName = "Screens_Orders_Icon")]
    public partial class OrdersView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<OrdersView, OrdersViewModel>();
            set.Bind(AddOrderButton).To(vm => vm.AddOrderCommand);
            set.Apply();
        }
    }
}