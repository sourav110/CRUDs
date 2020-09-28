using MvcViewModelCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcViewModelCrud.Database
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() : base("ProjectDbConnection")
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}