using Microsoft.AspNetCore.Identity;
using QuanLyBanHangVer2.ViewModel.Common;
using QuanLyBanHangVer2.ViewModel.Common.Api;
using QuanLyBanHangVer2.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.WebAdmin.Services
{
    public interface IUserApiClient
    {
        public Task<ApiResult<string>> Authenticate(LoginRequest request);

        public Task<ApiResult<string>> Create(CreateUserRequest request);

        public Task<ApiResult<string>> Edit(Guid id, UserUpdateRequest request);

        public Task<ApiResult<UserVm>> GetById(Guid id);

        public Task<ApiResult<PagedResult<UserVm>>> GetPagingUser(GetUserPagingRequest request);
    }
}