using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Display(Name="Benämning")]
        public string Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description{ get; set; } 

        [Display(Name = "Startdatum")]
        public DateTime StartDate{ get; set; }

        [Display(Name = "Slutdatum")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}