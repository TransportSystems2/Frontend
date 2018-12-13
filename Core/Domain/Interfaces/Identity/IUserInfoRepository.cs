using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core.Identity;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Identity
{
    public interface IUserInfoRepository
    {
        Task<UserInfoDM> GetUserInfo(string token);
    }
}