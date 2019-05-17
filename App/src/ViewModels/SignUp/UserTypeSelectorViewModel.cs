using System.Threading.Tasks;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.App.ViewModels.SignUp.Dispatcher;
using TransportSystems.Frontend.App.ViewModels.SignUp.Driver;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class UserTypeSelectorViewModel : BaseViewModel
    {
        public UserTypeSelectorViewModel()
        {
            SelectDispatcherCommand = new MvxAsyncCommand(SelectDispatcherAsync);
            SelectDriverCommand = new MvxAsyncCommand(SelectDriverAsync);
        }

        public readonly INC<string> DispatcherCaption = new NC<string>();

        public readonly INC<string> DispatcherDescription = new NC<string>();

        public readonly INC<string> DriverCaption = new NC<string>();

        public readonly INC<string> DriverDescription = new NC<string>();

        public IMvxCommand SelectDispatcherCommand { get; private set; }

        public IMvxCommand SelectDriverCommand { get; private set; }

        public override void Prepare()
        {
            Title.Value = "Регистрация";

            DispatcherCaption.Value = "Я диспетчер";
            DriverCaption.Value = "Я водитель";

            DispatcherDescription.Value = "Я работаю с одним или несколькими водителями, распределяю заказы (сам на эвакуации не езжу)";
            DriverDescription.Value = "У меня есть эвакуатор и я сам выезжаю на заказы";

            base.Prepare();
        }

        private async Task SelectDispatcherAsync()
        {
            var company = new DispatcherCompanyM();
            await NavigationService.Navigate<DispatcherViewModel, DispatcherCompanyM>(company);
        }

        private async Task SelectDriverAsync()
        {
            var company = new DriverCompanyM();
            await NavigationService.Navigate<DriverViewModel, DriverCompanyM>(company);
        }
    }
}