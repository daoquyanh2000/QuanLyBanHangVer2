using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangVer2.Application.System.Users;
using QuanLyBanHangVer2.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyBanHangVer2.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var resultTokens = await _usersService.Authenticate(request);
                return Ok(resultTokens);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _usersService.Create(request);
                if (!result.Succeeded)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
        }

        [HttpGet("Paging")]
        public async Task<IActionResult> GetPaging([FromQuery] GetUserPagingRequest request)
        {
            var result = await _usersService.GetUserPaging(request);
            return Ok(result);
        }
    }
}