using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCourseMVC.Models
{
    public class Course
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string ProfessorName { get; set; }
        public virtual Student Student { get; set; }
    }
}