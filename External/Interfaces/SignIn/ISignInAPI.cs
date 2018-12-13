using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.SignIn;

namespace TransportSystems.Frontend.External.SignIn
{
    public interface ISignInAPI
    {
        Task<bool> CheckToken(IdentityTokenEM token);
    }
}