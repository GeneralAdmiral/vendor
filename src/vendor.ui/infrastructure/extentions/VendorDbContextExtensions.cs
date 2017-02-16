using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using vendor.domain.data.concretes;
using vendor.domain.entities;

namespace vendor.ui.controllers.extentions
{
    public static class VendorDbContextExtensions
    {
        public static void EnsureSeedData(this VendorDbContext context)
        {
            if (context.IsMigrationsApplied())
            {
                if (!context.Users.Any())
                {
                    context.Users.Add(
                        new User
                        {
                            UserName = "Сервисный пользователь",
                            Email = "-",
                            LockoutEnabled = false,
                            Image = null,
                            RegisterDate = DateTime.Now,
                            Update = DateTime.Now
                        });
                    context.SaveChanges();
                }
                if (!context.Languages.Any())
                {
                    context.Languages.AddRange(
                        new Language
                        {
                            Name = "Русский",
                            Alias = "ru-RU",
                            IsDefault = true,
                            Update = DateTime.Now,
                            UserUpDateId = 1
                        },
                        new Language
                        {
                            Name = "English",
                            Alias = "en-US",
                            IsDefault = false,
                            Update = DateTime.Now,
                            UserUpDateId = 1
                        });

                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            // Name = "DetailOne",
                            // Description = "The first detail",
                            // Update = DateTime.Now,
                            UserUpdateId = 1
                        },
                        new Product
                        {
                            // Name = "DetailTwo",
                            // Description = "The second detail",
                            // Update = DateTime.Now,
                            UserUpdateId = 1
                        });

                    context.SaveChanges();
                }
            }
        }

        public static async void Setup(this VendorDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, long id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                adminRole = new Role("Admin");

                await roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "projects.view"));

                await roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "projects.create"));

                await roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "projects.update"));
            }

            if (!await userManager.IsInRoleAsync(user, adminRole.Name))
            {
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }

            var accountManagerRole = await roleManager.FindByNameAsync("Account Manager");

            if (accountManagerRole == null)
            {
                accountManagerRole = new Role("Account Manager");

                await roleManager.CreateAsync(accountManagerRole);

                await roleManager.AddClaimAsync(accountManagerRole, new Claim(ClaimTypes.Role, "account.manage"));
            }

            if (!await userManager.IsInRoleAsync(user, accountManagerRole.Name))
            {
                await userManager.AddToRoleAsync(user, accountManagerRole.Name);
            }
        }

    }
}