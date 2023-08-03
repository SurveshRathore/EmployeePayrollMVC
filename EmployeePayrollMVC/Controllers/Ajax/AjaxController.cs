using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeePayrollMVC.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        private readonly IEmployeeBL employeeBL;

        public AjaxController (IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        //public readonly EmployeeModel employeeModel;
        //public AjaxController(EmployeeModel employeeModel)
        //{
        //    this.employeeModel = employeeModel;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult EmployeeList()
        {

            var data = employeeBL.GetEmployees().ToList();
            return new JsonResult(data);
            
        }
    }
}
