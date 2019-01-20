using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Booking;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Services.Interfaces.Orders;

namespace TransportSystems.Frontend.App.ViewModels.Customer
{
    public class CustomerViewModel : BaseViewModel<BookingDM>
    {
        public CustomerViewModel(IOrdersService ordersService)
        {
            OrdersService = ordersService;
            RegisterCommand = new MvxAsyncCommand(Register);
        }

        public readonly INC<string> Name = new NC<string>();

        public readonly INC<string> Phone = new NC<string>();

        public readonly INC<string> AditionalPhone = new NC<string>();

        protected IOrdersService OrdersService { get; }

        public IMvxCommand RegisterCommand;

        public override void Prepare()
        {
            base.Prepare();

            Name.Value = "Артем";
            Phone.Value = "79159881818";
            AditionalPhone.Value = "79159881818";
        }

        private async Task Register()
        {
            var customer = new CustomerDM
            {
                FirstName = Name.Value,
                LastName = Name.Value,
                PhoneNumber = Phone.Value
            };
            Model.Customer = customer;
            Model.TimeOfDelivery = DateTime.Now;

            await OrdersService.Create(Model, RequestPriority.UserInitiated);
        }
    }
}
