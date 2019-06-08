using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.SignUp;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class DriverViewModel : BaseViewModel<CompanyApplicationDM>
    {
        public readonly INC<string> PhoneNumber = new NC<string>();

        public readonly INC<string> FirstName = new NC<string>();

        public readonly INC<string> LastName = new NC<string>();

        public readonly INC<bool> DriveMySelf = new NC<bool>();

        public DriverViewModel(ISignUpService signUpService, IUserInfoService userInfoService)
        {
            SignUpService = signUpService;
            UserInfoService = userInfoService;
            NextCommand = new MvxAsyncCommand(Next);
        }

        public IMvxCommand NextCommand { get; }

        protected ISignUpService SignUpService { get; }

        protected IUserInfoService UserInfoService { get; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            DriveMySelf.Changed += HandleDriverMySelfChanged;
        }

        public override void ViewDisappearing()
        {
            DriveMySelf.Changed -= HandleDriverMySelfChanged;

            base.ViewDisappearing();
        }

        private async Task Next()
        {
            var driver = new DriverDM
            {
                FirstName = FirstName.Value,
                LastName = LastName.Value,
                PhoneNumber = PhoneNumber.Value
            };

            Model.Driver = driver;

            await SignUpService.Register(Model, RequestPriority.UserInitiated);

            // после регистрации обновились роли пользователя,
            // необходимо обновить информацию о пользователе
            await UserInfoService.UpdateUserInfo();

            await NavigationService.Navigate<FinishedSignUpViewModel, CompanyApplicationDM>(Model);
        }

        private void HandleDriverMySelfChanged(object sender, System.EventArgs e)
        {
            FirstName.Value = DriveMySelf.Value ? Model.Dispatcher.FirstName : string.Empty;
            LastName.Value = DriveMySelf.Value ? Model.Dispatcher.LastName : string.Empty;
            PhoneNumber.Value = DriveMySelf.Value ? Model.Dispatcher.PhoneNumber : string.Empty;
        }
    }
}
