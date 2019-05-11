using System.Threading.Tasks;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.App.Models.Users;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;

namespace TransportSystems.Frontend.App.ViewModels.SignUp.Driver
{
    public class DriverViewModel : BaseViewModel<DriverCompanyM>
    {
        public DriverViewModel()
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
            Title.Value = "Водитель";

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
            var driver = new DriverM
            {
                FirstName = FirstName.Value,
                LastName = LastName.Value
            };

            Model.Driver = driver;

            await NavigationService.Navigate<VehicleViewModel, DriverCompanyM>(Model);
        }
    }
}
