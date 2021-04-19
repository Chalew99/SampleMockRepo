using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityDemoMVC.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}