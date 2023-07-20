using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL: IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;

        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public EmployeeModel RegisterEmployee (EmployeeModel employeeModel) {
            try
            {
                return this.employeeRL.RegisterEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public List<EmployeeModel> GetEmployees() {
            try
            {
                return this.employeeRL.GetEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel GetEmployeesById(int empId)
        {
            try
            {
                return this.employeeRL.GetEmployeesById(empId);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
