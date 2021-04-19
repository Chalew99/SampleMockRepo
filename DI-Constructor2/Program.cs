using System;
using System.Collections.Generic;

namespace DI_Constructor2
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

   
        public interface IEmployeeDAL
        {
            List<Employee> SelectAllEmployees();
        }
        public class EmployeeDAL : IEmployeeDAL
        {
            public List<Employee> SelectAllEmployees()
            {
                List<Employee> ListEmployees = new List<Employee>();
                //Get the Employees from the Database
                //for now we are hard coded the employees
                ListEmployees.Add(new Employee() { ID = 1, Name = "Pranaya", Department = "IT" });
                ListEmployees.Add(new Employee() { ID = 2, Name = "Kumar", Department = "HR" });
                ListEmployees.Add(new Employee() { ID = 3, Name = "Rout", Department = "Payroll" });
                return ListEmployees;
            }
        }


    // Comment constructor injection
    //public class EmployeeBL
    //{
    //    public IEmployeeDAL employeeDAL;
    //    public EmployeeBL(IEmployeeDAL employeeDAL)
    //    {
    //        this.employeeDAL = employeeDAL;
    //    }

    //    public List<Employee> GetAllEmployees()
    //    {
    //        return employeeDAL.SelectAllEmployees();
    //    }
    //}
    
    //Property Injection
        //public class EmployeeBL
        //{
        //    private IEmployeeDAL employeeDAL;
        //    public IEmployeeDAL employeeDataObject
        //    {
        //        set
        //        {
        //            this.employeeDAL = value;
        //        }
        //        get
        //        {
        //            if (employeeDataObject == null)
        //            {
        //                throw new Exception("Employee is not initialized");
        //            }
        //            else
        //            {
        //                return employeeDAL;
        //            }
        //        }
        //    }
        //    public List<Employee> GetAllEmployees()
        //    {
        //        return employeeDAL.SelectAllEmployees();
        //    }
        //}

    //Method Injection
    public class EmployeeBL
    {
        public IEmployeeDAL employeeDAL;

        public List<Employee> GetAllEmployees(IEmployeeDAL _employeeDAL)
        {
            employeeDAL = _employeeDAL;
            return employeeDAL.SelectAllEmployees();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Constructor Injection
            // EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            // PropertInjection
            // EmployeeBL employeeBL = new EmployeeBL();
            // employeeBL.employeeDataObject = new EmployeeDAL();
            // Method Injection
            EmployeeBL employeeBL = new EmployeeBL();
            List<Employee> ListEmployee = employeeBL.GetAllEmployees(new EmployeeDAL());
            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department);
            }
            Console.ReadKey();
        }
    }
}
