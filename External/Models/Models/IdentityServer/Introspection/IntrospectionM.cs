using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace TransportSystems.Frontend.External.Models.Models.IdentityServer.Introspection
{
    public class IntrospectionM
    {
        public IntrospectionM()
        {
            Claims = new List<Claim>();
        }

        public bool IsActive { get; set; }

        public List<Claim> Claims { get; set; }
    }
}