using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClubItWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       // public virtual DbSet<Club> Club { get; set; }
       // public virtual DbSet<Event> Event { get; set; }
       // public virtual DbSet<Club_Member> Club_Members { get; set; }



    }
}
