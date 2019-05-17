using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.App.Models.Geo;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.Garages;
using TransportSystems.Frontend.Core.Services.Interfaces.SignUp;

namespace TransportSystems.Frontend.App.ViewModels.SignUp.Driver
{
    public class DriverLocationViewModel : LocationViewModel<DriverCompanyM>
    {
        public DriverLocationViewModel(ISignUpService signUpService, IGarageService garageService)
            : base(signUpService, garageService)
        {
        }

        public override void Prepare()
        {
#if DEBUG
            Province.Value = "Ярославская";
            City.Value = "Рыбинск";
            Region.Value = "Центральный";
#endif

            base.Prepare();
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

            var domainCompany = Mapper.Map<DriverCompanyDM>(Model);

            await SignUpService.RegisterDriver(domainCompany, RequestPriority.UserInitiated);

            await NavigationService.Navigate<FinishedSignUpViewModel>();
        }
    }
}
