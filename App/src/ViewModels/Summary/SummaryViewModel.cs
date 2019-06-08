using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Services.Interfaces.Orders;

namespace TransportSystems.Frontend.App.ViewModels.Summary
{
    public class SummaryViewModel : BaseViewModel<BookingDM>
    {
        public readonly INC<DateTime> TimeOfDelivery = new NC<DateTime>();
        public readonly INC<string> OrderStatus = new NC<string>();

        public readonly INC<string> CustomerName = new NC<string>();
        public readonly INC<string> CustomerPhone = new NC<string>();

        public readonly INC<string> CargoType = new NC<string>();
        public readonly INC<string> CargoWeight = new NC<string>();
        public readonly INC<string> CargoBrand = new NC<string>();
        public readonly INC<string> CargoRegNumber = new NC<string>();
        public readonly INC<int> LockedWheels = new NC<int>();
        public readonly INC<string> LockedSteering = new NC<string>();
        public readonly INC<string> Ditch = new NC<string>();
        public readonly INC<string> Overturned = new NC<string>();
        public readonly INC<string> CargoComment = new NC<string>();

        public readonly INC<AddressDM> StartAddress = new NC<AddressDM>();
        public readonly INC<AddressDM> EndAddressess = new NC<AddressDM>();
        public readonly INC<string> AddressComment = new NC<string>();

        public readonly INC<string> City = new NC<string>();
        public readonly INC<string> Garage = new NC<string>();
        public readonly INC<int> Comission = new NC<int>();
        public readonly INC<float> DegreeOfDificulty = new NC<float>();

        public readonly INC<int> FeedDuration = new NC<int>();
        public readonly INC<int> FeedDistance = new NC<int>();
        public readonly INC<int> TotalDistance = new NC<int>();
        public readonly INC<decimal> TotalPrice = new NC<decimal>();

        public SummaryViewModel(IOrdersService ordersService)
        {
            OrdersService = ordersService;
            AddOrderCommand = new MvxAsyncCommand(AddOrder);
            CancelCommand = new MvxAsyncCommand(Cancel);
        }

        public ICommand AddOrderCommand { get; }

        public ICommand CancelCommand { get; }

        protected IOrdersService OrdersService { get; }

        public override void Prepare(BookingDM parameter)
        {
            base.Prepare(parameter);

            InitOrder();
            InitCustomer();
            InitCargo();
            InitBasket();
            InitAddressess();
            InitBooking();
        }

        private void InitOrder()
        {
            TimeOfDelivery.Value = Model.TimeOfDelivery;
            OrderStatus.Value = "новый";
        }

        private void InitCustomer()
        {
            CustomerName.Value = $"{Model.Customer.FirstName} {Model.Customer.LastName}";
            CustomerPhone.Value = Model.Customer.PhoneNumber;
        }

        private void InitCargo()
        {
            CargoType.Value = Model.Cargo.KindCatalogItemId.ToString();
            CargoWeight.Value = Model.Cargo.WeightCatalogItemId.ToString();
            CargoBrand.Value = Model.Cargo.BrandCatalogItemId.ToString();
            CargoRegNumber.Value = Model.Cargo.RegistrationNumber;
            CargoComment.Value = Model.Cargo.Comment;
        }

        private void InitBasket()
        {
            LockedWheels.Value = Model.Bill.Basket.LockedWheelsValue;
            LockedSteering.Value = Model.Bill.Basket.LockedSteeringValue == 1 ? "да" : "нет";
            Ditch.Value = Model.Bill.Basket.DitchValue == 1 ? "да" : "нет";
            Overturned.Value = Model.Bill.Basket.OverturnedValue == 1 ? "да" : "нет";
        }

        private void InitAddressess()
        {
            var waypointsExists = Model.Waypoints != null && Model.Waypoints.Points != null;
            if (!waypointsExists)
            {
                return;
            }

            var waypointsIsEmpty = Model.Waypoints.Points.Count == 0;
            if (!waypointsIsEmpty && Model.Waypoints.Points.Count > 1)
            {
                StartAddress.Value = Model.Waypoints.Points[0];
                EndAddressess.Value = Model.Waypoints.Points[1];
            }

            AddressComment.Value = Model.Waypoints.Comment;
        }

        private void InitBooking()
        {
            City.Value = Model.MarketId.ToString();
            Garage.Value = Model.MarketId.ToString();
            Comission.Value = Model.Bill.Info.CommissionPercentage;
            DegreeOfDificulty.Value = Model.Bill.Info.DegreeOfDifficulty;
        }

        private async Task AddOrder()
        {
            await OrdersService.Create(Model, RequestPriority.UserInitiated);
            await NavigationService.Close(this);
        }

        private async Task Cancel()
        {
            await NavigationService.Close(this);
        }
    }
}