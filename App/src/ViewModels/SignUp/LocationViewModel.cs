using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class LocationViewModel : BaseViewModel<CompanyApplicationDM>
    {
        public LocationViewModel(IAddressService addressesService)
        {
            AddressesService = addressesService;

            NextCommand = new MvxAsyncCommand(Next);
        }

        public readonly INC<string> AddressRequest = new NC<string>();

        public readonly INC<ICollection<AddressDM>> AddressesResponse = new NC<ICollection<AddressDM>>();

        public readonly INC<AddressDM> SelectedAddress = new NC<AddressDM>();

        public IMvxCommand NextCommand { get; private set; }

        public override void Prepare()
        {
            base.Prepare();

#if DEBUG
            AddressRequest.Value = "9 мая рыбинск";
#endif
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            AddressRequest.Changed += HandleFromAddressChanged;
        }

        public override void ViewDisappearing()
        {
            AddressRequest.Changed -= HandleFromAddressChanged;

            base.ViewDisappearing();
        }

        protected IAddressService AddressesService { get; }

        protected async Task Next()
        {
            Model.GarageAddress = SelectedAddress.Value;

            await NavigationService.Navigate<VehicleViewModel, CompanyApplicationDM>(Model);
        }

        private async void HandleFromAddressChanged(object sender, EventArgs e)
        {
            SelectedAddress.Value = null;
            if (AddressRequest.Value.Length > 3)
            {
                AddressesResponse.Value = await AddressesService.GetAddresses(AddressRequest.Value, RequestPriority.UserInitiated);
            }
        }
    }
}