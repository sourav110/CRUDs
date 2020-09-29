using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcAjaxCrud.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RegistrationNo { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [NotMapped]
        public List<Department> Departments { get; set; }
    }
}