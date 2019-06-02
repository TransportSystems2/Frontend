namespace TransportSystems.Frontend.External.Models.Models.IdentityServer.Token
{
    public class TokenM
    {
        public int ExpiresIn { get; set; }

        public string TokenType { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
