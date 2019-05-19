using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.Models.SignIn;
using TransportSystems.Frontend.App.ViewModels.Home;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;

namespace TransportSystems.Frontend.App.ViewModels.SignIn
{
    public class VerifyCodeViewModel : BaseViewModel<PhoneNumberM>
    {
        public VerifyCodeViewModel(ISignInService signInService, IUserInfoService userInfoService)
        {
            SignInService = signInService;
            UserInfoService = userInfoService;

            VerifyCodeCommand = new MvxAsyncCommand(VerifyCodeAsync);
        }

        public readonly INC<string> PhoneNumber = new NC<string>();

        public readonly INC<string> Code = new NC<string>();

        public IMvxCommand VerifyCodeCommand { get; private set; }

        private ISignInService SignInService { get; }

        private IUserInfoService UserInfoService { get; }

        public override void Prepare()
        {
            Title.Value = "Проверка кода";

            base.Prepare();
        }

        public override void Prepare(PhoneNumberM parameter)
        {
            PhoneNumber.Value = parameter.Phone;
        }

        private async Task VerifyCodeAsync()
        {
            var success = await SignInService.AuthAsync(PhoneNumber.Value, Code.Value);
            if (!success)
            {
                // should say verification code is failed
                return;
            }

            await UserInfoService.UpdateUserInfo();

            if (UserInfoService.IsNewUser())
            {
                await NavigationService.Navigate<DispatcherViewModel, CompanyApplicationDM>(new CompanyApplicationDM());
            }
            else
            {
                await NavigationService.Navigate<HomeViewModel>();
            }
        }
    }
}