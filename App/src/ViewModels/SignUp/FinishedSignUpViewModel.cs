using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.ViewModels.Home;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class FinishedSignUpViewModel : BaseViewModel
    {
        public FinishedSignUpViewModel(IUserInfoService userInfoService)
        {
            UserInfoService = userInfoService;

            FinishCommand = new MvxAsyncCommand(Finish);
        }

        public readonly INC<string> CongratulationsLabel = new NC<string>();

        public readonly INC<string> DescriptionLabel = new NC<string>();

        public readonly INC<string> FinishButtonText = new NC<string>();

        public IMvxCommand FinishCommand { get; private set; }

        private IUserInfoService UserInfoService { get; }

        public override void Prepare()
        {
            CongratulationsLabel.Value = "Поздравляем UserName, вы успешно зарегистрировались в диспетчерской службе ГосЭвакуатор.";
            DescriptionLabel.Value = "На ваш счет зачислено 1500 бонусных рублей, используйте их при оплате комиссии за использованные заказы.";
            FinishButtonText.Value = "Готово";

            base.Prepare();
        }

        public override void Start()
        {
            base.Start();

            UserInfoService.UpdateUserInfo();
        }

        private async Task Finish()
        {
            await NavigationService.Navigate<HomeViewModel>();
        }
    }
}