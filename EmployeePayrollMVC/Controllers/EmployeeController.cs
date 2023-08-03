using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                ViewBag.image = "~/assests/imgc.png"; 
                return View(empList);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public IActionResult GetEmployeeByID(int EmpID)
        {
            try
            {
                EmpID = (int)HttpContext.Session.GetInt32("EmpID");
                EmployeeModel employeeModel = employeeBL.GetEmployeesById(EmpID);
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
        public IActionResult DeleteConfirmed(int EmpID)
        {
            employeeBL.DeleteEmployee(EmpID);
            return RedirectToAction("GetEmployee");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            id = (int)HttpContext.Session.GetInt32("EmpID");
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

        //[HttpPost]
        //public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        //{
        //    //id = (int)HttpContext.Session.GetInt32("EmpID");
        //    if (id != employeeModel.EmpID)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        employeeBL.UpdateEmployee(employeeModel);
        //        return RedirectToAction("GetEmployeeByID");
        //    }
        //    return View(employeeModel);
        //}

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        {
            employeeModel.EmpID = id;
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employeeModel);
                return RedirectToAction("GetEmployeeByID");
            }
            return View(employeeModel);
        }

        [HttpGet]
        public IActionResult EmpLogin()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult EmpLogin([Bind] EmpLoginModel empLoginModel)
        {
            if(ModelState.IsValid)
            {
                var result = employeeBL.EmployeeLogin(empLoginModel);
                
                if (result != null)
                {
                    HttpContext.Session.SetInt32("EmpID", empLoginModel.EmpID);
                    HttpContext.Session.SetString("EmpName", empLoginModel.EmpName);

                    return RedirectToAction("GetEmployeeByID");
                    
                }
                                 
            }
            return View(empLoginModel);
        }

       

        [HttpGet]
        public IActionResult GetEmployeeDetails(int id)
        {
            int EmpID = (int)HttpContext.Session.GetInt32("EmpID");



            if(EmpID == 0)
            {
                return NotFound();
            }
            return RedirectToAction("GetEmployee");
        }

        
        public void ShowPrimeNumber()
        {
            List<int> primeNumber = new List<int>();
            primeNumber.Add(1);
            primeNumber.Add(3);
            primeNumber.Add(5);
            primeNumber.Add(7);
            primeNumber.Add(11);

            ViewBag.Date = DateTime.Now.ToString();
            ViewData["number"] = primeNumber;
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
