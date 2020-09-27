using MvcRepoCrud.Entities;
using MvcRepoCrud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRepoCrud.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        DepartmentService departmentService = new DepartmentService();

        // GET: Departments
        public ActionResult Index()
        {
            var departments = departmentService.GetDepartments();

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
                departmentService.SaveDepartment(department);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = departmentService.GetDepartment(id);

            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentService.UpdateDepartment(department);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var department = departmentService.GetDepartment(id);

            return View(department);
        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {
            departmentService.DeleteDepartment(department.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var department = departmentService.GetDepartment(id);

            return View(department);
        }
    }
}