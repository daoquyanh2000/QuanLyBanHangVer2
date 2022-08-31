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
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageSize = 1, int PageIndex = 1)
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
        [AllowAnonymous]
        public IActionResult Login()

        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            else
            {
                var token = await _userApiClient.Authenticate(request);
                if (string.IsNullOrEmpty(token))
                {
                    return View(request);
                }
                HttpContext.Session.SetString("Token", token);
                var userPrincipal = ValidateToken(token);
                //create cookie authenticate
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(3),
                    IsPersistent = request.RememberMe
                };
                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest request)
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
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    return View(request);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Login", "User");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}