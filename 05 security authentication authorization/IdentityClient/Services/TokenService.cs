using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
// using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IdentityClient.Services
    {
    public class TokenService : ITokenService
        {
        private readonly ILogger<TokenService> _logger;
        private readonly IOptions<IdentityServerSettings> _identityServerSettings;
        private readonly HttpClient _httpClient;

        public TokenService(ILogger<TokenService> logger, IOptions<IdentityServerSettings> identityServerSettings)
            {
            _logger = logger;
            _identityServerSettings = identityServerSettings;
            _httpClient = new HttpClient();
            }

        public async Task<TokenResponse> GetToken(string scope)
            {
            var discoveryDocument = await _httpClient.GetDiscoveryDocumentAsync(_identityServerSettings.Value.DiscoveryUrl);
            if (discoveryDocument.IsError)
                {
                _logger.LogError($"Unable to get discovery document. Error is: {discoveryDocument.Error}");
                throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
                }

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = _identityServerSettings.Value.ClientName,
                ClientSecret = _identityServerSettings.Value.ClientPassword,
                Scope = scope
                });

            if (tokenResponse.IsError)
                {
                _logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
                }

            return tokenResponse;
            }

        public async Task<bool> VerifyToken(string token)
            {
            var discoveryDocument = await _httpClient.GetDiscoveryDocumentAsync(_identityServerSettings.Value.DiscoveryUrl);
            if (discoveryDocument.IsError)
                {
                _logger.LogError($"Unable to get discovery document. Error is: {discoveryDocument.Error}");
                return false;
                }

            var introspectionResponse = await _httpClient.IntrospectTokenAsync(new TokenIntrospectionRequest
                {
                Address = discoveryDocument.IntrospectionEndpoint,
                ClientId = _identityServerSettings.Value.ClientName,
                ClientSecret = _identityServerSettings.Value.ClientPassword,
                Token = token
                });

            if (introspectionResponse.IsError)
                {
                _logger.LogError($"Unable to verify token. Error is: {introspectionResponse.Error}");
                return false;
                }

            return introspectionResponse.IsActive;
            }

        public async Task<TokenResponse> RefreshToken(string refreshToken)
            {
            var discoveryDocument = await _httpClient.GetDiscoveryDocumentAsync(_identityServerSettings.Value.DiscoveryUrl);
            if (discoveryDocument.IsError)
                {
                _logger.LogError($"Unable to get discovery document. Error is: {discoveryDocument.Error}");
                throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
                }

            var tokenResponse = await _httpClient.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = _identityServerSettings.Value.ClientName,
                ClientSecret = _identityServerSettings.Value.ClientPassword,
                RefreshToken = refreshToken
                });

            if (tokenResponse.IsError)
                {
                _logger.LogError($"Unable to refresh token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to refresh token", tokenResponse.Exception);
                }

            return tokenResponse;
            }

        }
    }