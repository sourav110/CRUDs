﻿using MvcAjaxCrud.Database;
using MvcAjaxCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAjaxCrud.Controllers
{
    public class StudentsController : Controller
    {
        ProjectDbContext _context = new ProjectDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            //var students = _context.Students.Include(x=> x.Department).ToList();

            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Student student = new Student();
            student.Departments = _context.Departments.ToList();

            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            Student newStudent = new Student();

            if (ModelState.IsValid)
            {
                newStudent.Name = student.Name;
                newStudent.RegistrationNo = student.RegistrationNo;
                newStudent.Department = _context.Departments.Find(student.DepartmentId);

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
        public ActionResult Edit(Student student)
        {
            var studentToUpdate = _context.Students.Find(student.Id);

            if (ModelState.IsValid)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.RegistrationNo = student.RegistrationNo;
                studentToUpdate.Department = null;
                studentToUpdate.DepartmentId = student.DepartmentId;

                //_context.Entry(student.Department).State = System.Data.Entity.EntityState.Unchanged;
                //_context.Entry(student).State = System.Data.Entity.EntityState.Modified;

                _context.Students.AddOrUpdate(student);

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