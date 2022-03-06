﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreAPI.Persistence;

namespace StoreAPI.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20220303003535_DateOfBirth")]
    partial class DateOfBirth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StoreAPI.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoreAPI.Domain.ProductStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductStocks");
                });

            modelBuilder.Entity("StoreAPI.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "08c22229-d5db-41ee-b1ee-fbd355ee887a",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "dd3ccd0c-a060-4ea8-8b1e-9f5715c220ff",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "29d544c6-5227-4dff-8e95-47203343b441",
                            Name = "Stock",
                            NormalizedName = "STOCK"
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "d206fff3-559d-4cd6-b0ca-1c75c953e307",
                            Name = "Seller",
                            NormalizedName = "SELLER"
                        });
                });

            modelBuilder.Entity("StoreAPI.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3f452be5-4a25-438b-8ca0-227d413acb5e",
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Istrator",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEGSz+lXxfv1bBBp3iHVnI1lAAdvwTOAsvHuQxewmOE7c91ecDrNafwMK1+PFWQG9sw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e8c74dd2-15b7-4341-81fc-10547d9be605",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c4a8e1ab-aed2-4809-abb1-c83b52b9ae7a",
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Manager",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEMlvFryFk7TcTIatsQI0BeyYl/+dZBfXE5LU6rXzjfc7Bho1PVYC+DkACte3E+ye0w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3fcf75b9-f74e-41af-aa38-a83286d77110",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "89745077-89f8-4a33-8d04-60bbae83028a",
                            DateOfBirth = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Stock",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "STOCK",
                            PasswordHash = "AQAAAAEAACcQAAAAEHjcaMKvr5Qgs/2UnO8LH5g3d50qTbG0TpoZTgFmtiZTk15lsTcvnh6a/PyLKGpaJg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0f144ae4-8466-4c05-9eae-c8241cf91c4b",
                            TwoFactorEnabled = false,
                            UserName = "stock"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e4a8cdc4-7cc6-4f0a-be9b-ad8ce8ffdf55",
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Seller",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "SELLER",
                            PasswordHash = "AQAAAAEAACcQAAAAEGNU1ihW8ikd+Sochk9nAofCmakMFuvHypzqq3JfZYjNypcCBFV+uj8JpFnaT0wHmw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e95fdd94-87c0-4263-9caf-16f5be626f6d",
                            TwoFactorEnabled = false,
                            UserName = "seller"
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0efe9cce-a591-4675-a7fc-00fec31b230a",
                            DateOfBirth = new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Public",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "PUBLIC",
                            PasswordHash = "AQAAAAEAACcQAAAAEHukzt3XBk2PGx6kIzINmvgjEl8TzcrmI6E/gYBWTCknk0L+p+ohaujv6EZ55VNGmQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "54c283d2-e7a2-4033-9e05-d57a44cb99c0",
                            TwoFactorEnabled = false,
                            UserName = "public"
                        });
                });

            modelBuilder.Entity("StoreAPI.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("StoreAPI.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("StoreAPI.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("StoreAPI.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("StoreAPI.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreAPI.Domain.ProductStock", b =>
                {
                    b.HasOne("StoreAPI.Domain.Product", "Product")
                        .WithOne("ProductStock")
                        .HasForeignKey("StoreAPI.Domain.ProductStock", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StoreAPI.Identity.UserRole", b =>
                {
                    b.HasOne("StoreAPI.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreAPI.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoreAPI.Domain.Product", b =>
                {
                    b.Navigation("ProductStock");
                });

            modelBuilder.Entity("StoreAPI.Identity.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("StoreAPI.Identity.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}