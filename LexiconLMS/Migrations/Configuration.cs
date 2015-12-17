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
            string previousKnowledge = " Förkunskaper:  if (previousKnowledge == ”Högskoleutbildade inom IT eller övriga tekniska discipliner som bedöms lämpliga i den förberedande utbildningen” || ”Personer som har stort intresse, erfarenhet och kunskaper i programmering eller andra IT-relaterade områden och som har bedömts som lämpliga i den förberedande utbildningen 'Testmodul IT Påbyggnadsutbildning' utbildnings nr 104800 . Deltagare ska kunna behärska engelska på gymnasienivå eller ha motsvarande kunskaper då arbetsmarknaden krav ofta ställer krav på affärs/fackengelska inom IT området”)";
            string systemutvecklareDotNet = "'Systemutvecklare.NET' innehåller C#, .Net, SQL, Applikationsutveckling, Test & testledning.  Syftet med utbildningen är att i första hand erbjuda påbyggnad- och vidareutbildning för personer med befintliga kunskaper inom Systemutveckling. ";
            string shortLorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            string longLorem = shortLorem + " " + shortLorem + " " + shortLorem + " " + shortLorem;

         context.Groups.AddOrUpdate(g => g.Name,
            new Group { Name = "nd15", Description = systemutvecklareDotNet + previousKnowledge, StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2016, 02, 28) },
            new Group { Name = "nf15", Description = systemutvecklareDotNet, StartDate = new DateTime(2015, 11, 23), EndDate = new DateTime(2016, 03, 12) },
            new Group { Name = "Java", Description = shortLorem, StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2015, 12, 15) },
            new Group { Name = "Sharepoint1", Description = shortLorem, StartDate = new DateTime(2015, 01, 11), EndDate = new DateTime(2015, 03, 10) },
            new Group { Name = ".net1", Description = shortLorem, StartDate = new DateTime(2015, 01, 11), EndDate = new DateTime(2015, 03, 30) },
            new Group { Name = "Sharepoint2", Description = longLorem, StartDate = new DateTime(2015, 03, 03), EndDate = new DateTime(2015, 05, 12) },
            new Group { Name = ".net2", Description = longLorem, StartDate = new DateTime(2015, 04, 05), EndDate = new DateTime(2015, 06, 15) },
            new Group { Name = "Sharepoint3", Description = shortLorem, StartDate = new DateTime(2015, 04, 07), EndDate = new DateTime(2015, 06, 16) },
            new Group { Name = "ng16", Description = shortLorem, StartDate = new DateTime(2016, 01, 12), EndDate = new DateTime(2016, 04, 10) },
            new Group { Name = "sg16", Description = longLorem, StartDate = new DateTime(2016, 01, 03), EndDate = new DateTime(2016, 02, 10) },
            new Group { Name = "sh16", Description = longLorem, StartDate = new DateTime(2016, 03, 07), EndDate = new DateTime(2016, 05, 08) },
            new Group { Name = "si16", Description = shortLorem, StartDate = new DateTime(2016, 04, 01), EndDate = new DateTime(2016, 06, 01) }
        );

            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.Name,
                new Course { Name = "Java 101", Description = "En introduktion till Java", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2015, 10, 24), GroupId = 3 },
                new Course { Name = "Java 102", Description = shortLorem, StartDate = new DateTime(2015, 10, 25), EndDate = new DateTime(2015, 11, 10), GroupId = 3 },
                new Course { Name = "Java 103", Description = longLorem, StartDate = new DateTime(2015, 11, 11), EndDate = new DateTime(2015, 12, 15), GroupId = 3 },
                new Course { Name = "C# 100", Description = "C# introduktion", StartDate = new DateTime(2015, 08, 31), EndDate = new DateTime(2015, 09, 10), GroupId = 1 },
                new Course { Name = "C# 101", Description = shortLorem, StartDate = new DateTime(2015, 09, 12), EndDate = new DateTime(2015, 09, 30), GroupId = 1 },
                new Course { Name = "C# Överkurs", Description = shortLorem, StartDate = new DateTime(2015, 10, 01), EndDate = new DateTime(2015, 12, 16), GroupId = 1 },
                new Course { Name = "C# 100", Description = "C# introduktion", StartDate = new DateTime(2015, 11, 23), EndDate = new DateTime(2015, 12, 15), GroupId = 2 },
                new Course { Name = "C# 101", Description = shortLorem, StartDate = new DateTime(2015, 12, 16), EndDate = new DateTime(2016, 01, 30), GroupId = 2 },
                new Course { Name = "C# Överkurs", Description = shortLorem, StartDate = new DateTime(2016, 01, 31), EndDate = new DateTime(2016, 03, 12), GroupId = 2 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2015, 10, 15), GroupId = 1 },
                new Course { Name = "Java included", Description = shortLorem, StartDate = new DateTime(2015, 10, 16), EndDate = new DateTime(2015, 10, 30), GroupId = 1 },
                new Course { Name = "Scrum", Description = "Utveckling av Lexicon LMS i tre parallella Scrumprojekt", StartDate = new DateTime(2015, 11, 27), EndDate = new DateTime(2015, 12, 18), GroupId = 1 },
                new Course { Name = "Praktik", Description = longLorem, StartDate = new DateTime(2016, 01, 04), EndDate = new DateTime(2016, 01, 23), GroupId = 1 },
                new Course { Name = ".net grund", Description = longLorem, StartDate = new DateTime(2015, 11, 30), EndDate = new DateTime(2016, 12, 10), GroupId = 2 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 01, 11), EndDate = new DateTime(2016, 01, 19), GroupId = 5 },
                new Course { Name = "C# 102", Description = shortLorem, StartDate = new DateTime(2015, 01, 21), EndDate = new DateTime(2015, 01, 22), GroupId = 5 },
                new Course { Name = "C# 103", Description = longLorem, StartDate = new DateTime(2015, 01, 23), EndDate = new DateTime(2015, 01, 29), GroupId = 5 },
                new Course { Name = "C# 104", Description = shortLorem, StartDate = new DateTime(2015, 01, 30), EndDate = new DateTime(2015, 02, 15), GroupId = 5 },
                new Course { Name = "C# 105", Description = longLorem, StartDate = new DateTime(2015, 02, 16), EndDate = new DateTime(2015, 02, 28), GroupId = 5 },
                new Course { Name = "C# 106", Description = shortLorem, StartDate = new DateTime(2015, 02, 28), EndDate = new DateTime(2015, 03, 18), GroupId = 5 },
                new Course { Name = "Sharepoint newbie", Description = "Färskingar!", StartDate = new DateTime(2015, 01, 11), EndDate = new DateTime(2015, 01, 22), GroupId = 6 },
                new Course { Name = "Sharepoint mellannivå", Description = "Inte nybörjare, inte expert?", StartDate = new DateTime(2015, 01, 03), EndDate = new DateTime(2015, 02, 04), GroupId = 6 },
                new Course { Name = "Sharepoint expert", Description = "Sharepoint för experter, övriga göre sig ej besvär!", StartDate = new DateTime(2015, 02, 05), EndDate = new DateTime(2015, 02, 28), GroupId = 6 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 03, 01), EndDate = new DateTime(2015, 03, 19), GroupId = 7 },
                new Course { Name = "C# start", Description = shortLorem, StartDate = new DateTime(2015, 03, 21), EndDate = new DateTime(2015, 03, 22), GroupId = 7 },
                new Course { Name = "C# ground", Description = longLorem, StartDate = new DateTime(2015, 03, 23), EndDate = new DateTime(2015, 03, 29), GroupId = 7 },
                new Course { Name = "C# framework", Description = shortLorem, StartDate = new DateTime(2015, 04, 30), EndDate = new DateTime(2015, 04, 15), GroupId = 7 },
                new Course { Name = "C# SQL", Description = longLorem, StartDate = new DateTime(2015, 05, 16), EndDate = new DateTime(2015, 05, 28), GroupId = 7 },
                new Course { Name = "C# sharp", Description = shortLorem, StartDate = new DateTime(2015, 05, 29), EndDate = new DateTime(2015, 06, 12), GroupId = 7 },
                new Course { Name = "Sharepoint newbie", Description = shortLorem, StartDate = new DateTime(2015, 04, 11), EndDate = new DateTime(2015, 04, 22), GroupId = 8 },
                new Course { Name = "Sharepoint mellannivå", Description = longLorem, StartDate = new DateTime(2015, 04, 23), EndDate = new DateTime(2015, 05, 04), GroupId = 8 },
                new Course { Name = "Sharepoint expert", Description = shortLorem, StartDate = new DateTime(2015, 05, 05), EndDate = new DateTime(2015, 05, 30), GroupId = 8 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2016, 01, 11), EndDate = new DateTime(2016, 02, 19), GroupId = 9 },
                new Course { Name = "Sharepoint newbie", Description = shortLorem, StartDate = new DateTime(2016, 01, 11), EndDate = new DateTime(2016, 02, 02), GroupId = 10 },
                new Course { Name = "Sharepoint newbie", Description = longLorem, StartDate = new DateTime(2016, 03, 11), EndDate = new DateTime(2016, 04, 22), GroupId = 11 },
                new Course { Name = "Sharepoint newbie", Description = shortLorem, StartDate = new DateTime(2016, 04, 11), EndDate = new DateTime(2016, 05, 22), GroupId = 12 }
                );
            context.SaveChanges();

            context.Activities.AddOrUpdate(a => a.Name,
                new Activity { Name = "C# för den allvetande", Description = "Det allvetande programmet regerar", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 10, 01), EndDate = new DateTime(2015, 11, 01), CourseId = 6 },
                new Activity { Name = "Inlämningsuppgift C#", Description = "Gör ett lyxigt garage!", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 11, 02), EndDate = new DateTime(2015, 12, 12), CourseId = 6 },
                new Activity { Name = "C# med framework", Description = shortLorem, Type = "inlämningsuppgift", StartDate = new DateTime(2015, 12, 15), EndDate = new DateTime(2015, 12, 16), CourseId = 6 },
                new Activity { Name = "C# för den allvetande", Description = "Det allvetande programmet regerar", Type = "E-Learning", StartDate = new DateTime(2015, 11, 23), EndDate = new DateTime(2015, 12, 30), CourseId = 9 },
                new Activity { Name = "Inlämningsuppgift C#", Description = "Gör ett lyxigt garage!", Type = "inlämningsuppgift", StartDate = new DateTime(2016, 01, 03), EndDate = new DateTime(2016, 01, 25), CourseId = 9 },
                new Activity { Name = "C# för den allvetande", Description = shortLorem, Type = "E-Learning", StartDate = new DateTime(2016, 01, 26), EndDate = new DateTime(2016, 03, 12), CourseId = 9 },
                new Activity { Name = "Laboration i Java 101", Description = "Första labben i Java", Type = "laboration", StartDate = new DateTime(2015, 10, 04), EndDate = new DateTime(2015, 10, 06), CourseId = 3 },
                new Activity { Name = "Laboration 2 i Java 101", Description = "Andra labben i Java", Type = "laboration", StartDate = new DateTime(2015, 10, 14), EndDate = new DateTime(2015, 10, 18), CourseId = 3 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2015, 01, 20), EndDate = new DateTime(2015, 02, 06), CourseId = 4 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2015, 03, 21), EndDate = new DateTime(2015, 05, 07), CourseId = 6 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2015, 05, 20), EndDate = new DateTime(2015, 06, 08), CourseId = 8 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2016, 01, 20), EndDate = new DateTime(2016, 02, 06), CourseId = 10 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2016, 03, 21), EndDate = new DateTime(2016, 05, 07), CourseId = 11 },
                new Activity { Name = "Laboration Java included", Description = shortLorem, Type = "laboration", StartDate = new DateTime(2015, 10, 24), EndDate = new DateTime(2015, 10, 30), CourseId = 11 },
                new Activity { Name = "Lexicon LMS", Description = "Skapa produktbacklogg med ägaren, planera upp sprintbackloggar", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 12, 02), EndDate = new DateTime(2015, 12, 02), CourseId = 12 },
                new Activity { Name = "E-kurs med Scott Allen", Description = shortLorem, Type = "laboration", StartDate = new DateTime(2015, 12, 02), EndDate = new DateTime(2015, 12, 18), CourseId = 11 },
                new Activity { Name = "Sprint övning", Description = "Sprint 'Review' och 'Retrospective' mm", Type = "rapportering", StartDate = new DateTime(2015, 12, 09), EndDate = new DateTime(2015, 12, 09), CourseId = 12 },
                new Activity { Name = "Scrum projekt", Description = "'Köra' veckovisa sprintar för att skapa Lexicons LMS, göra demostrationer och återblickar samt förbättringar", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 12, 01), EndDate = new DateTime(2015, 12, 17), CourseId = 12 },
                new Activity { Name = "Scrum Postgame", Description = "Slutdemonstration av produkten inför 'productowners && users' samt överlämning av dokument", Type = "inlämningsuppgift", StartDate = new DateTime(2015, 12, 18), EndDate = new DateTime(2015, 12, 18), CourseId = 12 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2015, 01, 17), EndDate = new DateTime(2015, 02, 08), CourseId = 21 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2016, 01, 18), EndDate = new DateTime(2016, 01, 21), CourseId = 34 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2016, 03, 18), EndDate = new DateTime(2016, 03, 21), CourseId = 35 },
                new Activity { Name = "Sharepoint done", Description = shortLorem, Type = "övning", StartDate = new DateTime(2016, 04, 18), EndDate = new DateTime(2016, 04, 21), CourseId = 36 }
                
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
            user = new ApplicationUser { FullName = "Kalle Öberg", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "kjelle@nomail.com";
            user = new ApplicationUser { FullName = "Kjell Ek", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "peter@nomail.com";
            user = new ApplicationUser { FullName = "Peter Petersson", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "lena@nomail.com";
            user = new ApplicationUser { FullName = "Lena EK", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "alena@nomail.com";
            user = new ApplicationUser { FullName = "Alien Night", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "stina@nomail.com";
            user = new ApplicationUser { FullName = "Stina Sten", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "anna@nomail.com";
            user = new ApplicationUser { FullName = "Anna Berg", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "sten@nomail.com";
            user = new ApplicationUser { FullName = "Sten Stinasson", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nina@nomail.com";
            user = new ApplicationUser { FullName = "Nina Öberg", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "greta@nomail.com";
            user = new ApplicationUser { FullName = "Greta Grus", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "elina@nomail.com";
            user = new ApplicationUser { FullName = "Elina Arnesson", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "despicableme@eviloverlords.com";
            user = new ApplicationUser { FullName = "Emperor Palpatine", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);


            context.Documents.AddOrUpdate(d => d.Name,
                new Document { Name = "Tillagt gruppdokument", Uri = "gruppdokument.txt", Description = "Testdokument för att testa kopplat till grupp. Helt klart ett test. Ett test är det. Nån som vill ha kaffe?", UploadTime = new DateTime(2015, 09, 30), GroupId = 3, UserId = context.Users.Where(u => u.FullName == "Oscar Jakobsson").FirstOrDefault().Id, OriginalFileName = "gruppdokument.txt" },
                new Document { Name = "gruppinformation", Uri = "studentinformation.txt", Description = "Teleofnnummer till folk", UploadTime = new DateTime(2015, 09, 30), GroupId = 3, UserId = context.Users.Where(u => u.FullName == "Oscar Jakobsson").FirstOrDefault().Id, OriginalFileName = "studentinformation.txt" },
                new Document { Name = "Tillagt kursdokument", Uri = "kursdokument.txt", Description = shortLorem, UploadTime = new DateTime(2015, 10, 02), CourseId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "kursdokument.txt" },
                new Document { Name = "Tillagt kursdokument", Uri = "kursdokument.txt", Description = shortLorem, UploadTime = new DateTime(2015, 10, 02), CourseId = 2, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "kursdokument.txt" },
                new Document { Name = "Tillagt kursdokument", Uri = "kursdokument.txt", Description = shortLorem, UploadTime = new DateTime(2015, 10, 02), CourseId = 3, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "kursdokument.txt" },
                new Document { Name = "Tillagt aktivitetsdokument", Uri = "aktivitetsdokument.txt", Description = longLorem, UploadTime = new DateTime(2015, 10, 05), ActivityId = 1, UserId = context.Users.Where(u => u.FullName == "Oscar Jakobsson").FirstOrDefault().Id, OriginalFileName = "aktivitetsdokument.txt" },
                new Document { Name = "Tillagt aktivitetsdokument", Uri = "aktivitetsdokument.txt", Description = longLorem, UploadTime = new DateTime(2015, 10, 05), ActivityId = 5, UserId = context.Users.Where(u => u.FullName == "Oscar Jakobsson").FirstOrDefault().Id, OriginalFileName = "aktivitetsdokument.txt" },
                new Document { Name = "Tillagt aktivitetsdokument nummer 2", Uri = "aktivitetsdokument2.txt", Description = longLorem, UploadTime = new DateTime(2015, 10, 05), ActivityId = 2, UserId = context.Users.Where(u => u.FullName == "Oscar Jakobsson").FirstOrDefault().Id, OriginalFileName = "aktivitetsdokument2.txt" },
                new Document { Name = "Tillagt aktivitetsdokument nummer många", Uri = "aktivitetsdokument3.txt", Description = longLorem, UploadTime = new DateTime(2015, 10, 05), ActivityId = 3, UserId = context.Users.Where(u => u.FullName == "Adrian Lozano").FirstOrDefault().Id, OriginalFileName = "aktivitetsdokument3.txt" }
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
