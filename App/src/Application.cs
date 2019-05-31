using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.App.Handlers;
using TransportSystems.Frontend.App.Utils;
using TransportSystems.Frontend.Core.Domain.Interfaces.Address;
using TransportSystems.Frontend.Core.Domain.Interfaces.Booking;
using TransportSystems.Frontend.Core.Domain.Interfaces.Cargo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Garages;
using TransportSystems.Frontend.Core.Domain.Interfaces.Identity;
using TransportSystems.Frontend.Core.Domain.Interfaces.Orders;
using TransportSystems.Frontend.Core.Domain.Interfaces.Settings;
using TransportSystems.Frontend.Core.Domain.Interfaces.SignUp;
using TransportSystems.Frontend.Core.Domain.Interfaces.Transport;
using TransportSystems.Frontend.Core.Domain.Interfaces.Utils;
using TransportSystems.Frontend.Core.Infrastructure.Business.Address;
using TransportSystems.Frontend.Core.Infrastructure.Business.Booking;
using TransportSystems.Frontend.Core.Infrastructure.Business.Cargo;
using TransportSystems.Frontend.Core.Infrastructure.Business.Garages;
using TransportSystems.Frontend.Core.Infrastructure.Business.Identity;
using TransportSystems.Frontend.Core.Infrastructure.Business.Orders;
using TransportSystems.Frontend.Core.Infrastructure.Business.Settings;
using TransportSystems.Frontend.Core.Infrastructure.Business.Signin;
using TransportSystems.Frontend.Core.Infrastructure.Business.SignUp;
using TransportSystems.Frontend.Core.Infrastructure.Business.Transport;
using TransportSystems.Frontend.Core.Infrastructure.Http;
using TransportSystems.Frontend.Core.Infrastructure.Http.Addresses;
using TransportSystems.Frontend.Core.Infrastructure.Http.Booking;
using TransportSystems.Frontend.Core.Infrastructure.Http.Cargo;
using TransportSystems.Frontend.Core.Infrastructure.Http.Garages;
using TransportSystems.Frontend.Core.Infrastructure.Http.Identity;
using TransportSystems.Frontend.Core.Infrastructure.Http.Orders;
using TransportSystems.Frontend.Core.Infrastructure.Http.SignUp;
using TransportSystems.Frontend.Core.Infrastructure.Http.Transport;
using TransportSystems.Frontend.Core.Infrastructure.Settings;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;
using TransportSystems.Frontend.Core.Services.Interfaces.Booking;
using TransportSystems.Frontend.Core.Services.Interfaces.Cargo;
using TransportSystems.Frontend.Core.Services.Interfaces.Garages;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.Orders;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;
using TransportSystems.Frontend.Core.Services.Interfaces.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.Transport;
using TransportSystems.Frontend.External.Business;
using TransportSystems.Frontend.External.Business.IdentityServer.Config;
using TransportSystems.Frontend.External.Business.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Business.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Business.IdentityServer.SignOut;
using TransportSystems.Frontend.External.Business.IdentityServer.Token;
using TransportSystems.Frontend.External.Business.IdentityServer.UserInfo;
using TransportSystems.Frontend.External.Business.Profiles;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Config;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Discovery;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Introspection;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.SignOut;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.Token;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.UserInfo;

namespace TransportSystems.Frontend.App
{
    public class Application : MvxApplication
    {
        public static string APIURL = "http://host.docker.internal:82";
        public static string IdentityServerURL = "http://host.docker.internal:82";

        private const string GrandType = "phone_number_token";
        private const string ClientId = "phone_number_authentication";
        private const string ClientSecret = "secret";
        private const string ApiName = "TSAPI";


        public override void Initialize()
        {
            RegisterRepositories();
            RegisterServices();

            RegisterCustomAppStart<CustomAppStart>();
        }

        public override Task Startup()
        {
            RegisterUtils();
            RegisterMapper();
            RegisterIdentityServerServices();

            return base.Startup();
        }

        protected virtual void RegisterServices()
        {
            Mvx.IoCProvider.RegisterType<ISignInSettingsService, SignInSettingsService>();
            Mvx.IoCProvider.RegisterType<ISignInService, SignInService>();
            Mvx.IoCProvider.RegisterType<ISignUpService, SignUpService>();
            Mvx.IoCProvider.RegisterType<IGarageService, GarageService>();
            Mvx.IoCProvider.RegisterType<IVehicleService, VehicleService>();
            Mvx.IoCProvider.RegisterType<IUserInfoService, UserInfoService>();
            Mvx.IoCProvider.RegisterType<IUserInfoSettingsService, UserInfoSettingsService>();
            Mvx.IoCProvider.RegisterType<IAddressService, AddressService>();
            Mvx.IoCProvider.RegisterType<ICargoService, CargoService>();
            Mvx.IoCProvider.RegisterType<IBookingService, BookingService>();
            Mvx.IoCProvider.RegisterType<IOrdersService, OrdersService>();
        }

        protected virtual void RegisterRepositories()
        {
            Mvx.IoCProvider.RegisterType<ISettingsRepository, SettingsRepository>();
            Mvx.IoCProvider.RegisterType<IUserInfoRepository, UserInfoRepository>();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISignUpRepository, SignUpRepository>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IVehicleRepository, VehicleRepository>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IGarageRepository, GarageRepository>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAddressRepository, AddressRepository>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ICargoRepository, CargoRepository>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBookingRepository, BookingRepository>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IOrdersRepository, OrdersRepository>();
        }

        protected virtual void RegisterIdentityServerServices()
        {
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IIdentityConfig>(() =>
            {
                return new IdentityConfig(IdentityServerURL, GrandType, ClientId, ClientSecret, ApiName);
            });

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IIdentityDiscoveryService, IdentityDiscoveryService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IIdentityIntrospectionService, IdentityIntrospectionService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IIdentityUserInfoService, IdentityUserInfoService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IIdentityTokenService, IdentityTokenService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ISignOutIdentityService, SignOutIdentityService>();
        }

        protected virtual void RegisterUtils()
        {
            Mvx.IoCProvider.RegisterType<IJsonConverter, CustomJsonConverter>();
            Mvx.IoCProvider.RegisterType<IClaimJsonConverter, CustomClaimJsonConverter>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAPIManager>(() =>
            {
                return new APIManager(APIURL, GetAuthenticatedMessageHandler());
            });

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMappingService, MappingService>();
        }

        protected virtual void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<IdentityServerProfile>();
                cfg.AddProfile<HttpMappingProfile>();
                cfg.AddProfile<AppProfile>();
            });

            Mvx.IoCProvider.RegisterType(() => Mapper.Instance);
        }

        protected HttpMessageHandler GetAuthenticatedMessageHandler()
        {
            var signInService = Mvx.IoCProvider.Resolve<ISignInService>();
            var handler = new AuthenticatedHttpClientHandler(signInService.GetToken)
            {
                AllowAutoRedirect = false
            };

            return handler;
        }
    }
}