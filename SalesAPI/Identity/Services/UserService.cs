﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Dtos;
using SalesAPI.Exceptions.Domain;
using SalesAPI.Extensions;
using SalesAPI.Persistence;
using SalesAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SalesAPI.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IRoleService _roleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRoleService roleService, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper)
        {
            _roleService = roleService;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<UserViewModel>> GetAllDtoAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var usersModel = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return usersModel;
        }


        public async Task<User> GetByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
            {
                throw new IdentityNotFoundException($"User ['{userName}'] not found.");
            }

            return user;
        }


        public async Task<UserViewModel> GetDtoByUserNameAsync(string userName)
        {
            var user = await GetByUserNameAsync(userName);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }

        public async Task<IEnumerable<UserViewModel>> SearchAsync(string search)
        {
            var result = await _userRepository.SearchAsync(search);

            var usersDto = _mapper.Map<IEnumerable<UserViewModel>>(result);

            return usersDto;
        }


        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new IdentityNotFoundException($"User [Id = {id}] not found.");
            }

            return user;
        }


        public async Task<UserViewModel> GetDtoByIdAsync(int id)
        {
            var user = await GetByIdAsync(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }


        public async Task<IList<string>> GetRolesNamesAsync(string userName)
        {
            var user = await GetByUserNameAsync(userName);
            var roles = await _userRepository.GetRolesNamesAsync(user);

            return roles;
        }


        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            var result = await _userRepository.CreateAsync(user, password);

            return result;
        }


        public async Task<UserViewModel> AddToRoleAsync(int id, int roleId)
        {
            var adminRoleId = AppConstants.Roles.Admin.Id;
            var adminUserId = AppConstants.Users.Admin.Id;
            var adminRoleName = AppConstants.Roles.Admin.Name;
            var role = await _roleService.GetByIdAsync(roleId);
            
            if (roleId == adminRoleId) 
            {
                var currentUser = await GetCurrentUserAsync();
                if (currentUser.Id != adminUserId)
                {
                    throw new IdentityException($"Only root {adminRoleName} [Id = {adminUserId}] can assign {adminRoleName} role");
                }
            }

            var user = await GetByIdAsync(id);
            var hasRole = user.Roles.Contains(role);

            if (hasRole)
            {
                throw new IdentityException($"User already assigned to role ['{role.Name}'].");
            }

            var result = await _userRepository.AddToRoleAsync(user, role.Name);
            if (!result.Succeeded)
            {
                throw new IdentityException($"Error adding user ['{user.UserName}'] to role ['{role.Name}'] .", result.Errors);
            }

            var userModel = _mapper.Map<UserViewModel>(user);
            return userModel;
        }


        public async Task<UserViewModel> RemoveFromRoleAsync(int id, int roleId)
        {
            var adminUserId = AppConstants.Users.Admin.Id;
            var adminRoleName = AppConstants.Roles.Admin.Name;
            var adminRoleId = AppConstants.Roles.Admin.Id;
            var currentUser = await GetCurrentUserAsync();

            if (id == adminUserId && roleId == adminRoleId) 
            {
                throw new IdentityException($"Cannot remove ['{adminRoleName}'] role from root admin.");
            }

            if (roleId == adminRoleId && currentUser.Id != adminUserId)
            {
                throw new IdentityException($"Only root {adminRoleName} [Id = {adminUserId}] can assign {adminRoleName} role");
            }

            var roleToRemove = await _roleService.GetByIdAsync(roleId);
            var userToRemoveRole = await GetByIdAsync(id);
            var hasRole = userToRemoveRole.Roles.Contains(roleToRemove);

            if (!hasRole)
            {
                throw new IdentityException($"User not assigned to role ['{roleToRemove.Name}'].");
            }

            var result = await _userRepository.RemoveFromRoleAsync(userToRemoveRole, roleToRemove.Name);
            if (!result.Succeeded)
            {
                throw new IdentityException($"Error removing user ['{userToRemoveRole.UserName}'] to role ['{roleToRemove.Name}'] .", result.Errors);
            }

            var userToReturn = await GetByIdAsync(id);
            var userModel = _mapper.Map<UserViewModel>(userToReturn);

            return userModel;
        }


        public async Task<UserViewModel> GetDtoCurrentUserAsync()
        {
            var user = await GetCurrentUserAsync();
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }


        public async Task<User> GetCurrentUserAsync()
        {
            var isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                throw new IdentityException("User not logged in");
            }

            var user = await _userRepository.GetCurrentUserAsync();

            return user;
        }


        public async Task<UserViewModel> UpdateUserAsync(string userName, UserUpdateDto userUpdateDto)
        {
            var user = await GetByUserNameAsync(userName);
            _mapper.Map<UserUpdateDto, User>(userUpdateDto, user);

            var result = await _userRepository.UpdateUserAsync(user);
            if (!result.Succeeded)
            {
                throw new IdentityException("Error while updating user.", result.Errors);
            }

            var updatedUser = await GetByUserNameAsync(userName);
            var userToResult = _mapper.Map<UserViewModel>(updatedUser);


            return userToResult;
        }


        public async Task ChangePasswordAsync(int id, string currentPassword, string newPassword)
        {
            var user = await GetByIdAsync(id);

            var result = await _userRepository.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new IdentityException("Error changing password.", result.Errors);
            }
        }


        public async Task ChangeCurrentUserPasswordAsync(string currentPassword, string newPassword)
        {
            var currentUser = await GetCurrentUserAsync();
            var result = await _userRepository.ChangePasswordAsync(currentUser, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new IdentityException("Error changing password.", result.Errors);
            }
        }


        public async Task ResetPasswordAsync(int id, string newPassword)
        {
            var user = await GetByIdAsync(id);
            if (newPassword == "")
            {
                newPassword = user.UserName; // pra ficar mais facil, poderia ser outro método
            }

            var result = await _userRepository.ResetPasswordAsync(user, newPassword);
            if (!result.Succeeded)
            {
                throw new IdentityException("Error reseting password.", result.Errors);
            }
        }
    }
}