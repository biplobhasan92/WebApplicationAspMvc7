using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAspMvc7.Models
{
    public class Employee
    {
        public int Emp_id { get; set; }
        public string Name { get; set; }
        public int Department_id { get; set; }
        public string Email { get; set;}
        public string Gender { get; set; }
        public List<Department> deptInfo { get; set; }
        // This property holds instances of SelectList items
        // public IEnumerable<SelectListItem> deptList { get; set; }
    }
}