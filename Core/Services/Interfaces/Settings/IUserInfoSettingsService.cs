using TransportSystems.Frontend.Core.Domain.Core.Identity;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Settings
{
    public interface IUserInfoSettingsService
    {
        bool ExistUserInfo();

        UserInfoDM GetUserInfo();

        void PutUserInfo(UserInfoDM userInfo);
    }
}
