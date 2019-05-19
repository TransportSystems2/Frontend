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

        public Task Register(CompanyApplicationDM companyApplication, RequestPriority priority)
        {
            return Repository.Register(companyApplication, priority);
        }
    }
}
