using Microsoft.AspNetCore.Identity;
using QuanLyBanHangVer2.ViewModel.Common;
using QuanLyBanHangVer2.ViewModel.Common.Api;
using QuanLyBanHangVer2.ViewModel.Common.Paging;
using QuanLyBanHangVer2.ViewModel.Common.Response;
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
        Task<ResponseBase<string>> Authenticate(LoginRequest request);

        Task<ResponseBase<bool>> Create(CreateUserRequest request);

        Task<ResponseBase<string>> Update(Guid Id, UserUpdateRequest request);

        Task<ResponseBase<UserVm>> GetById(Guid Id);

        Task<ResponseBase<bool>> Delete(Guid Id);

        Task<PagedResponse<List<UserVm>>> UserPaging(UserPagingRequest request);
    }
}