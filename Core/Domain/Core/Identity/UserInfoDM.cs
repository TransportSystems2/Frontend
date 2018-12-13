using System.Collections.Generic;
using System.Security.Claims;

namespace TransportSystems.Frontend.Core.Domain.Core.Identity
{
    public class UserInfoDM
    {
        public UserInfoDM()
        {
            Claims = new List<Claim>();
        }

        public List<Claim> Claims { get; set; }
    }
}