using ClubItWebApp.Models;
using ClubItWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Data
{
    public interface IClubItRepository
    {
        //have any method 
        //have role stuff
        ApplicationUser ReadApplicationUser(string email);
        bool AssignRole(string email, string roleName);


        //Profile stuff
        Profile CreateProfile(Profile profile);
        Profile ReadProfile(string profileId);
        void UpdateProfile(Profile profile);
    }
}
