using ClubItWebApp.Data;
using ClubItWebApp.Models;
using ClubItWebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ClubItWebApp
{
    public class DbClubItRepository : IClubItRepository
    {
        private ApplicationDbContext _db;
        private UserManager<IdentityUser> _userManager;

        public DbClubItRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // Authentication
        public ApplicationUser ReadApplicationUser(string email)
        {
            ApplicationUser appUser = null;
            // Using eager loading, a user is read by their email from the database.
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            // If the user is there...
            if (user != null)
            {
                // A user is created
                appUser = new ApplicationUser
                {
                    User = user
                };
                // A role is added to the user.
                AddRoles(appUser);
            }
            // The user is returned
            return appUser;
        }
        public bool AssignRole(string email, string roleName)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                // if the user's rolename is set...
                if (user.UserName != roleName)
                {
                    // the role is added to a user , using the user manager
                    _userManager.AddToRoleAsync(user, roleName).Wait();
                    // return true
                    return true;
                }
            }
            return false;
        }
        public IQueryable<ApplicationUser> ReadAllUsers()
        {
            ICollection<ApplicationUser> appUsers = new List<ApplicationUser>();
            foreach (var user in _db.Users)
            {
                ApplicationUser usr = new ApplicationUser
                {
                    User = user
                };
                AddRoles(usr);
                appUsers.Add(usr);
            }
            return appUsers.AsQueryable();
        }
        private void AddRoles(ApplicationUser user)
        {
            var roleIds = _db.UserRoles.Where(ur => ur.UserId == user.User.Id).Select(ur => ur.RoleId);
            foreach (var roleId in roleIds)
            {
                user.Roles.Add(_db.Roles.Find(roleId));
            }
        }




        // Profile
        public Profile CreateProfile(Profile profile)
        {
            throw new System.NotImplementedException();
        }

        public Profile ReadProfile(string profileId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProfile(Profile profile)
        {
            throw new System.NotImplementedException();
        }
    }
}