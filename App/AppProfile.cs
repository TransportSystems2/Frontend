using AutoMapper;
using TransportSystems.Frontend.App.Models.Geo;
using TransportSystems.Frontend.App.Models.Transport;
using TransportSystems.Frontend.App.Models.Users;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.Identity;
using TransportSystems.Frontend.Core.Domain.Core.SignIn;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.External.Models.Geo;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Token;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.UserInfo;
using TransportSystems.Frontend.External.Models.Transport;
using TransportSystems.Frontend.External.Models.Users;

namespace TransportSystems.Frontend.App
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
                CreateMap<TokenM, IdentityTokenDM>();
                CreateMap<UserInfoM, UserInfoDM>();
                CreateMap<AddressM, AddressDM>();
                CreateMap<DispatcherM, DispatcherDM>();
                CreateMap<DriverM, DriverDM>();
                CreateMap<VehicleM, VehicleDM>();
                CreateMap<VehicleParameterDM, VehicleParameterM>();
                CreateMap<VehicleParametersDM, VehicleParametersM>()
                .ForMember(dest => dest.Brands, opt => opt.MapFrom(src => src.Brands))
                .ForMember(dest => dest.Capacities, opt => opt.MapFrom(src => src.Capacities))
                .ForMember(dest => dest.Kinds, opt => opt.MapFrom(src => src.Kinds));
        }
    }
}