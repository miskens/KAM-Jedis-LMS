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

            context.Groups.AddOrUpdate(g => g.Name,
                new Group { Name = "Java", Description = "H�ndiga typer det d�r", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2016, 02, 28) },
                new Group { Name = "C#", Description = "Ny beskrivning", StartDate = new DateTime(2015, 08, 31), EndDate = new DateTime(2015, 12, 18) },
                new Group { Name = "Sharepoint", Description = "Sharepoint f�rr och nu. Den h�r klassen kommer att handla om att sitta och n�ta arslet och klicka p� fram�t- och bak�tknapparna i browsern, samt att klicka i textrutor och ange siffror mellan 1-10. Det kan �ven h�nda att man f�r klicka p� en f�rg f�r att s�tta bakgrundsf�rgen p� en sida.", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 04, 30) },
                new Group { Name = "Dynamics", Description = "Bli mer dynamisk med Dynamics.", StartDate = new DateTime(2015, 10, 22), EndDate = new DateTime(2016, 01, 20) },
                new Group { Name = "Pascal", Description = "Finns det n�n som �nnu anv�nder Pascal?", StartDate = new DateTime(2014, 01, 10), EndDate = new DateTime(2014, 06, 18) },
                new Group { Name = "Python", Description = "En typ av orm, eller ett programmeringsspr�k?", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 04, 30) },
                new Group { Name = "EMACS", Description = "En editor och ett f�nstersystem och ett enprocessoperativsystem, allt i ett!", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 04, 30) },
                new Group { Name = "V�rldsherrav�lde", Description = "Fr�n hantlangare till evil overlord p� 100 dagar.", StartDate = new DateTime(2015, 08, 03), EndDate = new DateTime(2015, 11, 11) }
            );
            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.Name,
                new Course { Name = "Java 101", Description = "En introduktion till Java", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2015, 10, 24), GroupId = 1 },
                new Course { Name = "Java 102", Description = "Java forts�ttning", StartDate = new DateTime(2015, 10, 25), EndDate = new DateTime(2015, 11, 10), GroupId = 1 },
                new Course { Name = "Java 103", Description = "Java forts�ttning", StartDate = new DateTime(2015, 11, 11), EndDate = new DateTime(2015, 12, 20), GroupId = 1 },
                new Course { Name = "Java 101-3", Description = "Java forts�ttning", StartDate = new DateTime(2015, 12, 21), EndDate = new DateTime(2016, 02, 28), GroupId = 1 },
                new Course { Name = "C# 100", Description = "C# introduktion", StartDate = new DateTime(2015, 08, 31), EndDate = new DateTime(2015, 09, 10), GroupId = 2 },
                new Course { Name = "C# 101", Description = "C# introduktion", StartDate = new DateTime(2015, 09, 12), EndDate = new DateTime(2015, 09, 30), GroupId = 2 },
                new Course { Name = "C# 102", Description = "C# forts�ttning", StartDate = new DateTime(2015, 10, 01), EndDate = new DateTime(2015, 10, 22), GroupId = 2 },
                new Course { Name = "C# 103", Description = "C# forts�ttning", StartDate = new DateTime(2015, 10, 23), EndDate = new DateTime(2015, 10, 29), GroupId = 2 },
                new Course { Name = "C# 104", Description = "C# forts�ttning", StartDate = new DateTime(2015, 10, 30), EndDate = new DateTime(2015, 11, 15), GroupId = 2 },
                new Course { Name = "C# 105", Description = "C# forts�ttning", StartDate = new DateTime(2015, 11, 16), EndDate = new DateTime(2015, 11, 28), GroupId = 2 },
                new Course { Name = "C# 106", Description = "C# forts�ttning", StartDate = new DateTime(2015, 11, 29), EndDate = new DateTime(2015, 12, 18), GroupId = 2 },
                new Course { Name = "Sharepoint expert", Description = "Sharepoint f�r experter, �vriga g�re sig ej besv�r!", StartDate = new DateTime(2016, 03, 13), EndDate = new DateTime(2016, 04, 01), GroupId = 3 },
                new Course { Name = "Sharepoint mellanniv�", Description = "Inte nyb�rjare, inte expert?", StartDate = new DateTime(2016, 02, 07), EndDate = new DateTime(2016, 03, 12), GroupId = 3 },
                new Course { Name = "Sharepoint newbie", Description = "F�rskingar!", StartDate = new DateTime(2016, 01, 01), EndDate = new DateTime(2016, 02, 06), GroupId = 3 },
                new Course { Name = "Sharepoint a-z", Description = "Sharepoint f�r experter, �vriga g�re sig ej besv�r!", StartDate = new DateTime(2016, 04, 02), EndDate = new DateTime(2016, 04, 30), GroupId = 3 },
                new Course { Name = "Pythonormars sk�tsel", Description = "Ormskr�cken b�rjar h�r!", StartDate = new DateTime(2016, 01, 05), EndDate = new DateTime(2016, 04, 28), GroupId = 6 },
                new Course { Name = ".net grund", Description = "E-kurs med Scott Allen", StartDate = new DateTime(2015, 09, 30), EndDate = new DateTime(2016, 09, 30), GroupId = 2 },
                new Course { Name = "Hantlangarsk�tsel", Description = "Dina minioner v�lbefinnande �r n�dv�ndig f�r att framg�ngsrikt ta �ver v�rlden.", StartDate = new DateTime(2015, 08, 03), EndDate = new DateTime(2015, 08, 30), GroupId = 8 },
                new Course { Name = "Ondskefulla skratt a-z", Description = "Skrattar f�rst som skrattar b�st som skattar mest.", StartDate = new DateTime(2015, 09, 01), EndDate = new DateTime(2015, 09, 15), GroupId = 8 },
                new Course { Name = "Ondskefulla skratt 101", Description = "Skrattar f�rst som skrattar b�st.", StartDate = new DateTime(2015, 09, 16), EndDate = new DateTime(2015, 09, 30), GroupId = 8 },
                new Course { Name = "Ondskefulla skratt 102", Description = "Forts�ttningskurs i elaka och ondskefulla skratt. Nu med fokus p� andningen.", StartDate = new DateTime(2015, 10, 01), EndDate = new DateTime(2015, 11, 11), GroupId = 8 }
                );
            context.SaveChanges();

            context.Activities.AddOrUpdate(a => a.Name,
                new Activity { Name = "Laboration i Java 101", Description = "F�rsta labben i Java", Type = "laboration", StartDate = new DateTime(2015, 10, 04), EndDate = new DateTime(2015, 10, 06), CourseId = 1 },
                new Activity { Name = "Laboration 2 i Java 101", Description = "Andra labben i Java", Type = "laboration", StartDate = new DateTime(2015, 10, 14), EndDate = new DateTime(2015, 10, 18), CourseId = 1 },
                new Activity { Name = "Sharepoint fr�n b�rjan", Description = "B�rja fr�n b�rjan", Type = "�vning", StartDate = new DateTime(2016, 01, 20), EndDate = new DateTime(2016, 02, 06), CourseId = 14 },
                new Activity { Name = "C# f�r den allvetande", Description = "Den allvetande skr�ph�gen regerar", Type = "inl�mningsuppgift", StartDate = new DateTime(2015, 11, 01), EndDate = new DateTime(2015, 11, 09), CourseId = 9 },
                new Activity { Name = "Skrattlabb", Description = "Anv�ndning av diafragman vid elakt skratt.", Type = "laboration", StartDate = new DateTime(2015, 11, 02), EndDate = new DateTime(2015, 11, 08), CourseId = 21 },
                new Activity { Name = "Historiskt skrattande", Description = "L�r dig skratta som historiska ondskefulla typer", Type = "laboration", StartDate = new DateTime(2015, 09, 10), EndDate = new DateTime(2015, 09, 15), CourseId = 19 },
                new Activity { Name = "Inl�mningsuppgift i skratt", Description = "Spela in dig sj�lv medan du flabbar som en galen typ som just tagit �ver v�rldsherrav�ldet!", Type = "inl�mningsuppgift", StartDate = new DateTime(2015, 10, 04), EndDate = new DateTime(2015, 10, 09), CourseId = 21 },
                new Activity { Name = "Inl�mningsuppgift C#", Description = "G�r ett lyxigt garage!", Type = "inl�mningsuppgift", StartDate = new DateTime(2015, 11, 29), EndDate = new DateTime(2015, 12, 05), CourseId = 11 }
                );
            context.SaveChanges();

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (string role in new[] { "elev", "l�rare" })      // seed roles to 
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
            var roles = new[] { "l�rare" };
            var user = new ApplicationUser { FullName = "Oscar Jakobsson", Email = email, UserName = email, Active = true };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "adrian@xenotype.com";
            // same roles as previous
            user = new ApplicationUser { FullName = "Adrian Lozano", UserName = email, Email = email, Active = true };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "kenneth.forsstrom@hotmail.com";
            roles = new[] { "elev" };
            user = new ApplicationUser { FullName = "Kenneth Forsstr�m", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "vitastjern@gmail.com";
            // same as student above
            user = new ApplicationUser { FullName = "Anna Eklund", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "miskens@hotmail.com";
            user = new ApplicationUser { FullName = "Michael Puusaari", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "matti.boustedt@gmail.com";
            user = new ApplicationUser { FullName = "Matti Boustedt", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "a.ronnegard@gmail.com";
            user = new ApplicationUser { FullName = "Anna-Karin R�nneg�rd", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "jonasjakobsson.sundbyberg@gmail.com";
            user = new ApplicationUser { FullName = "Jonas Jakobsson", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "staffan.ericsson2@gmail.com";
            user = new ApplicationUser { FullName = "Staffan Ericsson", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "christinamkronblad@yahoo.se";
            user = new ApplicationUser { FullName = "Christina Kronblad", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "olga.kagyrina@gmail.com";
            user = new ApplicationUser { FullName = "Olga Kagyrina", UserName = email, Email = email, Active = false, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nina@gmail.se";
            user = new ApplicationUser { FullName = "Nina Oksa", UserName = email, Email = email, Active = false, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "adnansweden14@gmail.com";
            user = new ApplicationUser { FullName = "Fredrik Hedlund", UserName = email, Email = email, Active = false, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nisaw99@hotmail.com";
            user = new ApplicationUser { FullName = "Niklas S�wensten", UserName = email, Email = email, Active = true, GroupId = 2 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "kalle@nomail.com";
            user = new ApplicationUser { FullName = "Kalle �berg", UserName = email, Email = email, Active = true, GroupId = 6 };
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
            user = new ApplicationUser { FullName = "Anna Berg", UserName = email, Email = email, Active = true, GroupId = 1 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "sten@nomail.com";
            user = new ApplicationUser { FullName = "Sten Stinasson", UserName = email, Email = email, Active = true, GroupId = 7 };
            CreateUserSeedWithPasswordSecret(context, manager, email, user, roleManager, roles);

            email = "nina@nomail.com";
            user = new ApplicationUser { FullName = "Nina �berg", UserName = email, Email = email, Active = true, GroupId = 1 };
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
                new Document { Name = "Test av grupp", Uri = "test1grupp.txt", Description = "Testdokument f�r att testa kopplat till grupp. Helt klart ett test. Ett test �r det. N�n som vill ha kaffe?", UploadTime = new DateTime(2015, 09, 30), GroupId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Locano").FirstOrDefault().Id, OriginalFileName= "test1grupp.txt"},
                new Document { Name = "Test av kurs", Uri = "test1kurs.txt", Description = "Testdokument f�r att testa kopplat till kurs. Helt klart ett test. Ett test �r det. N�n som vill ha kaffe?", UploadTime = new DateTime(2015, 10, 02), CourseId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Locano").FirstOrDefault().Id, OriginalFileName = "test1kurs.txt" },
                new Document { Name = "Test av aktivitet", Uri = "test1aktivitet.txt", Description = "Testdokument f�r att testa kopplat till aktivitet. Helt klart ett test. Ett test �r det. N�n som vill ha kaffe?", UploadTime = new DateTime(2015, 10, 05), ActivityId = 1, UserId = context.Users.Where(u => u.FullName == "Adrian Locano").FirstOrDefault().Id, OriginalFileName = "test1aktivitet.txt" }
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
            foreach (string role in roles)  // go through and seed the user's roles (l�rare and/or elev)
            {
                if (!databaseUser.Roles.Any(r => r.RoleId == roleManager.FindByName(role).Id))
                {
                    manager.AddToRoles(databaseUser.Id, role);
                }
            }

        }
    }
}
