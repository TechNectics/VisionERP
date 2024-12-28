using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataNexus.Auth;
using Microsoft.AspNetCore.Identity;

namespace DataNexus
{
    public class ApplicationDbContext : IdentityDbContext<UserIdentity>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //  this.seedingRoles(builder);

        }

        #region
        //private void seedingRoles(ModelBuilder builder)
        //{
        //    //builder.Entity<IdentityRole>().HasData(
        //    //    new IdentityRole() { ConcurrencyStamp = "1", Name = "Admin", NormalizedName = "Admin" },
        //    //    new IdentityRole() { ConcurrencyStamp = "2", Name = "SAdmin", NormalizedName = "SAdmin" },
        //    //    new IdentityRole() { ConcurrencyStamp = "3", Name = "Accountant", NormalizedName = "Accountant" }
        //    //    );

        //}
        #endregion

       
    }
}
