using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCourseMVC.Models
{
    public class Student
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual int Age { get; set; }
        public virtual Course Course { get; set; }

    }
}