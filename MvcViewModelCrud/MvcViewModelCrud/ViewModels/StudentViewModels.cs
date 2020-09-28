using MvcViewModelCrud.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcViewModelCrud.ViewModels
{
    public class StudentActionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RegistrationNo { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public List<Department> Departments { get; set; }
    }
}