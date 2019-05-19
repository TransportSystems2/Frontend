using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.Models.Transport;
using TransportSystems.Frontend.App.ViewModels.Cargo;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Services.Interfaces.Transport;
using TransportSystems.Frontend.Extensions;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class VehicleViewModel : BaseViewModel<CompanyApplicationDM>
    {  
        public VehicleViewModel(IVehicleService vehicleService)
        {
            NextCommand = new MvxAsyncCommand(Next);

            VehicleService = vehicleService;
        }

        public readonly INC<ICollection<string>> Kinds = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Brands = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Capacities = new NC<ICollection<string>>();

        public readonly INC<string> Kind = new NC<string>();

        public readonly INC<string> Brand = new NC<string>();

        public readonly INC<string> Capacity = new NC<string>();

        public readonly INC<string> RegistrationNumber = new NC<string>();

        public IMvxCommand NextCommand { get; private set; }

        protected VehicleParametersM VehicleParameters { get; set; }

        protected IVehicleService VehicleService { get; }

        public override void Prepare(CompanyApplicationDM parameter)
        {

#if DEBUG
            RegistrationNumber.Value = "Х827МН76";
#endif

            base.Prepare(parameter);
        }

        public async override Task Initialize()
        {
            VehicleParameters = await GetAvailableVehicleParameters();
            InitByVehicleParameters(VehicleParameters);

            await base.Initialize();
        }

        protected virtual void InitByVehicleParameters(VehicleParametersM parameters)
        {
            var kinds = parameters.Kinds.Select(i => i.Name);
            var brands = parameters.Brands.Select(i => i.Name);
            var capacities = parameters.Capacities.Select(i => i.Name);

            Kinds.Value = kinds.ToList();
            Brands.Value = brands.ToList();
            Capacities.Value = capacities.ToList();

            Kind.Value = kinds.FirstOrDefault();
            Brand.Value = brands.FirstOrDefault();
            Capacity.Value = capacities.FirstOrDefault();
        }

        private async Task Next()
        {
            var selectedKind = VehicleParameters.Kinds.First(k => k.Name.Equals(Kind.Value));
            var selectedBrand = VehicleParameters.Brands.First(b => b.Name.Equals(Brand.Value));
            var selectedCapacity = VehicleParameters.Capacities.First(c => c.Name.Equals(Capacity.Value));

            var vehicle = new VehicleDM
            {
                KindCatalogItemId = selectedKind.Id,
                BrandCatalogItemId = selectedBrand.Id,
                CapacityCatalogItemId = selectedCapacity.Id,
                RegistrationNumber = RegistrationNumber.Value
            };

            Model.Vehicle = vehicle;

            await NavigationService.Navigate<DriverViewModel, CompanyApplicationDM>(Model);
        }

        private async Task<VehicleParametersM> GetAvailableVehicleParameters()
        {
            var result = new VehicleParametersM();
            var domainVehicleParams = await VehicleService.GetVehiclesParams(RequestPriority.UserInitiated);
            Mapper.Map(domainVehicleParams, result);

            return result;
        }
    }
}
