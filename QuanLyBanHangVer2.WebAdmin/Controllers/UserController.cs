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
    public class UserController : Controller
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
            };
            var data = await _userApiClient.GetPagingUser(request);
            return View(data.Items);
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
                ModelState.AddModelError("", result.Message);
                if (result.IsSuccessed)
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
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.Items;
                var updateRequest = new UserUpdateRequest()
                {
                    Dob = user.Dob,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Id = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            else
            {
                var result = await _userApiClient.Edit(request.Id, request);
                ModelState.AddModelError("", result.Message);
                if (result.IsSuccessed)
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