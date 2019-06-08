using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using MvvmValidation;
using TransportSystems.Frontend.App.Extensions;
using TransportSystems.Frontend.App.ViewModels.Summary;
using TransportSystems.Frontend.Core.Domain.Core.Booking;

namespace TransportSystems.Frontend.App.ViewModels.Customer
{
    public class CustomerViewModel : BaseViewModel<BookingDM>
    {
        public CustomerViewModel()
        {
            Validator = new ValidationHelper();
            NextCommand = new MvxAsyncCommand(NavigateToSummaryView);
        }

        public INC<string> Name { get; } = new NC<string>();

        public INC<string> Phone { get; } = new NC<string>();

        public INC<string> AditionalPhone { get; } = new NC<string>();

        public INC<bool> Validating { get; } = new NC<bool>();

        public INC<Dictionary<string, string>> Errors { get; } = new NC<Dictionary<string, string>>();

        public IMvxCommand NextCommand { get; }

        protected ValidationHelper Validator { get; }

        public override void Prepare()
        {
            base.Prepare();

            Validator.AddRule(nameof(Phone), PhoneValidator);
            Validator.AddRule(nameof(Name), NameValidator);
        }

        private async Task NavigateToSummaryView()
        {
            var propertiesIsValide = await Validate();
            if (!propertiesIsValide)
            {
                return;
            }

            var modelIsInflated = await InflateModel();
            if (modelIsInflated)
            {
                await NavigationService.Navigate<SummaryViewModel, BookingDM>(Model);
            }
        }

        private Task<bool> InflateModel()
        {
            Model.Customer.FirstName = Name.Value;
            Model.Customer.PhoneNumber = Phone.Value;

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

                Errors.Value = validationResult.AsErrorDictionary();

                return validationResult.IsValid;
            }
            finally
            {
                Validating.Value = false;
            }
        }

        private RuleResult NameValidator()
        {
            var isEmpty = string.IsNullOrEmpty(Name.Value);
            if (isEmpty)
            {
                return RuleResult.Invalid($"Укажите имя клиента");
            }

            return RuleResult.Valid();
        }

        private RuleResult PhoneValidator()
        {
            var isEmpty = string.IsNullOrEmpty(Phone.Value);
            if (isEmpty)
            {
                return RuleResult.Invalid($"Укажите номер телефона");
            }

            return RuleResult.Valid();
        }
    }
}
