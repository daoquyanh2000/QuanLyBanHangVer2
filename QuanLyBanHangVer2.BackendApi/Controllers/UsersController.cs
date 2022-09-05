using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _usersService.Authenticate(request);
                if (string.IsNullOrEmpty(result.Items))
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _usersService.Create(request);
                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _usersService.Update(id, request);
                if (!result.IsSuccessed)
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