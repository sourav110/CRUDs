using MvcAjaxCrud.Database;
using MvcAjaxCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcAjaxCrud.Controllers
{
    public class DepartmentsController : Controller
    {
        ProjectDbContext _context = new ProjectDbContext();

        // GET: Departments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DepartmentTable(string searchText)
        {
            var departments = _context.Departments.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                departments = departments.Where(dept => dept.Name != null && dept.Name.ToLower()
                                         .Contains(searchText.ToLower())).ToList();
            }

            return PartialView(departments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return RedirectToAction("DepartmentTable");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            return PartialView(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("DepartmentTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("DepartmentTable");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var department = _context.Departments.Find(id);
            return PartialView(department);
        }
    }
}