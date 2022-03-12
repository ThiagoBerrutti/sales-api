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
    [Migration("20220311202437_DbMigration")]
    partial class DbMigration
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Abacate 1kg",
                            Name = "Abacate",
                            Price = 9.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Description = "Berinjela preta 1kg",
                            Name = "Berinjela",
                            Price = 3.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Coco seco un",
                            Name = "Coco",
                            Price = 7.5
                        },
                        new
                        {
                            Id = 4,
                            Description = "Danoninho Ice 70g",
                            Name = "Danoninho",
                            Price = 6.0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Espaguete Isabela 500g",
                            Name = "Espaguete",
                            Price = 4.0
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Quantity = 150
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Quantity = 200
                        });
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
                            ConcurrencyStamp = "38e12d0f-227d-47c6-8ce6-e25354920f5d",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "e7fa4211-fb54-4256-a137-82daf1f53169",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "dd3cf533-e9c1-4a9e-97c8-584a87b305a3",
                            Name = "Stock",
                            NormalizedName = "STOCK"
                        },
                        new
                        {
                            Id = 4,
                            ConcurrencyStamp = "1e932ed6-6921-4ee1-857e-cf793e269dce",
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
                            ConcurrencyStamp = "c3f0ef67-721d-412f-abd0-c4ed2bbb65b2",
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Istrator",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEBT4fdxp5/xfJ4X4raZqaTFphx5LtezaWuc25coE6yeuDyd9OgrHZFYko+hvuY+Bag==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2319e2d8-8c37-4157-91b2-d53f598dfb91",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "82a6a5c4-795a-4025-8832-8c36665e54bd",
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Manager",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEDHDLTP1M7BHpThSQYCelR3KxmPK+qDuQoSIqV4rj2YVs42VpfFEPUb+N/dWci/oMA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9299021c-d3f3-4189-bd68-8268df4dc0cf",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bac48320-5bb6-4b9e-8d0b-5b133ca6ada8",
                            DateOfBirth = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Stock",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "STOCK",
                            PasswordHash = "AQAAAAEAACcQAAAAEFmy698chQ2E4E7dIygdZ5mz+xkHIk0GQcBnSP25gjgyoG2hn0InaDV+hWIAWzS9MA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ee61aa36-8f02-4395-9a60-d6b01f58fb36",
                            TwoFactorEnabled = false,
                            UserName = "stock"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "40836bd8-ad96-4f5b-8362-6fb59297de37",
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Seller",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "SELLER",
                            PasswordHash = "AQAAAAEAACcQAAAAEKTGncEPc28K/F20NIZvHo9gdp5CpV52OB4xBaUt0lv0d/+NcXY3zaFa2ybAmrMbmQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1cc2ce74-88fe-49ba-8d69-81fb168250be",
                            TwoFactorEnabled = false,
                            UserName = "seller"
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "77436546-a249-40fc-8ba8-ba79f14d3386",
                            DateOfBirth = new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Public",
                            LastName = "Test Acc",
                            LockoutEnabled = false,
                            NormalizedUserName = "PUBLIC",
                            PasswordHash = "AQAAAAEAACcQAAAAEKh0lrjZ5apxtkiDrKVWb2kS0VhoW4++id79cQPaSgtq+eg8NY+VzXeh+K3Gd4S6hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0a9aa26f-cf35-4d3f-a942-8e7f6865e56b",
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