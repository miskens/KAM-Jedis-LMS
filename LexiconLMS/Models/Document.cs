using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconLMS.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UploadTime { get; set; }
        
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
    }
}