using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;
using TransportSystems.Frontend.Core.Domain.Interfaces.SignUp;
using TransportSystems.Frontend.Core.Services.Interfaces.SignUp;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.SignUp
{
    public class SignUpService : ISignUpService
    {
        public SignUpService(ISignUpRepository repository)
        {
            Repository = repository;
        }

        protected ISignUpRepository Repository { get; }

        public Task RegisterDispatcher(DispatcherCompanyDM dispatcherCompany, RequestPriority priority)
        {
            return Repository.RegisterDispatcher(dispatcherCompany, priority);
        }

        public Task RegisterDriver(DriverCompanyDM driverCompany, RequestPriority priority)
        {
            return Repository.RegisterDriver(driverCompany, priority);
        }
    }
}
