using MvcRepoCrud.Database;
using MvcRepoCrud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRepoCrud.Services
{
    public class DepartmentService
    {
        public List<Department> GetDepartments()
        {
            using (var context = new ProjectDbContext())
            {
                return context.Departments.ToList();
            }
        }

        public Department GetDepartment(int id)
        {
            using (var context = new ProjectDbContext())
            {
                return context.Departments.Find(id);
            }
        }

        public void SaveDepartment(Department department)
        {
            using (var context = new ProjectDbContext())
            {
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }

        public void UpdateDepartment(Department department)
        {
            using (var context = new ProjectDbContext())
            {
                context.Entry(department).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            using (var context = new ProjectDbContext())
            {
                var department = context.Departments.Find(id);

                context.Departments.Remove(department);
                context.SaveChanges();
            }
        }
    }
}
