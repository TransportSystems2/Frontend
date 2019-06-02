using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core.Identity;
using TransportSystems.Frontend.Core.Domain.Core.Users;
using TransportSystems.Frontend.Core.Domain.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.Identity;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Identity
{
    public class UserInfoService : IUserInfoService
    {
        public UserInfoService(ISignInService signInService, IUserInfoSettingsService userInfoSettingsService, IUserInfoRepository userInfoRepository)
        {
            SignInService = signInService;
            UserInfoSettingsService = userInfoSettingsService;
            UserInfoRepository = userInfoRepository;
        }

        protected ISignInService SignInService { get; }

        protected IUserInfoSettingsService UserInfoSettingsService { get; }

        protected IUserInfoRepository UserInfoRepository { get; }

        public async Task<UserInfoDM> UpdateUserInfo()
        {
            var token = await SignInService.GetToken();
            if (token == null)
            {
                throw new ArgumentNullException("can't get userInfo without token");
            }

            var userInfo = await UserInfoRepository.GetUserInfo(token.AccessToken);
            UserInfoSettingsService.PutUserInfo(userInfo);

            return userInfo;
        }

        public bool IsNewUser()
        {
            var isModerator = IsInRole(UserRoles.Moderator);
            var isDispatcher = IsInRole(UserRoles.Dispatcher);
            var isDriver = IsInRole(UserRoles.Driver);

            return !isModerator && !isDispatcher && !isDriver;
        }

        public bool IsInRole(string role)
        {
            bool result = false;
            if (UserInfoSettingsService.ExistUserInfo())
            {
                var userInfo = UserInfoSettingsService.GetUserInfo();
                result = IsInRole(userInfo.Claims, role);
            }

            return result;
        }

        private bool IsInRole(List<Claim> userInfo, string role)
        {
            return userInfo.Exists(c => c.Type.Equals("role") && c.Value.ToLower().Equals(role.ToLower()));
        }
    }
}