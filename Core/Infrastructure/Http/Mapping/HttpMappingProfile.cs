using AutoMapper;
using TransportSystems.Frontend.Core.Domain.Core.Billing;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Domain.Core.Transport;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.External.Models.Geo;
using TransportSystems.Frontend.External.Models.Models.Billing;
using TransportSystems.Frontend.External.Models.SignUp;
using TransportSystems.Frontend.External.Models.Transport;
using TransportSystems.Frontend.External.Models.Users;

namespace TransportSystems.Frontend.Core.Infrastructure.Http
{
    public class HttpMappingProfile : Profile
    {
        public HttpMappingProfile()
        {
            CreateMap<AddressEM, AddressDM>();
            CreateMap<DispatcherEM, DispatcherDM>();
            CreateMap<DriverEM, DriverDM>();
            CreateMap<VehicleEM, VehicleDM>();
            CreateMap<BillEM, BillDM>();

            CreateMap<VehicleParameterEM, VehicleParameterDM>();
            CreateMap<VehicleParametersEM, VehicleParametersDM>()
                .ForMember(dest => dest.Brands, opt => opt.MapFrom(src => src.Brands))
                .ForMember(dest => dest.Capacities, opt => opt.MapFrom(src => src.Capacities))
                .ForMember(dest => dest.Kinds, opt => opt.MapFrom(src => src.Kinds));

            CreateMap<DriverCompanyEM, DriverCompanyDM>();
        }
    }
}