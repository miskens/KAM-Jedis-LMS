using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using LexiconLMS.Models;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    public class Functions
    {
        private static ApplicationDbContext context = new ApplicationDbContext();

        public static SmtpClient ConfigureSmtpClient()
        {
            SmtpClient client = new SmtpClient();

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("Lexicontestmail@gmail.com", "T3st1ngMail");
            client.Host = "smtp.gmail.com";

            return client;
        }

        public static string CheckDatesForGroup(DateTime startDate, DateTime endDate, DateTime today)
        {
            string msg = string.Empty;
            if (startDate > endDate)
            {
                return msg = "Startdatum måste vara tidigare än slutdatum.";
            }
            if (endDate < today)
            {
                return msg = "Slutdatum får ej vara tidigare än dagens datum.";
            }
            if ((endDate.Month == 02 && endDate.Day == 30) || (startDate.Month == 02 && startDate.Day == 30))
            {
                //Lägg till koll för skottår när det finns tid
                return msg = "Den dagen finns inte i den angivna månaden.";
            }

            return msg;
        }

        public static string CheckDatesForCourse(Course model, DateTime groupStart, DateTime groupEnd, DateTime today)
        {
            string msg = string.Empty;
            if (model.StartDate > model.EndDate)
            {
                return msg = "Startdatum måste vara tidigare än slutdatum.";
            }
            if (model.EndDate < today)
            {
                return msg = "Slutdatum får ej vara tidigare än dagens datum.";
            }
            if (model.StartDate < groupStart)
            {
                return msg = "Kurs kan inte börja tidigare än Gruppen som den tillhör.";
            }
            if (model.EndDate > groupEnd)
            {
                return msg = "Kurs kan inte sluta senare än Gruppen som den tillhör.";
            }
            if ((model.EndDate.Month == 02 && model.EndDate.Day == 30) || (model.StartDate.Month == 02 && model.StartDate.Day == 30))
            {
                //Lägg till koll för skottår när det finns tid
                return msg = "Den dagen finns inte i den angivna månaden.";                
            }

            return msg;
        }

        public static string CheckDatesForActivity(Activity model, DateTime courseStart, DateTime courseEnd, DateTime today)
        {
            string msg = string.Empty;
            if (model.StartDate > model.EndDate)
            {
                return msg = "Startdatum måste vara tidigare än slutdatum.";
            }
            if (model.EndDate < today)
            {
                return msg = "Slutdatum får ej vara tidigare än dagens datum.";
            }
            if (model.StartDate < courseStart)
            {
                return msg = "Aktivitet kan inte börja tidigare än Kursen som den tillhör.";
            }
            if (model.EndDate > courseEnd)
            {
                return msg = "Aktivitet kan inte sluta senare än Kursen som den tillhör.";
            }
            if ((model.EndDate.Month == 02 && model.EndDate.Day == 30) || (model.StartDate.Month == 02 && model.StartDate.Day == 30))
            {
                //Lägg till koll för skottår när det finns tid
                return msg = "Den dagen finns inte i den angivna månaden.";
            }

            return msg;
        }

        
    }
}