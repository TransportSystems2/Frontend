using System.Collections.Generic;
using System.Security.Claims;

namespace TransportSystems.Frontend.External.Models.Models.IdentityServer.UserInfo
{
    public class UserInfoM
    {
        public UserInfoM()
        {
            Claims = new List<Claim>();
        }

        public List<Claim> Claims { get; set; }
    }
}