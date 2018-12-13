using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.Token;

namespace TransportSystems.Frontend.External.Interfaces.IdentityServer.Token
{
    public interface IIdentityTokenService
    {
        Task<bool> GetCode(string phone);

        Task<TokenM> GetToken(string phone, string code);

        Task<TokenM> RefreshToken(string refreshToken);
    }
}
