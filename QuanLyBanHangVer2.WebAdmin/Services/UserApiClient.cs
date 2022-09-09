using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using QuanLyBanHangVer2.ViewModel.Common.Api;
using QuanLyBanHangVer2.ViewModel.Common.Paging;
using QuanLyBanHangVer2.ViewModel.Common.Response;
using QuanLyBanHangVer2.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.WebAdmin.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseBase<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            var response = await client.PostAsync("/api/Users/Authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SuccessResponse<string>>(token);
            }
            else
            {
                var a = JsonConvert.DeserializeObject<ApiErrorResult<string>>(token);
                return a;
            }
        }

        public async Task<ResponseBase<string>> Create(CreateUserRequest request)
        {
            var sessions = httpContextAccessor.HttpContext.Session.GetString("Token");
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.PostAsync("/api/Users/Create", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SuccessResponse<string>>(result);
            }
            else
            {
                return JsonConvert.DeserializeObject<ApiErrorResult<string>>(result);
            }
        }

        public async Task<ResponseBase<UserVm>> GetById(Guid id)
        {
            var sessions = httpContextAccessor.HttpContext.Session.GetString("Token");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/users/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SuccessResponse<UserVm>>(body);
            }
            else
            {
                return JsonConvert.DeserializeObject<ApiErrorResult<UserVm>>(body);
            }
        }

        public async Task<ResponseBase<PagedResponse<UserVm>>> GetPagingUser(GetUserPagingRequest request)
        {
            var sessions = httpContextAccessor.HttpContext.Session.GetString("Token");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/users/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SuccessResponse<PagedResponse<UserVm>>>(body);
            }
            else
            {
                return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<UserVm>>>(body);
            }
        }

        public async Task<ResponseBase<string>> Edit(Guid id, UserUpdateRequest request)
        {
            var sessions = httpContextAccessor.HttpContext.Session.GetString("Token");
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.PutAsync($"/api/users/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SuccessResponse<string>>(result);
            }
            else
            {
                return JsonConvert.DeserializeObject<ApiErrorResult<string>>(result);
            }
        }
    }
}