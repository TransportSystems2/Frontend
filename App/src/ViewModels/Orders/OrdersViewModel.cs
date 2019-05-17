using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using TransportSystems.Frontend.App.ViewModels.Cargo;
using TransportSystems.Frontend.Core.Domain.Core.Booking;

namespace TransportSystems.Frontend.App.ViewModels.Orders
{
    public class OrdersViewModel : BaseViewModel
    {
        public OrdersViewModel()
        {
            AddOrderCommand = new MvxAsyncCommand(ShowNewOrderScreen);
        }

        public IMvxCommand AddOrderCommand { get; }

        protected BookingRequestDM BookingRequest { get; private set; }

        private async Task ShowNewOrderScreen()
        {
            BookingRequest = new BookingRequestDM();
            await NavigationService.Navigate<CargoViewModel, BookingRequestDM>(BookingRequest);
        }
    }
}