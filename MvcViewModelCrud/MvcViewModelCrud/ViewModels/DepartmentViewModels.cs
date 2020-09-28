using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcViewModelCrud.ViewModels
{
    public class NewDeptViewModel
    {
        public int DeptId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Abbr { get; set; }
    }

    public class EditDeptViewModel
    {
        public int DeptId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Abbr { get; set; }
    }
}