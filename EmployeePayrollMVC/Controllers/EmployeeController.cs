using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeBL employeeBL;

        public EmployeeController (IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] EmployeeModel employeeModel) {
           
            if (ModelState.IsValid)
            {
                //var result = this.employeeBL.RegisterEmployee(employeeModel);
                //return View (result);
                employeeBL.RegisterEmployee(employeeModel);
                return RedirectToAction("GetEmployee");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            try
            {
                List<EmployeeModel> empList = new List<EmployeeModel>();
                empList = employeeBL.GetEmployees().ToList();
                return View(empList);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public IActionResult GetEmployeeByID(int id)
        {
            try
            {
                EmployeeModel employeeModel = employeeBL.GetEmployeesById(id);
                return View(employeeModel);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeeBL.GetEmployeesById(id);

            if(employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel); 
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeeBL.GetEmployeesById(id);

            if(employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        {
            if (id != employeeModel.EmpID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employeeModel);
                return RedirectToAction("GetEmployee");
            }
            return View(employeeModel);
        }

        //[HttpGet]
        //public IActionResult GetEmployee()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
