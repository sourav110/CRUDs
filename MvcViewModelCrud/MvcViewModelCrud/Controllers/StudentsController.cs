using MvcViewModelCrud.Database;
using MvcViewModelCrud.Models;
using MvcViewModelCrud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcViewModelCrud.Controllers
{
    public class StudentsController : Controller
    {
        ProjectDbContext _context = new ProjectDbContext();

        public ActionResult Index()
        {
            //var students = _context.Students.ToList();
            var students = _context.Students.Include(x=> x.Department).ToList();

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            StudentActionViewModel model = new StudentActionViewModel();

            model.Departments = _context.Departments.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StudentActionViewModel model)
        {
            Student newStudent = new Student();

            if (ModelState.IsValid)
            {
                newStudent.Name = model.Name;
                newStudent.RegistrationNo = model.RegistrationNo;
                newStudent.Department = _context.Departments.Find(model.DepartmentId);

                //_context.Entry(student.Department).State = System.Data.Entity.EntityState.Unchanged;
                //_context.Entry(newStudent.Department).State = System.Data.Entity.EntityState.Unchanged;

                _context.Students.Add(newStudent);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentActionViewModel model = new StudentActionViewModel();

            var existingStudent = _context.Students.Find(id);

            model.Id = existingStudent.Id;
            model.Name = existingStudent.Name;
            model.RegistrationNo = existingStudent.RegistrationNo;
            model.DepartmentId = model.Department != null ? model.Department.Id : 0;
            
            model.Departments = _context.Departments.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StudentActionViewModel model)
        {
            var studentToUpdate = _context.Students.Find(model.Id);

            if (ModelState.IsValid)
            {
                studentToUpdate.Name = model.Name;
                studentToUpdate.RegistrationNo = model.RegistrationNo;
                studentToUpdate.Department = null;
                studentToUpdate.DepartmentId = model.DepartmentId;

                //_context.Entry(student.Department).State = System.Data.Entity.EntityState.Unchanged;
                //_context.Entry(student).State = System.Data.Entity.EntityState.Modified;

                //_context.Students.AddOrUpdate(student);

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            //var student = _context.Students.FirstOrDefault(x => x.Id == id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            student = _context.Students.Find(student.Id);

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }
    }
}