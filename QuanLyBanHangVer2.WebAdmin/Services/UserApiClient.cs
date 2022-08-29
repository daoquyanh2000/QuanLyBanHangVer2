using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using QuanLyBanHangVer2.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.WebAdmin.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            var response = await client.PostAsync("/api/Login/Authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public async Task<IdentityResult> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}