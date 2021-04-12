using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAspMvc7.Models
{
    public class Employee
    {
        public int Emp_id { get; set; }
        public string Name { get; set; }
        public int Department_id { get; set; }
        public string Email { get; set;}
    }
}