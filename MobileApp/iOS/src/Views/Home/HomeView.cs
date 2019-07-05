using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TransportSystems.Frontend.App.ViewModels.Home;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.Home
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class HomeView : MvxTabBarViewController<HomeViewModel>
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Apply();
        }
    }
}

