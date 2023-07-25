using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public EmployeeModel RegisterEmployee(EmployeeModel employeeModel);
        public List<EmployeeModel> GetEmployees();

        public EmployeeModel GetEmployeesById(int empId);
        public void DeleteEmployee(int empId);
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
    }
}
