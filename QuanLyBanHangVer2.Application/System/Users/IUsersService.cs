using Microsoft.AspNetCore.Identity;
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
        Task<string> Authenticate(LoginRequest request);

        Task<IdentityResult> Register(RegisterRequest request);
    }
}