using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.SignUp;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.SignUp
{
    public interface ISignUpRepository
    {
        Task Register(CompanyApplicationDM companyApplication, RequestPriority priority);
    }
}