using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Introspection;

namespace TransportSystems.Frontend.External.Interfaces.IdentityServer.Introspection
{
    public interface IIdentityIntrospectionService
    {
        Task<IntrospectionM> IntrospectToken(string accessToken);
    }
}
