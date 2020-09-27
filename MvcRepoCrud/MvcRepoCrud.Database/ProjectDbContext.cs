using MvcRepoCrud.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcRepoCrud.Database
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() : base("ProjectDbConnection")
        {}

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
