using MvcRepoCrud.Entities;
using MvcRepoCrud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRepoCrud.Web.Controllers
{
    public class StudentsController : Controller
    {
        StudentService studentService = new StudentService();
        DepartmentService departmentService = new DepartmentService();

        // GET: Students
        public ActionResult Index()
        {
            var students = studentService.GetStudents();

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Student student = new Student();
            student.Departments = departmentService.GetDepartments();

            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = new Student();

                newStudent.Name = student.Name;
                newStudent.RegistrationNo = student.RegistrationNo;
                newStudent.Department = departmentService.GetDepartment(student.DepartmentId);

                //student.Departments = departmentService.GetDepartments();
                studentService.SaveStudent(newStudent);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var existingStudent = studentService.GetStudent(id);
            Student student = new Student();

            student.Id = existingStudent.Id;
            student.Name = existingStudent.Name;
            student.RegistrationNo = existingStudent.RegistrationNo;
            student.DepartmentId = student.Department != null ? student.Department.Id : 0;

            student.Departments = departmentService.GetDepartments();

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var studentToUpdate = studentService.GetStudent(student.Id);

            if (ModelState.IsValid)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.RegistrationNo = student.RegistrationNo;
                studentToUpdate.Department = null;
                studentToUpdate.DepartmentId = student.DepartmentId;

                studentService.UpdateStudent(studentToUpdate);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = studentService.GetStudent(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            studentService.DeleteStudent(student.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var student = studentService.GetStudent(id);
            student.Departments = departmentService.GetDepartments();

            return View(student);
        }
    }
}