using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace LexiconLMS.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Kursnamn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slutdatum")]
        public DateTime EndDate { get; set; }
        
        //[ForeignKey("Id")]
        //public int Group Group { get; set; }

        [Display(Name = "GruppId")]
        public int GroupId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}