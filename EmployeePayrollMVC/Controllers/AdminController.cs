using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollMVC.Controllers
{
    public class AdminController : Controller
    {
        private IAdminBL adminBL;
        private EmployeeController employeeController;

        public AdminController (IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin([Bind] AdminModel adminModel) 
        {
            if(ModelState.IsValid)
            {
                var result = this.adminBL.AdminLogin(adminModel);
                TempData["name"] = "Admin";
                //return View(result);
                return RedirectToAction("GetEmployee", "Employee");
            }
            return View(adminModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
