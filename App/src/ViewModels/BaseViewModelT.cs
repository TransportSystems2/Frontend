using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TransportSystems.Frontend.App.ViewModels
{
    public class BaseViewModel<T> : MvxViewModel<T>
    {
        public BaseViewModel()
        {
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        protected IMvxNavigationService NavigationService { get; }

        protected T Model { get; private set; }

        public override void Prepare(T parameter)
        {
            Model = parameter;
        }
    }
}
