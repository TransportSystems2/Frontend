using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.ViewModels.Booking;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;
using TransportSystems.Frontend.Extensions;

namespace TransportSystems.Frontend.App.ViewModels.Address
{
    public class AddressesViewModel : BaseViewModel<BookingRequestDM>
    {
        public AddressesViewModel(IAddressService addressesService)
        {
            AddressesService = addressesService;

            NextCommand = new MvxAsyncCommand(ShowBookingView);
        }

        public readonly INC<string> FromLabel = new NC<string>();

        public readonly INC<string> ToLabel = new NC<string>();

        public readonly INC<string> Request = new NC<string>();

        public readonly INC<ICollection<string>> Addresses = new NC<ICollection<string>>();

        public readonly INC<string> FromAddress = new NC<string>();

        public readonly INC<string> ToAddress = new NC<string>();

        public IMvxCommand NextCommand { get; }

        protected AddressDM ToDomainAddress { get; private set; }

        protected AddressDM FromDomainAddress { get; private set; }

        protected ICollection<AddressDM> AvailableAddresses { get; private set; }

        protected IAddressService AddressesService { get; }

        public override void Prepare()
        {
            base.Prepare();

            FromLabel.Value = "От";
            ToLabel.Value = "До";

            Addresses.Value = new List<string>();

            Request.Changed += HandleRequestChanged;
            ToAddress.Changed += HandleToAddressChanged;
            FromAddress.Changed += HandleFromAddressChanged;
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            Request.Changed -= HandleRequestChanged;
            ToAddress.Changed -= HandleToAddressChanged;
            FromAddress.Changed -= HandleFromAddressChanged;

            base.ViewDestroy(viewFinishing);
        }

        private async Task InitAddressess(string request)
        {
            AvailableAddresses = await AddressesService.GetAddresses(request, RequestPriority.UserInitiated);

            var addresses = AvailableAddresses.Select(i => i.ToString());
            Addresses.Value.ClearAndAddRange(addresses);
        }

        private async Task ShowBookingView()
        {
            if (await InflateWaypointsModel())
            {
                await NavigationService.Navigate<BookingViewModel, BookingRequestDM>(Model);
            }
        }

        private Task<bool> InflateWaypointsModel()
        {
            Model.Waypoints.Points.Add(FromDomainAddress);
            Model.Waypoints.Points.Add(ToDomainAddress);

            return Task.FromResult(true);
        }

        private async void HandleRequestChanged(object sender, EventArgs e)
        {
            if (Request.Value.Length > 3)
            {
                await InitAddressess(Request.Value);
            }
        }

        private void HandleToAddressChanged(object sender, EventArgs e)
        {
            ToDomainAddress = AvailableAddresses.FirstOrDefault(a => a.ToString().Equals(ToAddress.Value));
        }

        private void HandleFromAddressChanged(object sender, EventArgs e)
        {
            FromDomainAddress = AvailableAddresses.FirstOrDefault(a => a.ToString().Equals(FromAddress.Value));
        }
    }
}
