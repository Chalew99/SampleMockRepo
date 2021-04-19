using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreBlack.Model
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        //void Save(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }

}
