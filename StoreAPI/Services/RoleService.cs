﻿using AutoMapper;
using Microsoft.AspNetCore.Routing;
using StoreAPI.Dtos;
using StoreAPI.Exceptions;
using StoreAPI.Identity;
using StoreAPI.Infra;
using StoreAPI.Persistence.Repositories;
using StoreAPI.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly RoleValidator _validator;

        public RoleService(IRoleRepository roleRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _validator = new RoleValidator();
        }



        public async Task<IEnumerable<RoleReadDto>> GetAllDtoAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            var rolesDto = _mapper.Map<IEnumerable<RoleReadDto>>(roles);

            return rolesDto;
        }


        public async Task<Role> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                throw new IdentityNotFoundException()
                    .SetTitle("Role not found")
                    .SetDetail($"Role [Id = {id}] not found.");
            };

            return role;
        }


        public async Task<RoleReadDto> GetDtoByIdAsync(int id)
        {
            var role = await GetByIdAsync(id);
            var roleDto = _mapper.Map<RoleReadDto>(role);

            return roleDto;
        }


        public async Task<Role> GetByNameAsync(string name)
        {
            var role = await _roleRepository.GetByNameAsync(name);
            if (role == null)
            {
                throw new IdentityNotFoundException()
                    .SetTitle("Role not found.")
                    .SetDetail($"Role '{name}' not found.");
            }

            return role;
        }


        public async Task<RoleReadDto> GetDtoByNameAsync(string name)
        {
            var role = await GetByNameAsync(name);
            var roleDto = _mapper.Map<RoleReadDto>(role);

            return roleDto;
        }


        public async Task<IEnumerable<RoleReadDto>> SearchByNameAsync(string name)
        {
            var roles = await _roleRepository.SearchByNameAsync(name);
            var rolesDto = _mapper.Map<IEnumerable<RoleReadDto>>(roles);

            return rolesDto;
        }


        public async Task<RoleReadDto> CreateAsync(RoleWriteDto roleWriteDto)
        {
            var validationResult = _validator.Validate(roleWriteDto);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult)
                    .SetTitle("Validation error")
                    .SetDetail($"Invalid role data. See '{ExceptionWithProblemDetails.ErrorKey}' for more details");
            }

            var role = _mapper.Map<Role>(roleWriteDto);
            var result = await _roleRepository.CreateAsync(role);
            if (!result.Succeeded)
            {
                throw new IdentityException(result)
                    .SetTitle("Error creating role")
                    .SetDetail($"Role not created. See '{ExceptionWithProblemDetails.ErrorKey}' property for more details");
            }

            var appRole = await _roleRepository.GetByNameAsync(roleWriteDto.Name);
            var roleReturn = _mapper.Map<RoleReadDto>(appRole);

            return roleReturn;
        }


        public async Task DeleteAsync(int id)
        {
            var role = await GetByIdAsync(id);
            if (role.Name == AppConstants.Roles.Admin.Name ||
                role.Name == AppConstants.Roles.Manager.Name ||
                role.Name == AppConstants.Roles.Stock.Name ||
                role.Name == AppConstants.Roles.Seller.Name) 
            {
                throw new AppException()
                    .SetTitle("Error deleting role")
                    .SetDetail($"Role '{role.Name}' cannot be deleted.")
                    .SetInstance(RoleInstance(id));
            }

            var result = await _roleRepository.DeleteAsync(role);
            if (!result.Succeeded)
            {
                throw new IdentityException(result)
                    .SetTitle("Error deleting role")
                    .SetDetail($"Role not deleted. See '{ExceptionWithProblemDetails.ErrorKey}' property for more details");
            }
        }


        public async Task<IEnumerable<UserReadDto>> GetAllUsersOnRole(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            var usersViewModel = _mapper.Map<IEnumerable<UserReadDto>>(role.Users);

            return usersViewModel;
        }


        private string RoleInstance(object id)
        {
            return _linkGenerator.GetPathByName(nameof(Controllers.RoleController.GetRoleById), new { id });
        }
    }
}