using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using StudentCourseMVC.Models;

namespace StudentCourseMVC.Mappings
{
    public class StudentMap:ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(s=>s.Id).GeneratedBy.Identity();
            Map(s => s.Name);
            Map(s => s.Age);
            HasOne(s => s.Course).Cascade.All().PropertyRef(s => s.Student).Constrained();
        }
    }
}