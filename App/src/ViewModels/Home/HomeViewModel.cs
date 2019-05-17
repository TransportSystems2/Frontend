using System.Threading.Tasks;
using MvvmCross.Commands;
using TransportSystems.Frontend.App.ViewModels.Orders;
using TransportSystems.Frontend.App.ViewModels.Settings;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;

namespace TransportSystems.Frontend.App.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IUserInfoService userInfoService, ISignInService signInService)
        {
            UserInfoService = userInfoService;
            SignInService = signInService;

            ShowOrdersViewCommand = new MvxAsyncCommand(ShowOrdersView);
            ShowSettingsViewCommand = new MvxAsyncCommand(ShowSettingsView);
        }

        public IMvxCommand AddOrderCommand { get; }

        public IMvxCommand ShowOrdersViewCommand { get; }

        public IMvxCommand ShowSettingsViewCommand { get; }

        protected IUserInfoService UserInfoService { get; }

        protected ISignInService SignInService { get; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            // InitScreens();
        }

        protected void InitScreens()
        {
            var isModerator = UserInfoService.IsInRole(UserRoles.Moderator);
            if (isModerator)
            {
                InitScreensForModerator();
            }

            var isDispatcher = UserInfoService.IsInRole(UserRoles.Dispatcher);
            if (isDispatcher)
            {
                InitScreensForDispatcher();
            }

            var isDriver = UserInfoService.IsInRole(UserRoles.Driver);
            if (isDriver)
            {
                InitScreensForDriver();
            }
        }

        protected void InitScreensForModerator()
        {
            ShowOrdersViewCommand.Execute(null);
            ShowSettingsViewCommand.Execute(null);
        }

        protected void InitScreensForDispatcher()
        {
            ShowOrdersViewCommand.Execute(null);
            ShowSettingsViewCommand.Execute(null);
        }

        protected void InitScreensForDriver()
        {
            ShowOrdersViewCommand.Execute(null);
            ShowSettingsViewCommand.Execute(null);
        }

        private async Task ShowOrdersView()
        {
            await NavigationService.Navigate<OrdersViewModel>();
        }

        private async Task ShowSettingsView()
        {
            await NavigationService.Navigate<SettingsViewModel>();
        }
    }
}
