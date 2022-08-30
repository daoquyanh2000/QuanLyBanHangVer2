using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangVer2.ViewModel.System.Users;
using QuanLyBanHangVer2.WebAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.WebAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            else
            {
                var token = await _userApiClient.Authenticate(request);

                return View(token);
            }
        }
    }
}