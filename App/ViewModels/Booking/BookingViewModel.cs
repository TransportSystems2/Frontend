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

        public INC<ICollection<string>> Cities = new NC<ICollection<string>>();

        public INC<string> City = new NC<string>();

        public INC<int> Comission = new NC<int>();

        public INC<float> DegreeOfDificulty = new NC<float>();

        public INC<int> FeedDuration = new NC<int>();

        public INC<int> FeedDistance = new NC<int>();

        public INC<int> TotalDistance = new NC<int>();

        public INC<decimal> TotalPrice = new NC<decimal>();

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
                FeedDuration.Value = route.FeedDuration;
                FeedDistance.Value = route.FeedDistance;
                TotalDistance.Value = route.TotalDistance;
                TotalPrice.Value = route.Bill.TotalCost;
            }
        }

        private async Task Next()
        {
            var route = BookingResponse.Routes.Find(r => r.Title.Equals(City.Value));
            var booking = new BookingDM
            {
                Customer = new CustomerDM(),
                RootAddress = route.RootAddress,
                Waypoints = Model.Waypoints,
                Cargo = Model.Cargo,
                Basket = Model.Basket,
                BillInfo = route.Bill.Info
            };

            await NavigationService.Navigate<CustomerViewModel, BookingDM>(booking);
        }

        private void HandleCityChanged(object sender, EventArgs e)
        {
            ShowBookingRouteByCity(City.Value);
        }
    }
}
