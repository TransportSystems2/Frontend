using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.SignUp;
using Refit;

namespace TransportSystems.Frontend.External.SignUp
{
    public interface ISignUpAPI
    {
        [Post("/api/signup/company")]
        [Headers("Authorization: Bearer")]
        Task Register([Body(BodySerializationMethod.Json)] CompanyApplicationEM companyApplication);
    }
}
