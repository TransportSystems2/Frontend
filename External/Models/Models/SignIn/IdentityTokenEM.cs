namespace TransportSystems.Frontend.External.Models.SignIn
{
    public class IdentityTokenEM
    {
        public string IdToken { get; set; }

        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }
    }
}