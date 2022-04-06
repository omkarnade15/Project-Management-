using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPLProject.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public AddEmployee AddEmployee { get; set; }
    }
}