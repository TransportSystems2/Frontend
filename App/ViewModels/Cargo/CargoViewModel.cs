using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.ViewModels.Address;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Services.Interfaces.Cargo;
using TransportSystems.Frontend.Extensions;

namespace TransportSystems.Frontend.App.ViewModels.Cargo
{
    public class CargoViewModel : BaseViewModel<BookingRequestDM>
    {
        public CargoViewModel(ICargoService cargoService)
        {
            CargoService = cargoService;
            NextCommand = new MvxAsyncCommand(ShowAddressView);
        }

        public readonly INC<ICollection<string>> Kinds = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Weights = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Brands = new NC<ICollection<string>>();

        public readonly INC<string> KindLabel = new NC<string>();

        public readonly INC<string> Kind = new NC<string>();

        public readonly INC<string> BrandLabel = new NC<string>();

        public readonly INC<string> Brand = new NC<string>();

        public readonly INC<string> WeightLabel = new NC<string>();

        public readonly INC<string> Weight = new NC<string>();

        public readonly INC<string> RegistrationNumberLabel = new NC<string>();

        public readonly INC<string> RegistrationNumber = new NC<string>();

        public readonly INC<string> NextButtonLabel = new NC<string>();

        public IMvxCommand NextCommand { get; }

        protected CargoCatalogItemsDM AvailableCatalogItems { get; private set; }

        protected ICargoService CargoService { get; }

        public override void Prepare()
        {
            Title.Value = "Груз";

            KindLabel.Value = "Тип";
            WeightLabel.Value = "Вес";
            BrandLabel.Value = "Марка";
            RegistrationNumberLabel.Value = "Гос. номер";
            NextButtonLabel.Value = "Далее";

#if DEBUG
            RegistrationNumber.Value = "Х827МН76";
#endif

            base.Prepare();
        }

        public override async void Start()
        {
            base.Start();

            await InitAvailableCargoParams();
        }

        private async Task InitAvailableCargoParams()
        {
            AvailableCatalogItems = await CargoService.GetAvailableParams(RequestPriority.UserInitiated);

            var brands = AvailableCatalogItems.Brands.Select(i => i.Name);
            Brands.Value = brands.ToList();
            Brand.Value = brands.FirstOrDefault();

            var kinds = AvailableCatalogItems.Kinds.Select(i => i.Name);
            Kinds.Value = kinds.ToList();
            Kind.Value = kinds.FirstOrDefault();

            var weights = AvailableCatalogItems.Weights.Select(i => i.Name);
            Weights.Value = weights.ToList();
            Weight.Value = weights.FirstOrDefault();
        }

        private async Task ShowAddressView()
        {
            var modelIsInflated = (await InflateCargoModel() && await InflateBascetModel());
            if (modelIsInflated)
            {
                await NavigationService.Navigate<AddressesViewModel, BookingRequestDM>(Model);
            }
        }

        private Task<bool> InflateCargoModel()
        {
            var kind = AvailableCatalogItems.Kinds.FirstOrDefault(k => k.Name.Equals(Kind.Value));
            var weight = AvailableCatalogItems.Weights.FirstOrDefault(w => w.Name.Equals(Weight.Value));
            var brand = AvailableCatalogItems.Brands.FirstOrDefault(b => b.Name.Equals(Brand.Value));

            Model.Cargo.KindCatalogItemId = kind.Id;
            Model.Cargo.WeightCatalogItemId = weight.Id;
            Model.Cargo.BrandCatalogItemId = brand.Id;

            return Task.FromResult(true);
        }

        private Task<bool> InflateBascetModel()
        {
            Model.Basket.KmValue = 300;
            Model.Basket.LoadingValue = 1;
            Model.Basket.DitchValue = 1;

            return Task.FromResult(true);
        }
    }
}