using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;

namespace TransportSystems.Frontend.App.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public readonly INC<string> Title = new NC<string>();

        protected IMvxNavigationService NavigationService { get; }

        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }
    }

    public class BaseViewModel<T> : MvxViewModel<T>
    {
        public readonly INC<string> Title = new NC<string>();

        protected IMvxNavigationService NavigationService { get; }

        protected T Model { get; private set; }

        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        public override void Prepare(T parameter)
        {
            Model = parameter;
        }
    }
}
