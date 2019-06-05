using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.ViewModels.Home;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class FinishedSignUpViewModel : BaseViewModel<CompanyApplicationDM>
    {
        public FinishedSignUpViewModel()
        {
            FinishCommand = new MvxAsyncCommand(Finish);
        }

        public readonly INC<string> CongratulationsLabel = new NC<string>();

        public readonly INC<string> DescriptionLabel = new NC<string>();

        public IMvxCommand FinishCommand { get; private set; }

        public override void Prepare(CompanyApplicationDM parameter)
        {
            CongratulationsLabel.Value = $"Поздравляем {parameter.Dispatcher.FirstName}, вы успешно зарегистрировались в диспетчерской службе ГосЭвакуатор.";
            DescriptionLabel.Value = "На ваш счет зачислено 1500 бонусных рублей, используйте их при оплате комиссии за использованные заказы.";

            base.Prepare(parameter);
        }

        private async Task Finish()
        {
            await NavigationService.Navigate<HomeViewModel>();
        }
    }
}