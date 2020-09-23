using MvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class DepartmentsController : Controller
    {
        ProjectDbContext _context = new ProjectDbContext();

        // GET: Departments
        public ActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {
            if (ModelState.IsValid)
            {
                //_context.Departments.Remove(department);
                _context.Entry(department).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var department = _context.Departments.Find(id);
            return View(department);
        }
    }
}