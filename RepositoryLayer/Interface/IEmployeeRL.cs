using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeModel RegisterEmployee(EmployeeModel employeeModel);
        public List<EmployeeModel> GetEmployees();
        public EmployeeModel GetEmployeesById(int empId);
    }
}
