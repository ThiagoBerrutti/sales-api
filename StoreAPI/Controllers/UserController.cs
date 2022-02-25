﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Dtos;
using StoreAPI.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllDtoAsync();

            return Ok(result);
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpGet("{id}", Name = nameof(GetUserById))]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetDtoByIdAsync(id);

            return Ok(result);
        }


        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _userService.GetDtoCurrentUserAsync();

            return Ok(result);
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpGet("userName/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var result = await _userService.GetDtoByUserNameAsync(userName);

            return Ok(result);
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpGet("search/{search}")]
        public async Task<IActionResult> SearchUser(string search)
        {
            var result = await _userService.SearchAsync(search);

            return Ok(result);
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(string userName, UserUpdateDto userUpdate)
        {
            var currentUserClaims = HttpContext.User;
            var currentUserName = currentUserClaims.FindFirst(ClaimTypes.Name).Value;
            var isCurrentUser = currentUserName.ToUpper() == userName.ToUpper();

            if (!(currentUserClaims.IsInRole("Administrator") || currentUserClaims.IsInRole("Manager") || isCurrentUser))
            {
                return new UnauthorizedResult();
            }

            var result = await _userService.UpdateUserAsync(userName, userUpdate);

            return Ok(result);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}/password")]
        public async Task<IActionResult> ChangePassword(int id, ChangePasswordDto passwords)
        {
            await _userService.ChangePasswordAsync(id, passwords);

            return Ok();
        }


        [HttpPut("current/password")]
        public async Task<IActionResult> ChangeCurrentUserPassword(ChangePasswordDto passwords)
        {
            await _userService.ChangeCurrentUserPasswordAsync(passwords);

            return Ok();
        }


        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}/password")]
        public async Task<IActionResult> ResetPassword(int id, string newPassword = "")
        {
            await _userService.ResetPasswordAsync(id, newPassword);

            return Ok();
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpPut("{id}/roles/add/{roleId}")]
        public async Task<IActionResult> AddUserToRole(int id, int roleId)
        {
            var user = await _userService.AddToRoleAsync(id, roleId);

            return Ok(user);
        }


        [Authorize(Roles = "Administrator,Manager")]
        [HttpPut("{id}/roles/remove/{roleId}")]
        public async Task<IActionResult> RemoveFromRole(int id, int roleId)
        {
            var user = await _userService.RemoveFromRoleAsync(id, roleId);

            return Ok(user);
        }
    }
}