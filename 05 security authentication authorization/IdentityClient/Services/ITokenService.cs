using IdentityModel.Client;

namespace IdentityClient.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
        Task<bool> VerifyToken(string token);
        Task<TokenResponse> RefreshToken(string refreshToken);
    }
}