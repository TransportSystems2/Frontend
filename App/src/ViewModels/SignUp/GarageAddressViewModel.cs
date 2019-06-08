using System;
using System.Collections.Generic;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.Models.SignUp;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class GarageAddressViewModel : BaseViewModel<CompanyApplicationM>
    {
        public GarageAddressViewModel(IAddressService addressService)
        {
            AddressService = addressService;
        }

        public INC<string> AddressRequest { get; } = new NC<string>();

        public INC<ICollection<AddressDM>> AddressesResponse { get; } = new NC<ICollection<AddressDM>>();

        protected IAddressService AddressService { get; private set; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            AddressRequest.Changed += HandleAddressRequestChanged;
        }

        public override void ViewDisappearing()
        {
            AddressRequest.Changed -= HandleAddressRequestChanged;

            base.ViewDisappearing();
        }

        private async void HandleAddressRequestChanged(object sender, EventArgs e)
        {
            AddressesResponse.Value = await AddressService.GetAddresses(AddressRequest.Value, RequestPriority.UserInitiated);
        }
    }
}
