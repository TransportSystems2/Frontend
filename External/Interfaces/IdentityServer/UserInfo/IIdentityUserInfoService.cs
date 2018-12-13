using System;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.Models.IdentityServer.UserInfo;

namespace TransportSystems.Frontend.External.Interfaces.IdentityServer.UserInfo
{
    public interface IIdentityUserInfoService
    {
        Task<UserInfoM> GetUserInfo(string token);
    }
}
