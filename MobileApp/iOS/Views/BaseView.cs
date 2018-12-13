using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using TransportSystems.Frontend.App.ViewModels;

namespace TransportSystems.Frontend.MobileApp.iOS.Views
{
    public class BaseView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<BaseView, BaseViewModel>();
            set.Bind(this).For(v => v.Title).To(vm => vm.Title);
            set.Apply();
        }
    }
}
