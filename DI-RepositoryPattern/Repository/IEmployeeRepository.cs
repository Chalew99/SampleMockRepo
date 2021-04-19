using DI_RepositoryPattern.DAL;
using DI_RepositoryPattern.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DI_RepositoryPattern.Repository
{
    //public interface IEmployeeRepository
    //{
    //    IEnumerable<Employee> GetAll();
    //    Employee GetById(int EmployeeID);
    //    void Insert(Employee employee);
    //    void Update(Employee employee);
    //    void Delete(int EmployeeID);
    //    void Save();
    //}

    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesByGender(string Gender);
        IEnumerable<Employee> GetEmployeesByDepartment(string Dept);
    }
}