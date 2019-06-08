using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TransportSystems.Frontend.App.ViewModels.Home;
using TransportSystems.Frontend.App.ViewModels.SignIn;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;

namespace TransportSystems.Frontend.App
{
    public class CustomAppStart : MvxAppStart
    {
        public CustomAppStart(IMvxApplication application, IMvxNavigationService navigationService)
            : base(application, navigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            var signInService = Mvx.IoCProvider.Resolve<ISignInService>();
            var isSigned = signInService.IsSigned();
            return isSigned ? NavigateForSignedUser() : NavigateForUnsignedUser();
        }

        private Task NavigateForUnsignedUser()
        {
            return NavigationService.Navigate<SignInPhoneViewModel>();
        }

        private Task NavigateForSignedUser()
        {
            var userInfoService = Mvx.IoCProvider.Resolve<IUserInfoService>();
            return userInfoService.IsNewUser()
                ? NavigationService.Navigate<DispatcherViewModel, CompanyApplicationDM>(new CompanyApplicationDM())
                : NavigationService.Navigate<HomeViewModel>();
        }
    }
}