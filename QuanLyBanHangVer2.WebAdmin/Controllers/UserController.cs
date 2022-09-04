using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using QuanLyBanHangVer2.ViewModel.System.Users;
using QuanLyBanHangVer2.WebAdmin.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.WebAdmin.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageSize = 10, int PageIndex = 1)
        {
            var request = new GetUserPagingRequest()
            {
                keyword = keyword,
                PageSize = pageSize,
                PageIndex = PageIndex,
                BearerToken = HttpContext.Session.GetString("Token"),
            };
            var users = await _userApiClient.GetPagingUser(request);
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            else
            {
                var result = await _userApiClient.Create(request);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return View(request);
                }
            }
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            else
            {
                var result = await _userApiClient.Create(request);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return View(request);
                }
            }
        }
    }
}