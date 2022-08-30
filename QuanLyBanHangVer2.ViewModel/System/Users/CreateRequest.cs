using QuanLyBanHangVer2.ViewModel.Common;
using System;

namespace QuanLyBanHangVer2.ViewModel.System.Users
{
    public class CreateRequest : TokenRequestBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
    }
}