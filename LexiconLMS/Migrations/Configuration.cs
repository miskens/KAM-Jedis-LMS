using System.Data.Entity.Migrations.Model;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace LexiconLMS.Migrations {
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconLMS.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LexiconLMS.Models.ApplicationDbContext context) {

            context.Groups.AddOrUpdate(g => g.Name,
                new Group
            { Name = "Java", Description = "Händiga typer det där", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(60) },
                            new Group
            { Name = "C#", Description = "Ny description", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(60) }
            );
            context.SaveChanges();

            context.Users.AddOrUpdate(u => u.FullName,
    new ApplicationUser { FullName = "Oscar Jakobsson", Email = "oscar@dsfdsfad", UserName = "oscar@dsfdsfad", Active = true, GroupId = 1 },
    new ApplicationUser { FullName = "Adrian Locano", UserName = "adrian@xenotype.com", Email = "adrian@xenotype.com", Active = true, GroupId = 2 },
    new ApplicationUser { FullName = "Kenneth Forsström", UserName = "kenneth.forsstrom@hotmail.com", Email = "kenneth.forsstrom@hotmail.com", Active = true, GroupId = 1 },
    new ApplicationUser { FullName = "Anna Eklund", UserName = "vitastjern@gmail.com", Email = "vitastjern@gmail.com", Active = true, GroupId = 2 },
    new ApplicationUser { FullName = "Michael Puusaari", UserName = "miskens@hotmail.com", Email = "miskens@hotmail.com", Active = true, GroupId = 1 },
    new ApplicationUser { FullName = "Matti Boustedt", UserName = "matti.boustedt@gmail.com", Email = "matti.boustedt@gmail.com", Active = true },
    new ApplicationUser { FullName = "Anna-Karin Rönnegård", UserName = "a.ronnegard@gmail.com", Email = "a.ronnegard@gmail.com", Active = true },
    new ApplicationUser { FullName = "Jonas Jakobsson", UserName = "jonasjakobsson.sundbyberg@gmail.com", Email = "jonasjakobsson.sundbyberg@gmail.com", Active = true },
    new ApplicationUser { FullName = "Staffan Ericsson", UserName = "staffan.ericsson2@gmail.com", Email = "staffan.ericsson2@gmail.com", Active = true },
    new ApplicationUser { FullName = "Christina Kronblad", UserName = "christinamkronblad@yahoo.se", Email = "christinamkronblad@yahoo.se", Active = true },
    new ApplicationUser { FullName = "Olga Kagyrina", UserName = "olga.kagyrina@gmail.com", Email = "olga.kagyrina@gmail.com", Active = false },
    new ApplicationUser { FullName = "Nina Oksa", UserName = "nina@gmail.se", Email = "nina@gmail.se", Active = false },
    new ApplicationUser { FullName = "Fredrik Hedlund", UserName = "adnansweden14@gmail.com", Email = "adnansweden14@gmail.com", Active = false },
    new ApplicationUser { FullName = "Niklas Säwensten", UserName = "nisaw99@hotmail.com", Email = "nisaw99@hotmail.com", Active = true }
);
        }
    }
}
