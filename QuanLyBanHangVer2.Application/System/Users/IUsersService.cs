using Microsoft.AspNetCore.Identity;
using QuanLyBanHangVer2.ViewModel.Common;
using QuanLyBanHangVer2.ViewModel.Common.Api;
using QuanLyBanHangVer2.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.System.Users
{
    public interface IUsersService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Create(CreateUserRequest request);

        Task<ApiResult<string>> Update(Guid Id, UserUpdateRequest request);

        Task<ApiResult<UserVm>> GetById(Guid Id);

        Task<ApiResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
    }
}