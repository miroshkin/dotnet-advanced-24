using IdentityClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Entities;
using IdentityClient.Services;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace IdentityClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenService _tokenService;
        private static HttpClient? _httpClient;

        public HomeController(ITokenService tokenService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _tokenService = tokenService;
            _httpClient ??= new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Catalog()
        {
            var token = await _tokenService.GetToken("catalogapi.read");
            var refreshToken = token.RefreshToken;
            var accessToken = token.AccessToken;

            var isVerified = await _tokenService.VerifyToken(accessToken);


            _httpClient.SetBearerToken(accessToken);

            var result = await _httpClient.GetAsync("https://localhost:7295/Category/1");

            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<Category>(model);

                return View(data);

            }

            throw new Exception("Unable to get content");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
