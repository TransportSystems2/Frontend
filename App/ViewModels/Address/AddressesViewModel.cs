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

namespace TransportSystems.Frontend.App.ViewModels.Address
{
    public class AddressesViewModel : BaseViewModel<BookingRequestDM>
    {
        public AddressesViewModel(IAddressService addressesService)
        {
            AddressesService = addressesService;

            NextCommand = new MvxAsyncCommand(ShowBookingView);
        }

        public readonly INC<string> FromAddressRequest = new NC<string>();

        public readonly INC<string> ToAddressRequest = new NC<string>();

        public readonly INC<ICollection<AddressDM>> FromDomainAddresses = new NC<ICollection<AddressDM>>();

        public readonly INC<ICollection<AddressDM>> ToDomainAddresses = new NC<ICollection<AddressDM>>();

        public readonly INC<AddressDM> SelectedFromAddress = new NC<AddressDM>();

        public readonly INC<AddressDM> SelectedToAddressess = new NC<AddressDM>();

        public readonly INC<string> Comment = new NC<string>();

        public IMvxCommand NextCommand { get; }

        protected IAddressService AddressesService { get; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            FromAddressRequest.Changed += HandleFromAddressChanged;
            ToAddressRequest.Changed += HandleToAddressChanged;
        }


        public override void ViewDisappearing()
        {
            FromAddressRequest.Changed -= HandleFromAddressChanged;
            ToAddressRequest.Changed -= HandleToAddressChanged;

            base.ViewDisappearing();
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
            if (SelectedFromAddress.Value == null || SelectedToAddressess.Value == null)
            {
                return Task.FromResult(false);
            }

            Model.Waypoints.Points.Add(SelectedFromAddress.Value);
            Model.Waypoints.Points.Add(SelectedToAddressess.Value);
            Model.Waypoints.Comment = Comment.Value;

            return Task.FromResult(true);
        }

        private async void HandleFromAddressChanged(object sender, EventArgs e)
        {
            SelectedFromAddress.Value = null;
            if (FromAddressRequest.Value.Length > 3)
            {
                FromDomainAddresses.Value = await AddressesService.GetAddresses(FromAddressRequest.Value, RequestPriority.UserInitiated);
            }
        }

        private async void HandleToAddressChanged(object sender, EventArgs e)
        {
            SelectedToAddressess.Value = null;
            if (ToAddressRequest.Value.Length > 3)
            {
                ToDomainAddresses.Value = await AddressesService.GetAddresses(ToAddressRequest.Value, RequestPriority.UserInitiated);
            }
        }
    }
}