﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesAPI.Identity;
using System;
using System.Collections.Generic;

namespace SalesAPI.Persistence.EntityConfigurations
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRole>(

                    builder => builder
                        .HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired(),


                    builder => builder
                        .HasOne(ur => ur.User)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired(),

                    builder => builder.HasKey(ur => new { ur.UserId, ur.RoleId })
                );


            var hasher = new PasswordHasher<User>();
            builder.HasData(new List<User>
            {
                //Admin
                new User
                {
                    Id = AppConstants.Users.Admin.Id,
                    UserName = AppConstants.Users.Admin.UserName,
                    NormalizedUserName = AppConstants.Users.Admin.NormalizedUserName,
                    FirstName = AppConstants.Users.Admin.FirstName,
                    LastName = AppConstants.Users.Admin.LastName,
                    PasswordHash = hasher.HashPassword(null,"string"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DateOfbirth = new DateTime(1980,1,1)
                },

                //Manager
                new User
                {
                    Id = AppConstants.Users.Manager.Id,
                    UserName = AppConstants.Users.Manager.UserName,
                    NormalizedUserName = AppConstants.Users.Manager.NormalizedUserName,
                    FirstName = AppConstants.Users.Manager.FirstName,
                    LastName = AppConstants.Users.Manager.LastName,
                    PasswordHash = hasher.HashPassword(null,"string"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DateOfbirth = new DateTime(1990,1,1)
                },

                //Stock
                new User
                {
                    Id = AppConstants.Users.Stock.Id,
                    UserName = AppConstants.Users.Stock.UserName,
                    NormalizedUserName = AppConstants.Users.Stock.NormalizedUserName,
                    FirstName = AppConstants.Users.Stock.FirstName,
                    LastName = AppConstants.Users.Stock.LastName,
                    PasswordHash = hasher.HashPassword(null,"string"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DateOfbirth = new DateTime(1995,1,1)
                },

                //Seller
                new User
                {
                    Id = AppConstants.Users.Seller.Id,
                    UserName = AppConstants.Users.Seller.UserName,
                    NormalizedUserName = AppConstants.Users.Seller.NormalizedUserName,
                    FirstName = AppConstants.Users.Seller.FirstName,
                    LastName = AppConstants.Users.Seller.LastName,
                    PasswordHash = hasher.HashPassword(null,"string"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DateOfbirth = new DateTime(2000,1,1)
                }
            });
        }
    }
}