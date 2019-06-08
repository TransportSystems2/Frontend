using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.SignUp;

namespace TransportSystems.Frontend.External.SignUp
{
    public interface ISignUpAPI
    {
        [Post("/api/signup/company")]
        [Headers("Authorization: Bearer")]
        Task Register([Body(BodySerializationMethod.Json)] CompanyApplicationEM companyApplication);
    }
}
