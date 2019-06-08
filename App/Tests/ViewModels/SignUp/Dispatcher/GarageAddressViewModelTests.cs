using System.Collections.Generic;
using Moq;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using NUnit.Framework;
using TransportSystems.Frontend.App.ViewModels.SignUp;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;

namespace TransportSystems.Frontend.App.Tests.ViewModels.SignUp.Dispatcher
{
    public class GarageAddressViewModelTests : MvxIoCSupportingTest
    {
        [Test]
        public void ResponseAddressess()
        {
            Setup();

            var vm = Ioc.IoCConstruct<GarageAddressViewModel>();
            vm.ViewAppearing();
            vm.AddressRequest.Value = "Ярославская область, рыбинск, Ленина 122";

            Assert.AreEqual(vm.AddressesResponse.Value.Count, 2);
        }

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();

            ICollection<AddressDM> addressess = new List<AddressDM>
            {
                new AddressDM { Country = "Russian Federation" },
                new AddressDM { Country = "Russian Federation" }
            };

            var addressService = new Mock<IAddressService>();
            addressService
                .Setup(m => m.GetAddresses(
                    It.IsAny<string>(),
                    RequestPriority.UserInitiated))
                .ReturnsAsync(addressess);

            Ioc.RegisterSingleton(addressService.Object);

            var navigationService = new Mock<IMvxNavigationService>();
            Ioc.RegisterSingleton(navigationService.Object);
        }
    }
}