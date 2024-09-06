using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCourseMVC.Data;
using StudentCourseMVC.Models;

namespace StudentCourseMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using(var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student.Course.Id == 0)
            {
                ModelState.Remove("Course.Id");
            }

            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {

                        if (student.Course != null)
                        {
                            student.Course.Student = student;
                        }

                        session.Save(student);

                        transaction.Commit();

                        return RedirectToAction("Index");
                    }
                }

            }
            return View(student);
        }

        public ActionResult Edit(int studId) { 
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s=>s.Id ==studId);
                return View(student);
            }
        }
        [HttpPost]
        public ActionResult Edit (Student student) {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Update(student);
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        public ActionResult Details(int studId) {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s => s.Id == studId);
                return View(student);
            }
        }
        public ActionResult Delete(int studId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(studId);
                return View(student);
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteProduct(int studId)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var student = session.Get<Student>(studId);
                    session.Delete(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}