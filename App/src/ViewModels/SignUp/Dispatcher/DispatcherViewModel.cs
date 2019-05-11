using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.App.Models.Users;

namespace TransportSystems.Frontend.App.ViewModels.SignUp.Dispatcher
{
    public class DispatcherViewModel : BaseViewModel<DispatcherCompanyM>
    {
        public DispatcherViewModel()
        {
            NextCommand = new MvxAsyncCommand(Next);
        }

        public readonly INC<string> FirstNameLabel = new NC<string>();

        public readonly INC<string> FirstName = new NC<string>();

        public readonly INC<string> LastNameLabel = new NC<string>();

        public readonly INC<string> LastName = new NC<string>();

        public readonly INC<string> NextButtonText = new NC<string>();

        public IMvxCommand NextCommand { get; private set; }

        public override void Prepare()
        {
            Title.Value = "Диспетчер";

            FirstNameLabel.Value = "Имя";
            LastNameLabel.Value = "Фамилия";
            NextButtonText.Value = "Далее";

#if DEBUG
            FirstName.Value = "Александр";
            LastName.Value = "Фадеев";
#endif

            base.Prepare();
        }

        private async Task Next()
        {
            var dispatcher = new DispatcherM
            {
                FirstName = FirstName.Value,
                LastName = LastName.Value
            };

            Model.Dispatcher = dispatcher;

            await NavigationService.Navigate<DispatcherLocationViewModel, DispatcherCompanyM>(Model);
        }
    }
}
