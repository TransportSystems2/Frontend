using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.ViewModels.Customer;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Services.Interfaces.Booking;

namespace TransportSystems.Frontend.App.ViewModels.Booking
{
    public class BookingViewModel : BaseViewModel<BookingRequestDM>
    {
        public BookingViewModel(IBookingService bookingService)
        {
            BookingService = bookingService;
            NextCommand = new MvxAsyncCommand(Next);
        }

        public INC<ICollection<string>> Cities { get; } = new NC<ICollection<string>>();

        public INC<string> City { get; } = new NC<string>();

        public INC<int> Comission { get; } = new NC<int>();

        public INC<float> DegreeOfDificulty { get; } = new NC<float>();

        public INC<double> FeedDistance { get; } = new NC<double>();

        public INC<double> TotalDistance { get; } = new NC<double>();

        public INC<decimal> TotalPrice { get; } = new NC<decimal>();

        public IMvxCommand NextCommand { get; }

        protected BookingResponseDM BookingResponse { get; private set; }

        protected IBookingService BookingService { get; }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            City.Changed += HandleCityChanged;
        }

        public override void ViewDisappearing()
        {
            City.Changed -= HandleCityChanged;

            base.ViewDisappearing();
        }

        public async override Task Initialize()
        {
            await base.Initialize();

            await Calculate();
        }

        private async Task Calculate()
        {
            BookingResponse = await BookingService.Calculate(Model, RequestPriority.UserInitiated);

            var cities = BookingResponse.Routes.Select(i => i.Title);
            Cities.Value = cities.ToList();

            if (BookingResponse != null && BookingResponse.Routes != null && BookingResponse.Routes.Count > 0)
            {
                City.Value = BookingResponse.Routes[0].Title;
            }
        }

        private void ShowBookingRouteByCity(string city)
        {
            var route = BookingResponse.Routes.Find(r => r.Title.Equals(city));
            if (route != null)
            {
                Comission.Value = route.Bill.Info.CommissionPercentage;
                DegreeOfDificulty.Value = route.Bill.Info.DegreeOfDifficulty;
                FeedDistance.Value = route.FeedDistance.Meters;
                TotalDistance.Value = route.TotalDistance.Meters;
                TotalPrice.Value = route.Bill.TotalCost;
            }
        }

        private async Task Next()
        {
            var route = BookingResponse.Routes.Find(r => r.Title.Equals(City.Value));
            var booking = new BookingDM
            {
                MarketId = route.MarketId,
                Waypoints = Model.Waypoints,
                TimeOfDelivery = DateTime.Now.Add(route.AvgDeliveryTime),
                Customer = new CustomerDM(),
                Cargo = Model.Cargo,
                Bill = route.Bill
            };

            await NavigationService.Navigate<CustomerViewModel, BookingDM>(booking);
        }

        private void HandleCityChanged(object sender, EventArgs e)
        {
            ShowBookingRouteByCity(City.Value);
        }
    }
}
