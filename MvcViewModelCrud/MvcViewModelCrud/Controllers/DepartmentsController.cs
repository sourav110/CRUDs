using MvcViewModelCrud.Database;
using MvcViewModelCrud.Models;
using MvcViewModelCrud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcViewModelCrud.Controllers
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
        public ActionResult Create(NewDeptViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department();

                department.Name = model.Name;
                department.Abbr = model.Abbr;

                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditDeptViewModel model = new EditDeptViewModel();

            var existingDept = _context.Departments.Find(id);

            model.DeptId = existingDept.Id;
            model.Name = existingDept.Name;
            model.Abbr = existingDept.Abbr;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditDeptViewModel model)
        {
            var deptToUpdate = _context.Departments.Find(model.DeptId);

            if (ModelState.IsValid)
            {
                deptToUpdate.Name = model.Name;
                deptToUpdate.Abbr = model.Abbr;

                _context.Entry(deptToUpdate).State = System.Data.Entity.EntityState.Modified;
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
            department = _context.Departments.Find(department.Id);

            _context.Departments.Remove(department);
            _context.SaveChanges();

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