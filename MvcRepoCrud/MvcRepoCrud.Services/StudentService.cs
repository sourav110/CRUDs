using MvcRepoCrud.Database;
using MvcRepoCrud.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRepoCrud.Services
{
    public class StudentService
    {
        public List<Student> GetStudents()
        {
            using (var context = new ProjectDbContext())
            {
                return context.Students.Include(x => x.Department).ToList();
            }
        }

        public Student GetStudent(int id)
        {
            //using (var context = new ProjectDbContext())
            //{
            //    return context.Students.Find(id);
            //}

            var dbContext = new ProjectDbContext();
            return dbContext.Students.Find(id);
        }

        public void SaveStudent(Student student)
        {
            using (var context = new ProjectDbContext())
            {
                context.Entry(student.Department).State = System.Data.Entity.EntityState.Unchanged;
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var context = new ProjectDbContext())
            {
                //context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                //context.Students.Attach(student);

                context.Students.AddOrUpdate(student);
                context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new ProjectDbContext())
            {
                //var student = context.Students.Find(id);
                var student = context.Students.FirstOrDefault(x => x.Id == id);

                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
