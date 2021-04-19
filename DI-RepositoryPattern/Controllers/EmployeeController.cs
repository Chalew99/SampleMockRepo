using DI_RepositoryPattern.DAL;
using DI_RepositoryPattern.GenericRepository;
using DI_RepositoryPattern.Repository;
using DI_RepositoryPattern.Repository.RepositoryUsingEFinMVC.Repository;
using DI_RepositoryPattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI_RepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        //    private IEmployeeRepository _employeeRepository;
        //    public EmployeeController()
        //    {
        //        _employeeRepository = new EmployeeRepository(new EmployeeDBContext());
        //    }
        //    public EmployeeController(IEmployeeRepository employeeRepository)
        //    {
        //        _employeeRepository = employeeRepository;
        //    }
        //    [HttpGet]
        //    public ActionResult Index()
        //    {
        //        var model = _employeeRepository.GetAll();
        //        return View(model);
        //    }
        //    [HttpGet]
        //    public ActionResult AddEmployee()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult AddEmployee(Employee model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _employeeRepository.Insert(model);
        //            _employeeRepository.Save();
        //            return RedirectToAction("Index", "Employee");
        //        }
        //        return View();
        //    }
        //    [HttpGet]
        //    public ActionResult EditEmployee(int EmployeeId)
        //    {
        //        Employee model = _employeeRepository.GetById(EmployeeId);
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult EditEmployee(Employee model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _employeeRepository.Update(model);
        //            _employeeRepository.Save();
        //            return RedirectToAction("Index", "Employee");
        //        }
        //        else
        //        {
        //            return View(model);
        //        }
        //    }
        //    [HttpGet]
        //    public ActionResult DeleteEmployee(int EmployeeId)
        //    {
        //        Employee model = _employeeRepository.GetById(EmployeeId);
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult Delete(int EmployeeID)
        //    {
        //        _employeeRepository.Delete(EmployeeID);
        //        _employeeRepository.Save();
        //        return RedirectToAction("Index", "Employee");
        //    }
        //}

        //    //Generic Repository
        //    private IGenericRepository<Employee> repository = null;
        //    public EmployeeController()
        //    {
        //        this.repository = new GenericRepository<Employee>();
        //    }
        //    public EmployeeController(IGenericRepository<Employee> repository)
        //    {
        //        this.repository = repository;
        //    }
        //    [HttpGet]
        //    public ActionResult Index()
        //    {
        //        var model = repository.GetAll();
        //        return View(model);
        //    }
        //    [HttpGet]
        //    public ActionResult AddEmployee()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult AddEmployee(Employee model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            repository.Insert(model);
        //            repository.Save();
        //            return RedirectToAction("Index", "Employee");
        //        }
        //        return View();
        //    }
        //    [HttpGet]
        //    public ActionResult EditEmployee(int EmployeeId)
        //    {
        //        Employee model = repository.GetById(EmployeeId);
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult EditEmployee(Employee model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            repository.Update(model);
        //            repository.Save();
        //            return RedirectToAction("Index", "Employee");
        //        }
        //        else
        //        {
        //            return View(model);
        //        }
        //    }
        //    [HttpGet]
        //    public ActionResult DeleteEmployee(int EmployeeId)
        //    {
        //        Employee model = repository.GetById(EmployeeId);
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult Delete(int EmployeeID)
        //    {
        //        repository.Delete(EmployeeID);
        //        repository.Save();
        //        return RedirectToAction("Index", "Employee");
        //    }
        //}

        //Mixed mode

        //    //Generic Repository
        //    private IGenericRepository<Employee> repository = null;
        //    public EmployeeController()
        //    {
        //        this.repository = new GenericRepository<Employee>();
        //    }
        //    public EmployeeController(IGenericRepository<Employee> repository)
        //    {
        //        this.repository = repository;
        //    }
        //    [HttpGet]
        //    public ActionResult Index()
        //    {
        //        var model = repository.GetAll();
        //        return View(model);
        //    }
        //    [HttpGet]
        //    public ActionResult AddEmployee()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult AddEmployee(Employee model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            repository.Insert(model);
        //            repository.Save();
        //            return RedirectToAction("Index", "Employee");
        //        }
        //        return View();
        //    }
        //    [HttpGet]
        //    public ActionResult EditEmployee(int EmployeeId)
        //    {
        //        Employee model = repository.GetById(EmployeeId);
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult EditEmployee(Employee model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            repository.Update(model);
        //            repository.Save();
        //            return RedirectToAction("Index", "Employee");
        //        }
        //        else
        //        {
        //            return View(model);
        //        }
        //    }
        //    [HttpGet]
        //    public ActionResult DeleteEmployee(int EmployeeId)
        //    {
        //        Employee model = repository.GetById(EmployeeId);
        //        return View(model);
        //    }
        //    [HttpPost]
        //    public ActionResult Delete(int EmployeeID)
        //    {
        //        repository.Delete(EmployeeID);
        //        repository.Save();
        //        return RedirectToAction("Index", "Employee");
        //    }
        //}

        //Unit of work

        private UnitOfWork<EmployeeDBContext> unitOfWork = new UnitOfWork<EmployeeDBContext>();
        private GenericRepository<Employee> repository;
        private IEmployeeRepository employeeRepository;
        public EmployeeController()
        {
            //If you want to use Generic Repository with Unit of work
            repository = new GenericRepository<Employee>(unitOfWork);
            //If you want to use Specific Repository with Unit of work
            employeeRepository = new EmployeeRepository(unitOfWork);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            //Using Specific Repository
            //var model = employeeRepository.GetEmployeesByDepartment(1);
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            try
            {
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    repository.Insert(model);
                    unitOfWork.Save();
                    //Do Some Other Task with the Database
                    //If everything is working then commit the transaction else rollback the transaction
                    unitOfWork.Commit();
                    return RedirectToAction("Index", "Employee");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int EmployeeId)
        {
            Employee model = repository.GetById(EmployeeId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                unitOfWork.Save();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int EmployeeId)
        {
            Employee model = repository.GetById(EmployeeId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int EmployeeID)
        {
            Employee model = repository.GetById(EmployeeID);
            repository.Delete(model);
            unitOfWork.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}