﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() {
            Active = true;
        }

        [Display(Name = "För- och efternamn")]
        public string FullName { get; set; }
                
        [Display(Name= "Aktiv/Inskriven")]
        public bool Active { get; set; }

        [Display(Name = "E-postadress")]
        public override string Email { get; set; }

        [Display(Name = "Telefonnr")]
        public override string PhoneNumber { get; set; }

        [Display(Name="Grupp")]
        public int? GroupId { get; set; }

        [Display(Name = "Användarnamn")]
        public override string UserName { get; set; }

        [Display(Name = "Antal fel login")]
        public override int AccessFailedCount { get; set; }

        [Display(Name = "Roll")]
        public string Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Course> Courses { get; set; }

        public System.Data.Entity.DbSet<LexiconLMS.Models.Document> Documents { get; set; }

        //public System.Data.Entity.DbSet<LexiconLMS.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}