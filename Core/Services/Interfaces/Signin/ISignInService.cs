using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core.SignIn;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Signin
{
    public interface ISignInService
    {
        bool IsSigned();

        Task<bool> Check();

        Task<bool> GetCodeAsync(string phone);

        Task<bool> AuthAsync(string phone, string code);

        Task<IdentityTokenDM> GetToken();

        Task<IdentityTokenDM> RefreshToken(IdentityTokenDM old);

        Task<bool> SignOut();
    }
}