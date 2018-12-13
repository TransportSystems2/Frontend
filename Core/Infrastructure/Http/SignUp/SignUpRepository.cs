using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Domain.Interfaces.SignUp;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Models.SignUp;
using TransportSystems.Frontend.External.SignUp;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.SignUp
{
    public class SignUpRepository : ApiRepository<ISignUpAPI>, ISignUpRepository
    {
        public SignUpRepository(IAPIManager apiManager)
            : base(apiManager)
        {
        }

        public Task RegisterDispatcher(DispatcherCompanyDM dispatcherCompany, RequestPriority priority)
        {
            var company = Mapper.Map<DispatcherCompanyEM>(dispatcherCompany);
            var api = GetApi(priority);
            return api.RegisterDispatcher(company);
        }

        public Task RegisterDriver(DriverCompanyDM driverCompany, RequestPriority priority)
        {
            var company = Mapper.Map<DriverCompanyEM>(driverCompany);
            var api = GetApi(priority);

            return api.RegisterDriver(company);
        }
    }
}