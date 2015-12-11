using System.Data.Entity.Migrations.Model;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace LexiconLMS.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconLMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LexiconLMS.Models.ApplicationDbContext context)
        {

            string systemutvecklareDotNet = "Systemutvecklare.NET = C#, .Net, Applikationsutveckling, SQL, Test & testledning.  Syftet med utbildningen är att i första hand erbjuda påbyggnad- och vidareutbildning för personer med befintliga kunskaper inom Systemutveckling.";
            string shortLorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string longLorem = shortLorem + " " + shortLorem + " " + shortLorem + " " + shortLorem;

            context.Groups.AddOrUpdate(g => g.Name,
            new Group { Name = "nd15", Description = systemutvecklareDotNet, StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2016, 02, 28) },
            new Group { Name = "nf15", Description = "", StartDate = new DateTime(2015, 11, 23), EndDate = new DateTime(2016, 03, 12) },
            new Group { Name = ".Net3", Description = shortLorem, StartDate = new DateTime(2015, 03, 01), EndDate = new DateTime(2015, 06, 28) },
            new Group { Name = "Java", Description = shortLorem, StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2016, 02, 28) },
            new Group { Name = "C#", Description = longLorem, StartDate = new DateTime(2015, 08, 31), EndDate = new DateTime(2015, 12, 18) },
                new Group { Name = "Sharepoint", Description = "Sharepoint förr och nu. Den här klassen kommer att handla om att sitta och nöta arslet och klicka på framåt- och bakåtknapparna i browsern, samt att klicka i textrutor och ange siffror mellan 1-10. Det kan även hända att man får klicka på en färg för att sätta bakgrundsfärgen på en sida.", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 04, 30) },
                new Group { Name = "Dynamics", Description = "Bli mer dynamisk med Dynamics.", StartDate = new DateTime(2015, 10, 22), EndDate = new DateTime(2016, 01, 20) },
                new Group { Name = "Pascal", Description = "Finns det nån som ännu använder Pascal?", StartDate = new DateTime(2014, 01, 10), EndDate = new DateTime(2014, 06, 18) },
                new Group { Name = "Python", Description = "En typ av orm, eller ett programmeringsspråk?", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 04, 30) },
                new Group { Name = "EMACS", Description = "En editor och ett fönstersystem och ett enprocessoperativsystem, allt i ett!", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 04, 30) },
                new Group { Name = "Världsherravälde", Description = "Från hantlangare till evil overlord på 100 dagar.", StartDate = new DateTime(2015, 08, 03), EndDate = new DateTime(2015, 11, 11) }
            );
            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.Name,
                new Course { Name = "Java 101", Description = "En introduktion till Java", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2015, 10, 24), GroupId = 4 },
                new Course { Name = "Java 102", Description = shortLorem, StartDate = new DateTime(2015, 10, 25), EndDate = new DateTime(2015, 11, 10), GroupId = 4 },
                new Course { Name = "Java 103", Description = longLorem, StartDate = new DateTime(2015, 11, 11), EndDate = new DateTime(2015, 12, 20), GroupId = 4 },
                new Course { Name = "Java 101-3", Description = shortLorem, StartDate = new DateTime(2015, 12, 21), EndDate = new DateTime(2016, 02, 28), GroupId = 4 },
                new Course { Name = "Java included", Description = shortLorem, StartDate = new DateTime(2015, 10, 16), EndDate = new DateTime(2015, 10, 30), GroupId = 1 },
                new Course { Name = "C# 100", Description = "C# introduktion", StartDate = new DateTime(2015, 08, 31), EndDate = new DateTime(2015, 09, 10), GroupId = 5 },
                new Course { Name = "C# 101", Description = shortLorem, StartDate = new DateTime(2015, 09, 12), EndDate = new DateTime(2015, 09, 30), GroupId = 5 },
                new Course { Name = "C# 102", Description = shortLorem, StartDate = new DateTime(2015, 10, 01), EndDate = new DateTime(2015, 10, 22), GroupId = 5 },
                new Course { Name = "C# 103", Description = shortLorem, StartDate = new DateTime(2015, 10, 23), EndDate = new DateTime(2015, 10, 29), GroupId = 5 },
                new Course { Name = "C# 104", Description = shortLorem, StartDate = new DateTime(2015, 10, 30), EndDate = new DateTime(2015, 11, 15), GroupId = 5 },
                new Course { Name = "C# 105", Description = shortLorem, StartDate = new DateTime(2015, 11, 16), EndDate = new DateTime(2015, 11, 28), GroupId = 5 },
                new Course { Name = "C# 106", Description = shortLorem, StartDate = new DateTime(2015, 11, 29), EndDate = new DateTime(2015, 12, 18), GroupId = 5 },
                new Course { Name = "C# frameworks", Description = shortLorem, StartDate = new DateTime(2015, 10, 31), EndDate = new DateTime(2015, 11, 20), GroupId = 1 },
                new Course { Name = "Sharepoint expert", Description = "Sharepoint för experter, övriga göre sig ej besvär!", StartDate = new DateTime(2016, 03, 13), EndDate = new DateTime(2016, 04, 01), GroupId = 6 },
                new Course { Name = "Sharepoint mellannivå", Description = "Inte nybörjare, inte expert?", StartDate = new DateTime(2016, 02, 07), EndDate = new DateTime(2016, 03, 12), GroupId = 6 },
                new Course { Name = "Sharepoint newbie", Description = "Färskingar!", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 02, 06), GroupId = 6 },
                new Course { Name = "Sharepoint a-z", Description = "Sharepoint för experter, övriga göre sig ej besvär!", StartDate = new DateTime(2016, 04, 02), EndDate = new DateTime(2016, 04, 30), GroupId = 6 },
                new Course { Name = "Pythonormars skötsel", Description = "Ormskräcken börjar här!", StartDate = new DateTime(2016, 01, 05), EndDate = new DateTime(2016, 04, 28), GroupId = 9 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2015, 10, 15), GroupId = 1 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 11, 30), EndDate = new DateTime(2016, 12, 10), GroupId = 2 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 04, 01), EndDate = new DateTime(2016, 04, 30), GroupId = 3 },
                new Course { Name = "Scrum", Description = "Utveckling av Lexicon LMS i tre parallella Scrumprojekt", StartDate = new DateTime(2015, 11, 27), EndDate = new DateTime(2015, 12, 18), GroupId = 1 },
                new Course { Name = "Hantlangarskötsel", Description = "Dina minioner välbefinnande är nödvändig för att framgångsrikt ta över världen.", StartDate = new DateTime(2015, 08, 03), EndDate = new DateTime(2015, 08, 30), GroupId = 11 },
                new Course { Name = "Ondskefulla skratt a-z", Description = "Skrattar först som skrattar bäst som skattar mest.", StartDate = new DateTime(2015, 09, 01), EndDate = new DateTime(2015, 09, 15), GroupId = 11 },
                new Course { Name = "Ondskefulla skratt 101", Description = "Skrattar sist som skrattar bäst.", StartDate = new DateTime(2015, 09, 16), EndDate = new DateTime(2015, 09, 30), GroupId = 11 },
                new Course { Name = "Ondskefulla skratt 102", Description = "Fortsättningskurs i elaka och ondskefulla skratt. Nu med fokus på andningen.", StartDate = new DateTime(2015, 10, 01), EndDate = new DateTime(2015, 11, 11), GroupId = 11 }
                );
            context.SaveChanges();

            context.Activities.AddOrUpdate(a => a.Name,
                new Activity { Name = "Laboration i Java 101", Description = "Första labben i Java", Type = "laboration", StartDate = new DateTime(2015, 10, 04), EndDate = new DateTime(2015, 10, 06), CourseId = 1 },
                new Activity { Name = "Laboration 2 i Java 101", Description = "Andra labben i Java", Type = "laboration", StartDate = new DateTime(2015, 10, 14), EndDate = new DateTime(2015, 10, 18), CourseId = 1 },
                new Activity { Name = "Sharepoint från början", Description = "Börja från början", Type = "övning", StartDate = new DateTime(2016, 01, 20), EndDate = new DateTime(2016, 02, 06), CourseId = 14 },
                new Activity { Name = "C# för den allvetande", Description = "Det allvetande programmet regerar", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 11, 01), EndDate = new DateTime(2015, 11, 09), CourseId = 9 },
                new Activity { Name = "Skrattlabb", Description = "Användning av diafragman vid elakt skratt.", Type = "laboration", StartDate = new DateTime(2015, 11, 02), EndDate = new DateTime(2015, 11, 08), CourseId = 21 },
                new Activity { Name = "Historiskt skrattande", Description = "Lär dig skratta som historiska ondskefulla typer", Type = "laboration", StartDate = new DateTime(2015, 09, 10), EndDate = new DateTime(2015, 09, 15), CourseId = 19 },
                new Activity { Name = "Inlämningsuppgift i skratt", Description = "Spela in dig själv medan du flabbar som en galen typ som just tagit över världsherraväldet!", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 10, 04), EndDate = new DateTime(2015, 10, 09), CourseId = 21 },
                new Activity { Name = "Inlämningsuppgift C#", Description = "Gör ett lyxigt garage!", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 11, 29), EndDate = new DateTime(2015, 12, 05), CourseId = 11 },
                new Activity { Name = "Laboration i Java included", Description = shortLorem, Type = "laboration", StartDate = new DateTime(2015, 10, 14), EndDate = new DateTime(2015, 10, 18), CourseId = 5 },
                new Activity { Name = "Laboration 2 i Java included", Description = shortLorem, Type = "laboration", StartDate = new DateTime(2015, 10, 24), EndDate = new DateTime(2015, 10, 30), CourseId = 5 },
                new Activity { Name = "C# för den allvetande", Description = shortLorem, Type = "inlämningsuppgift", StartDate = new DateTime(2015, 11, 11), EndDate = new DateTime(2015, 11, 19), CourseId = 13 }
                );
            context.SaveChanges();

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (string role in new[] { "elev", "lärare" })      // seed roles to 
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole { Name = role });
                }
            }
            context.SaveChanges();

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var email = "oscar.jakobsson@lexicon.se";
            var roles = new[] { "lärare" };
            var user = new ApplicationUser { FullName = "Oscar Jakobsson", Email = email, UserName = email, Active = true };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "adrian@xenotype.com";
            // same roles as previous
            user = new ApplicationUser { FullName = "Adrian Lozano", UserName = email, Email = email, Active = true };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "kenneth.forsstrom@hotmail.com";
            roles = new[] { "elev" };
            user = new ApplicationUser { FullName = "Kenneth Forsström", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "vitastjern@gmail.com";
            // same as student above
            user = new ApplicationUser { FullName = "Anna Eklund", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "miskens@hotmail.com";
            user = new ApplicationUser { FullName = "Michael Puusaari", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "matti.boustedt@gmail.com";
            user = new ApplicationUser { FullName = "Matti Boustedt", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "a.ronnegard@gmail.com";
            user = new ApplicationUser { FullName = "Anna-Karin Rönnegård", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "jonasjakobsson.sundbyberg@gmail.com";
            user = new ApplicationUser { FullName = "Jonas Jakobsson", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "staffan.ericsson2@gmail.com";
            user = new ApplicationUser { FullName = "Staffan Ericsson", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "christinamkronblad@yahoo.se";
            user = new ApplicationUser { FullName = "Christina Kronblad", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "olga.kagyrina@gmail.com";
            user = new ApplicationUser { FullName = "Olga Kagyrina", UserName = email, Email = email, Active = false, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nina@gmail.se";
            user = new ApplicationUser { FullName = "Nina Oksa", UserName = email, Email = email, Active = false, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "adnansweden14@gmail.com";
            user = new ApplicationUser { FullName = "Fredrik Hedlund", UserName = email, Email = email, Active = false, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nisaw99@hotmail.com";
            user = new ApplicationUser { FullName = "Niklas Säwensten", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "kalle@nomail.com";
            user = new ApplicationUser { FullName = "Kalle Öberg", UserName = email, Email = email, Active = true, GroupId = 6 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "kjelle@nomail.com";
            user = new ApplicationUser { FullName = "Kjell Ek", UserName = email, Email = email, Active = true, GroupId = 5 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "peter@nomail.com";
            user = new ApplicationUser { FullName = "Peter Petersson", UserName = email, Email = email, Active = true, GroupId = 3 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "lena@nomail.com";
            user = new ApplicationUser { FullName = "Lena EK", UserName = email, Email = email, Active = true, GroupId = 4 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "alena@nomail.com";
            user = new ApplicationUser { FullName = "Alien Night", UserName = email, Email = email, Active = true, GroupId = 5 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "stina@nomail.com";
            user = new ApplicationUser { FullName = "Stina Sten", UserName = email, Email = email, Active = true, GroupId = 6 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "anna@nomail.com";
            user = new ApplicationUser { FullName = "Anna Berg", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "sten@nomail.com";
            user = new ApplicationUser { FullName = "Sten Stinasson", UserName = email, Email = email, Active = true, GroupId = 7 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nina@nomail.com";
            user = new ApplicationUser { FullName = "Nina Öberg", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "greta@nomail.com";
            user = new ApplicationUser { FullName = "Greta Grus", UserName = email, Email = email, Active = true, GroupId = 5 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "elina@nomail.com";
            user = new ApplicationUser { FullName = "Elina Arnesson", UserName = email, Email = email, Active = true, GroupId = 8 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "despicableme@eviloverlords.com";
            user = new ApplicationUser { FullName = "Emperor Palpatine", UserName = email, Email = email, Active = true, GroupId = 8 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);


            context.Documents.AddOrUpdate(d => d.Name,
                new Document { Name = "Test av grupp", Uri = "test1grupp.txt", Description = "Testdokument för att testa kopplat till grupp. Helt klart ett test. Ett test är det. Nån som vill ha kaffe?", UploadTime = new DateTime(2015, 09, 30), GroupId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "test1grupp.txt" },
                new Document { Name = "Test av kurs", Uri = "test1kurs.txt", Description = shortLorem, UploadTime = new DateTime(2015, 10, 02), CourseId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "test1kurs.txt" },
                new Document { Name = "Test av aktivitet", Uri = "test1aktivitet.txt", Description = longLorem, UploadTime = new DateTime(2015, 10, 05), ActivityId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "test1aktivitet.txt" }
                );

        }



        private static void CreateUserSeedWithPasswordSecret(ApplicationDbContext context, UserManager<ApplicationUser> manager, string email, ApplicationUser user, RoleManager<IdentityRole> roleManager, string[] roles)
        {


            if (!context.Users.Any(u => u.UserName == email))
            {
                manager.Create(user, "secret");         // set user's password to "secret" (this is for dev purposes only)
                manager.UpdateSecurityStamp(user.Id);   // set the user's security stamp to use when requesting new password

                context.SaveChanges();
            }


            var databaseUser = context.Users.First(u => u.UserName == user.UserName);
            foreach (string role in roles)  // go through and seed the user's roles (lärare and/or elev)
            {
                if (!databaseUser.Roles.Any(r => r.RoleId == roleManager.FindByName(role).Id))
                {
                    manager.AddToRoles(databaseUser.Id, role);
                }
            }

        }
    }
}
