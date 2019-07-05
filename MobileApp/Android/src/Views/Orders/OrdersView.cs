using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using TransportSystems.Frontend.App.ViewModels.Home;
using TransportSystems.Frontend.App.ViewModels.Orders;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Orders
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.content_frame)]
    public class OrdersView : MvxFragment<OrdersViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.OrdersView, null);
        }
    }
}
