using System;
using TransportSystems.Frontend.External.Interfaces.IdentityServer;

namespace TransportSystems.Frontend.External.Business.IdentityServer
{
    public class ExternalIdentityServerConfig : IExternalIdentityServerConfig
    {
        public string Address { get; set; }
    }
}
