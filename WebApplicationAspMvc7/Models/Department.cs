using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAspMvc7.Models
{
    public class Department
    {
        public int Dept_Id { get; set; }
        public string Dept_name { get; set; }
        public List<Department> deptInfo { get; set; }
    }
}