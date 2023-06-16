using Microsoft.Identity.Client;

namespace EletroCheck.Models
{
    public class PowerBiAuthService
    {
        public async Task<string> GetAccessToken()
        {
            string clientId = "5d22adc0-7cd2-44c7-bfe7-505ec7ecc7bb";
            string clientSecret = "mnn8Q~xlZnUSBGjuwhKxhL3~CUxFWdNhtTmmTcEn";
            string tenantId = "c267dda3-cb7e-4abd-b21b-3150a5b83cd1";
            string authority = $"https://login.microsoftonline.com/{tenantId}";

            string[] scopes = new[] { "https://analysis.windows.net/powerbi/api/.default" };

            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(authority)
                .Build();

            var result = await app.AcquireTokenForClient(scopes)
                .ExecuteAsync();

            return result.AccessToken;
        }
    }
}
    

