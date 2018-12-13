using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.App.Models.Geo;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.Garages;
using TransportSystems.Frontend.Core.Services.Interfaces.SignUp;

namespace TransportSystems.Frontend.App.ViewModels.SignUp.Dispatcher
{
    public class DispatcherLocationViewModel : LocationViewModel<DispatcherCompanyM>
    {
        public DispatcherLocationViewModel(ISignUpService signUpService, IGarageService garageService)
            : base(signUpService, garageService)
        {
        }

        protected override async Task Register()
        {
            var address = new AddressM
            {
                Country = "Россия",
                Province = Province.Value,
                Locality = City.Value,
                District = Region.Value
            };

            Model.GarageAddress = address;
            var company = Mapper.Map<DispatcherCompanyDM>(Model);
            await SignUpService.RegisterDispatcher(company, RequestPriority.UserInitiated);

            await NavigationService.Navigate<FinishedSignUpViewModel>();
        }
    }
}