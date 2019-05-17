using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.App.Models.Transport;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Services.Interfaces.Transport;
using TransportSystems.Frontend.Extensions;

namespace TransportSystems.Frontend.App.ViewModels.SignUp.Driver
{
    public class VehicleViewModel : BaseViewModel<DriverCompanyM>
    {
        private VehicleParametersM vehicleParameters;
       
        public VehicleViewModel(IVehicleService vehicleService)
        {
            NextCommand = new MvxAsyncCommand(Next);

            VehicleService = vehicleService;
        }

        public readonly INC<ICollection<string>> Brands = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Capacities = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Kinds = new NC<ICollection<string>>();

        public readonly INC<string> BrandLabel = new NC<string>();

        public readonly INC<string> Brand = new NC<string>();

        public readonly INC<string> MaxTonCapacityLabel = new NC<string>();

        public readonly INC<string> Capaticy = new NC<string>();

        public readonly INC<string> TypeLabel = new NC<string>();

        public readonly INC<string> Kind = new NC<string>();

        public readonly INC<string> RegistrationNumberLabel = new NC<string>();

        public readonly INC<string> RegistrationNumber = new NC<string>();

        public readonly INC<string> NextButtonText = new NC<string>();

        public IMvxCommand NextCommand { get; private set; }

        protected VehicleParametersM VehicleParameters
        {
            get => vehicleParameters;

            private set => SetVehicleParameters(value);
        }

        protected IVehicleService VehicleService { get; }

        public override void Prepare()
        {
            Title.Value = "Мой эвакуатор";

            Brands.Value = new List<string>();
            Capacities.Value = new List<string>();
            Kinds.Value = new List<string>();

            TypeLabel.Value = "Тип";
            BrandLabel.Value = "Марка";
            MaxTonCapacityLabel.Value = "Грузоподъемность до";
            RegistrationNumberLabel.Value = "Гос. номер";
            NextButtonText.Value = "Далее";

#if DEBUG
            RegistrationNumber.Value = "Х827МН76";
#endif

            base.Prepare();
        }

        public async override void Start()
        {
            base.Start();

            VehicleParameters = await GetAvailableVehicleParameters();
        }

        private async Task Next()
        {
            var selectedBrand = VehicleParameters.Brands.First(b => b.Name.Equals(Brand.Value));
            var selectedCapacity = VehicleParameters.Capacities.First(c => c.Name.Equals(Capaticy.Value));
            var selectedKind = vehicleParameters.Kinds.First(k => k.Name.Equals(Kind.Value));

            var vehicle = new VehicleM
            {
                BrandCatalogItemId = selectedBrand.Id,
                CapacityCatalogItemId = selectedCapacity.Id,
                KindCatalogItemId = selectedKind.Id,

                RegistrationNumber = RegistrationNumber.Value
            };

            Model.Vehicle = vehicle;

            await NavigationService.Navigate<DriverLocationViewModel, DriverCompanyM>(Model);
        }

        protected virtual void InitByVehicleParameters(VehicleParametersM parameters)
        {
            var brands = parameters.Brands.Select(i => i.Name);
            var capacities = parameters.Capacities.Select(i => i.Name);
            var kinds = parameters.Kinds.Select(i => i.Name);

            Brands.Value.ClearAndAddRange(brands);
            Capacities.Value.ClearAndAddRange(capacities);
            Kinds.Value.ClearAndAddRange(kinds);

            Brand.Value = brands.FirstOrDefault();
            Capaticy.Value = capacities.FirstOrDefault();
            Kind.Value = kinds.FirstOrDefault();
        }

        private async Task<VehicleParametersM> GetAvailableVehicleParameters()
        {
            var result = new VehicleParametersM();
            var domainVehicleParams = await VehicleService.GetVehiclesParams(RequestPriority.UserInitiated);
            Mapper.Map(domainVehicleParams, result);

            return result;
        }

        private void SetVehicleParameters(VehicleParametersM parameters)
        {
            vehicleParameters = parameters;
            InitByVehicleParameters(parameters);
        }
    }
}
