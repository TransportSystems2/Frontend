using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class DispatcherViewModel : BaseViewModel<CompanyApplicationDM>
    {
        public DispatcherViewModel(IUserInfoService userInfoService)
        {
            UserInfoService = userInfoService;
            NextCommand = new MvxAsyncCommand(Next);
        }

        public readonly INC<string> FirstName = new NC<string>();

        public readonly INC<string> LastName = new NC<string>();

        public IMvxCommand NextCommand { get; private set; }

        protected IUserInfoService UserInfoService { get; }

        public override void Prepare()
        {
#if DEBUG
            FirstName.Value = "Александр";
            LastName.Value = "Фадеев";
#endif

            base.Prepare();
        }

        private async Task Next()
        {
            var phoneNumber = UserInfoService.GetPhoneNumber();
            var dispatcher = new DispatcherDM
            {
                FirstName = FirstName.Value,
                LastName = LastName.Value,
                PhoneNumber = phoneNumber
            };

            Model.Dispatcher = dispatcher;

            await NavigationService.Navigate<LocationViewModel, CompanyApplicationDM>(Model);
        }
    }
}
