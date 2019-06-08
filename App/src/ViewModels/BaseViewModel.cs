using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TransportSystems.Frontend.App.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        protected IMvxNavigationService NavigationService { get; }
    }
}