using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using MvvmValidation;
using TransportSystems.Frontend.App.Extensions;
using TransportSystems.Frontend.App.ViewModels.Address;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Services.Interfaces.Cargo;

namespace TransportSystems.Frontend.App.ViewModels.Cargo
{
    public class CargoViewModel : BaseViewModel<BookingRequestDM>
    {
        public CargoViewModel(ICargoService cargoService)
        {
            CargoService = cargoService;
            Validator = new ValidationHelper();
            NextCommand = new MvxAsyncCommand(ShowAddressView);
        }

        public readonly INC<ICollection<string>> Kinds = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Weights = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Brands = new NC<ICollection<string>>();

        public readonly INC<string> Kind = new NC<string>();

        public readonly INC<string> Weight = new NC<string>();

        public readonly INC<string> Brand = new NC<string>();

        public readonly INC<string> RegistrationNumber = new NC<string>();

        public readonly INC<bool> Validating = new NC<bool>();

        public readonly INC<Dictionary<string, string>> Errors = new NC<Dictionary<string, string>>();

        public IMvxCommand NextCommand { get; }

        protected ICargoService CargoService { get; }

        protected ValidationHelper Validator { get; set; }

        protected CargoCatalogItemsDM AvailableCatalogItems { get; private set; }

        public override void Prepare()
        {
            Title.Value = "Груз";

#if DEBUG
            RegistrationNumber.Value = "Х827МН76";
#endif

            RegistrationNumber.Changed += HandleRegistrationNumberChanged;

            Validator.AddAsyncRule(nameof(RegistrationNumber), RegistrationNumberValidator);

            base.Prepare();
        }

        public async override Task Initialize()
        {
            await InitAvailableCargoParams();

            await base.Initialize();
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
            var propertiesIsValide = await Validate();
            if (!propertiesIsValide)
            {
                return;
            }

            var modelIsInflated = await InflateCargoModel() && await InflateBascetModel();
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

        private async Task<bool> Validate(string propertyName = "")
        {
            try
            {
                Validating.Value = true;

                ValidationResult validationResult;
                if (!string.IsNullOrEmpty(propertyName))
                {
                    validationResult = await Validator.ValidateAsync(propertyName);
                }
                else
                {
                    validationResult = await Validator.ValidateAllAsync();
                }

                Errors.Value = validationResult.AsDictionary();

                return validationResult.IsValid;
            }
            finally
            {
                Validating.Value = false;
            }
        }

        private async Task<RuleResult> RegistrationNumberValidator()
        {
            try
            {
                var isEmpty = string.IsNullOrEmpty(RegistrationNumber.Value);
                if (isEmpty)
                {
                    return RuleResult.Invalid($"Укажите регистрационный номер. Пример: Д000ЧЮ77");
                }

                var isValid = await CargoService.ValidateRegistrationNumber(RegistrationNumber.Value, RequestPriority.UserInitiated);
                if (!isValid)
                {
                    return RuleResult.Invalid($"Регистрационный номер {RegistrationNumber.Value} не корректен. Пример: Д000ЧЮ77");
                }

                return RuleResult.Valid();
            }
            catch(Exception)
            {
                //TODO залогировать причину возникновения ошибки
                return RuleResult.Invalid("Ошибка валидации регистрационного номера");
            }
        }

        private async void HandleRegistrationNumberChanged(object sender, EventArgs e)
        {
            if (RegistrationNumber.Value.Length > 7)
            {
                await Validate(nameof(RegistrationNumber));
            }
        }
    }
}