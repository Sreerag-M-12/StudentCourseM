using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using StudentCourseMVC.Models;

namespace StudentCourseMVC.Mappings
{
    public class CourseMap:ClassMap<Course>
    {
        public CourseMap()
        {
            Table("Courses");
            Id(c=>c.Id);
            Map(c=>c.Name);
            Map(c=>c.ProfessorName);
            References(c=>c.Student).Columns("studId").Unique().Cascade.None();
        }
    }
}