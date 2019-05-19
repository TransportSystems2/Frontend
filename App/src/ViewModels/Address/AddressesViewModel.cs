using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.ViewModels.Booking;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;

namespace TransportSystems.Frontend.App.ViewModels.Address
{
    public class AddressesViewModel : BaseViewModel<BookingRequestDM>
    {
        public AddressesViewModel(IAddressService addressesService)
        {
            AddressesService = addressesService;

            NextCommand = new MvxAsyncCommand(NavigateToBookingView);
        }

        public readonly INC<string> StartAddressRequest = new NC<string>();

        public readonly INC<string> EndAddressRequest = new NC<string>();

        public readonly INC<ICollection<AddressDM>> StartDomainAddresses = new NC<ICollection<AddressDM>>();

        public readonly INC<ICollection<AddressDM>> EndDomainAddresses = new NC<ICollection<AddressDM>>();

        public readonly INC<AddressDM> SelectedStartAddress = new NC<AddressDM>();

        public readonly INC<AddressDM> SelectedEndAddressess = new NC<AddressDM>();

        public readonly INC<string> Comment = new NC<string>();

        public IMvxCommand NextCommand { get; }

        protected IAddressService AddressesService { get; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            StartAddressRequest.Changed += HandleFromAddressChanged;
            EndAddressRequest.Changed += HandleToAddressChanged;
        }


        public override void ViewDisappearing()
        {
            StartAddressRequest.Changed -= HandleFromAddressChanged;
            EndAddressRequest.Changed -= HandleToAddressChanged;

            base.ViewDisappearing();
        }

        private async Task NavigateToBookingView()
        {
            if (await InflateWaypointsModel())
            {
                await NavigationService.Navigate<BookingViewModel, BookingRequestDM>(Model);
            }
        }

        private Task<bool> InflateWaypointsModel()
        {
            if (SelectedStartAddress.Value == null || SelectedEndAddressess.Value == null)
            {
                return Task.FromResult(false);
            }

            Model.Waypoints.Points.Add(SelectedStartAddress.Value);
            Model.Waypoints.Points.Add(SelectedEndAddressess.Value);
            Model.Waypoints.Comment = Comment.Value;

            return Task.FromResult(true);
        }

        private async void HandleFromAddressChanged(object sender, EventArgs e)
        {
            SelectedStartAddress.Value = null;
            if (StartAddressRequest.Value.Length > 3)
            {
                StartDomainAddresses.Value = await AddressesService.GetAddresses(StartAddressRequest.Value, RequestPriority.UserInitiated);
            }
        }

        private async void HandleToAddressChanged(object sender, EventArgs e)
        {
            SelectedEndAddressess.Value = null;
            if (EndAddressRequest.Value.Length > 3)
            {
                EndDomainAddresses.Value = await AddressesService.GetAddresses(EndAddressRequest.Value, RequestPriority.UserInitiated);
            }
        }
    }
}