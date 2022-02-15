﻿using SalesAPI.Dtos;
using SalesAPI.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.Services
{
    public interface IRoleService
    {
        public Task<IEnumerable<RoleReadDto>> GetAllDtoAsync();

        public Task<Role> GetByIdAsync(int id);

        public Task<RoleReadDto> GetDtoByIdAsync(int id);

        public Task<Role> GetByNameAsync(string name);

        public Task<RoleReadDto> GetDtoByNameAsync(string name);

        public Task<IEnumerable<UserViewModel>> GetAllUsersOnRole(int id);

        public Task<IEnumerable<RoleReadDto>> SearchByNameAsync(string name);

        public Task<RoleReadDto> CreateAsync(RoleWriteDto role);

        public Task DeleteAsync(int id);
    }
}