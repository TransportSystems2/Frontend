using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;

namespace TransportSystems.Frontend.Core.Services.Interfaces.SignUp
{
    public interface ISignUpService
    {
        Task RegisterDispatcher(DispatcherCompanyDM dispatcherCompany, RequestPriority priority);

        Task RegisterDriver(DriverCompanyDM driverCompany, RequestPriority priority);
    }
}
