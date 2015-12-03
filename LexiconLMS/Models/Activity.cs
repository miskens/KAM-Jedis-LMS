using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LexiconLMS.Models
{
    public class Activity
    {
        [Key]
        [Display(Name = "Aktivitet")]
        public int Id { get; set; }

        [Display(Name = "Aktivitetsnamn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Typ")]
        public string Type { get; set; }

        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "KursId")]
        public int CourseId { get; set; }
    }
}