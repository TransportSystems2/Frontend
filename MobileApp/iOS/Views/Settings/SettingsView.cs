using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using TransportSystems.Frontend.App.ViewModels.Settings;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.Settings
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Settings", TabIconName = "Screens_Settings_Icon")]
    public partial class SettingsView : BaseView
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<SettingsView, SettingsViewModel>();
            set.Apply();
        }
    }
}