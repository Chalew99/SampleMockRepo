using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIEnableHTTPS.Models;

namespace WebAPIEnableHTTPS.Controllers
{
    public class EmployeesController : ApiController
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmployeeID = 101, EmployeeName = "Anurag"},
            new Employee() { EmployeeID = 102, EmployeeName = "Priyanka"},
            new Employee() { EmployeeID = 103, EmployeeName = "Sambit"},
            new Employee() { EmployeeID = 104, EmployeeName = "Preety"},
        };

        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        public Employee Get(int id)
        {
            return employees.FirstOrDefault(s => s.EmployeeID == id);
        }
    }
}
