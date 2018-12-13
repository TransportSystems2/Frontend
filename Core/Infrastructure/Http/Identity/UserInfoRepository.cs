using System.Threading.Tasks;
using AutoMapper;
using TransportSystems.Frontend.Core.Domain.Core.Identity;
using TransportSystems.Frontend.Core.Domain.Interfaces.Identity;
using TransportSystems.Frontend.External.Interfaces.IdentityServer.UserInfo;

namespace TransportSystems.Frontend.Core.Infrastructure.Http.Identity
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public UserInfoRepository(IIdentityUserInfoService userInfoService)
        {
            UserInfoService = userInfoService;
        }

        protected IIdentityUserInfoService UserInfoService { get; }

        public async Task<UserInfoDM> GetUserInfo(string token)
        {
            var userInfo = await UserInfoService.GetUserInfo(token);

            return Mapper.Map<UserInfoDM>(userInfo);
        }
    }
}
