using TransportSystems.Frontend.Core.Domain.Core.Identity;
using TransportSystems.Frontend.Core.Domain.Interfaces.Settings;
using TransportSystems.Frontend.Core.Domain.Interfaces.Utils;
using TransportSystems.Frontend.Core.Services.Interfaces.Settings;

namespace TransportSystems.Frontend.Core.Infrastructure.Business.Settings
{
    public class UserInfoSettingsService : SettingsService, IUserInfoSettingsService
    {
        private const string StorageName = "UserInfoSettings";

        private const string UserInfoKey = "UserInfoKey";

        public UserInfoSettingsService(IClaimJsonConverter jsonSerializer, ISettingsRepository settingsRepository) : base(settingsRepository)
        {
            JsonSerializer = jsonSerializer;
        }

        protected IClaimJsonConverter JsonSerializer {get; }

        public bool ExistUserInfo()
        {
            return HasKey(UserInfoKey);
        }

        public UserInfoDM GetUserInfo()
        {
            var strUserInfo = Get(UserInfoKey);

            return JsonSerializer.DeserializeObject<UserInfoDM>(strUserInfo);
        }

        public void PutUserInfo(UserInfoDM userInfo)
        {
            var strUserInfo = JsonSerializer.SerializeObject(userInfo);

            Put(UserInfoKey, strUserInfo);
        }

        protected override string GetFileName()
        {
            return StorageName;
        }
    }
}
