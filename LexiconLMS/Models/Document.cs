using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Document
    {
        [Key]
        [Display(Name = "Dokument")]
        public int Id { get; set; }

        [Display(Name = "URI")]
        public string Uri { get; set; }

        [StringLength(50, ErrorMessage="Var god håll namnet under 50 teckens längd.")]
        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage ="Var god förkorta din beskrivning till 500 tecken eller mindre.")]
        [Required]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Skapad")]
        public DateTime UploadTime { get; set; }

        [Display(Name = "Originalets filnamn")]
        public string OriginalFileName { get; set; }

        [Display(Name = "Grupp")]
        public int? GroupId { get; set; }

        [Display(Name = "Kurs")]
        public int? CourseId { get; set; }

        [Display(Name = "Dokumentets ägare")]
        public string UserId { get; set; }

        [Display(Name = "Aktivitet")]
        public int? ActivityId { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}