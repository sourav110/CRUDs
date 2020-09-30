using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvcCrud.Database;
using CoreMvcCrud.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcCrud.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ProjectDbContext _context;

        public StudentsController(ProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(x=> x.Department).ToList();
            return View(students);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Student student = new Student();
            student.Departments = _context.Departments.ToList();

            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            Student newStudent = new Student();

            if (ModelState.IsValid && !IsStudentExists(student.Id))
            {
                newStudent.Name = student.Name;
                newStudent.RegistrationNo = student.RegistrationNo;
                newStudent.Department = _context.Departments.Find(student.DepartmentId);

                _context.Add(newStudent);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = new Student();

            var existingStudent = _context.Students.Find(id);

            student.Id = existingStudent.Id;
            student.Name = existingStudent.Name;
            student.RegistrationNo = existingStudent.RegistrationNo;
            student.DepartmentId = student.Department != null ? student.Department.Id : 0;

            student.Departments = _context.Departments.ToList();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var studentToUpdate = _context.Students.Find(student.Id);

            if (ModelState.IsValid)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.RegistrationNo = student.RegistrationNo;
                studentToUpdate.Department = null;
                studentToUpdate.DepartmentId = student.DepartmentId;

                _context.Update(studentToUpdate);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            student = _context.Students.Find(student.Id);

            _context.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);
            return View(student);
        }


        private bool IsStudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
