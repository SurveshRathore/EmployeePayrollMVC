using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
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
                var result = this.employeeBL.RegisterEmployee(employeeModel);
                return View (result);
            }
            return View(employeeModel);
        }
    public IActionResult Index()
        {
            
            return View();
        }
    }
}
