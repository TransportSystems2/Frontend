using System.Threading.Tasks;
using TransportSystems.Frontend.Core.Domain.Core.Identity;

namespace TransportSystems.Frontend.Core.Services.Interfaces.Identity
{
    public interface IUserInfoService
    {
        Task<UserInfoDM> UpdateUserInfo();

        bool IsInRole(string role);

        bool IsNewUser();
    }
}