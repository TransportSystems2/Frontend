using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;

namespace TransportSystems.Frontend.Core.Services.Interfaces.SignUp
{
    public interface ISignUpService
    {
        Task Register(CompanyApplicationDM companyApplication, RequestPriority priority);
    }
}
