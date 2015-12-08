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

        [StringLength(250, ErrorMessage ="Var god förkorta din beskrivning till 250 tecken eller mindre.")]
        [Required]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Skapad")]
        public DateTime UploadTime { get; set; }

        [Display(Name = "Grupp")]
        public int? GroupId { get; set; }

        [Display(Name = "Kurs")]
        public int? CourseId { get; set; }

        [Display(Name = "Användare")]
        public int UserId { get; set; }

        [Display(Name = "Aktivitet")]
        public int? ActivityId { get; set; }
    }
}