using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using TransportSystems.Frontend.App.ViewModels;

namespace TransportSystems.Frontend.MobileApp.Ios.Views
{
    public class BaseView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<BaseView, BaseViewModel>();
            set.Apply();
        }
    }
}
