using Microsoft.AspNetCore.Identity;
using QuanLyBanHangVer2.ViewModel.Common.Paging;
using QuanLyBanHangVer2.ViewModel.Common.Response;
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
        public Task<ResponseBase<string>> Authenticate(LoginRequest request);

        public Task<ResponseBase<string>> Create(CreateUserRequest request);

        public Task<ResponseBase<string>> Edit(Guid id, UserUpdateRequest request);

        public Task<ResponseBase<UserVm>> GetById(Guid id);

        public Task<ResponseBase<PagedResponse<UserVm>>> GetPagingUser(GetUserPagingRequest request);
    }
}