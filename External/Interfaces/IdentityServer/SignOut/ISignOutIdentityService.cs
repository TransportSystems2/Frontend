using System.Threading.Tasks;

namespace TransportSystems.Frontend.External.Interfaces.IdentityServer.SignOut
{
    public interface ISignOutIdentityService
    {
        Task<bool> SignOut(string accessToken);
    }
}