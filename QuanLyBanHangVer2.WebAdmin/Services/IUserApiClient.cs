using Microsoft.AspNetCore.Identity;
using QuanLyBanHangVer2.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.WebAdmin.Services
{
    public interface IUserApiClient
    {
        public Task<string> Authenticate(LoginRequest request);

        public Task<IdentityResult> Register(RegisterRequest request);
    }
}