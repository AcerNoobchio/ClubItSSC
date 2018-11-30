using ClubItWebApp.Data;
using ClubItWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Services
{
    public class Initializer
    {
        //all the roles
        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public Initializer(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();
            if(!_context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
            }
            if (!_context.Roles.Any(r => r.Name == "ClubAdmin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "ClubAdmin" });
            }
            if (!_context.Roles.Any(r => r.Name == "StudentUser"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "StudentUser" });
            }

            if (!_context.Users.Any(u => u.UserName == "SuperAdmin@user.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "SuperAdmin@user.com",
                    UserName = "SuperAdmin@user.com"
                };
                await _userManager.CreateAsync(user, "Superadmin1!");
                await _userManager.AddToRoleAsync(user, "SuperAdmin");
            }

            if (!_context.Users.Any(u => u.UserName == "ClubAdmin@user.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "ClubAdmin@user.com",
                    UserName = "ClubAdmin@user.com"
                };
                await _userManager.CreateAsync(user, "Clubadmin1!");
                await _userManager.AddToRoleAsync(user, "ClubAdmin");
            }
        }
    }
}
