using DI_RepositoryPattern.DAL;
using DI_RepositoryPattern.GenericRepository;
using DI_RepositoryPattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DI_RepositoryPattern.Repository
{
    //public class EmployeeRepository : IEmployeeRepository
    //{
    //    private readonly EmployeeDBContext _context;
    //    public EmployeeRepository()
    //    {
    //        _context = new EmployeeDBContext();
    //    }
    //    public EmployeeRepository(EmployeeDBContext context)
    //    {
    //        _context = context;
    //    }
    //    public IEnumerable<Employee> GetAll()
    //    {
    //        return _context.Employees.ToList();
    //    }
    //    public Employee GetById(int EmployeeID)
    //    {
    //        return _context.Employees.Find(EmployeeID);
    //    }
    //    public void Insert(Employee employee)
    //    {
    //        _context.Employees.Add(employee);
    //    }
    //    public void Update(Employee employee)
    //    {
    //        _context.Entry(employee).State = EntityState.Modified;
    //    }
    //    public void Delete(int EmployeeID)
    //    {
    //        Employee employee = _context.Employees.Find(EmployeeID);
    //        _context.Employees.Remove(employee);
    //    }
    //    public void Save()
    //    {
    //        _context.SaveChanges();
    //    }
    //    private bool disposed = false;
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                _context.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}

    namespace RepositoryUsingEFinMVC.Repository
    {
        //    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
        //    {
        //        public IEnumerable<Employee> GetEmployeesByGender(string Gender)
        //        {
        //            return _context.Employees.Where(emp => emp.Gender == Gender).ToList();
        //        }
        //        public IEnumerable<Employee> GetEmployeesByDepartment(string Dept)
        //        {
        //            return _context.Employees.Where(emp => emp.Dept == Dept).ToList();
        //        }
        //    }
        //}

        public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
        {
            public EmployeeRepository(IUnitOfWork<EmployeeDBContext> unitOfWork)
                : base(unitOfWork)
            {
            }
            public EmployeeRepository(EmployeeDBContext context)
                : base(context)
            {
            }
            public IEnumerable<Employee> GetEmployeesByGender(string Gender)
            {
                return Context.Employees.Where(emp => emp.Gender == Gender).ToList();
            }
            public IEnumerable<Employee> GetEmployeesByDepartment(string Dept)
            {
                return Context.Employees.Where(emp => emp.Dept == Dept).ToList();
            }
        }
    }
}