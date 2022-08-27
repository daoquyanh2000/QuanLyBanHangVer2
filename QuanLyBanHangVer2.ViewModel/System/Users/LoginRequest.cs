using System;

namespace QuanLyBanHangVer2.ViewModel.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}