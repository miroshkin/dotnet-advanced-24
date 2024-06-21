using IdentityModel.Client;

namespace IdentityClient.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
