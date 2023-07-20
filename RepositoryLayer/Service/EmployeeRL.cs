using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL :IEmployeeRL
    {
        private readonly IConfiguration iconfiguration;
        private string connectionString;
        private readonly SqlConnection sqlConnection = new SqlConnection();
        public EmployeeRL(IConfiguration configuration) {
            this.connectionString = configuration.GetConnectionString("EmployeeDB");
            sqlConnection.ConnectionString = connectionString;
        }

        public EmployeeModel RegisterEmployee(EmployeeModel employeeModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using(sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("addEmployee", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                    sqlCommand.Parameters.AddWithValue("@EmpProfileImage", employeeModel.EmpProfileImage);
                    sqlCommand.Parameters.AddWithValue("@EmpGender", employeeModel.EmpGender);
                    sqlCommand.Parameters.AddWithValue("@EmpDepartment", employeeModel.EmpDepartment);
                    sqlCommand.Parameters.AddWithValue("@EmpSalary", employeeModel.EmpSalary);
                    sqlCommand.Parameters.AddWithValue("@EmpStartDate", employeeModel.EmpStartDate);
                    sqlCommand.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();

                    if(result >= 1)
                    {
                        return employeeModel; 
                    }
                    else
                        return null;

                }
            }
            catch(Exception ex) {
                throw ex;
            }
            finally
            {
                if(sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public List<EmployeeModel> GetEmployees()
        {
            try
            {
                List<EmployeeModel> employeeList = new List<EmployeeModel>();

                using(sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("GetAllEmployee", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read()){
                            EmployeeModel employeeModel = new EmployeeModel()
                            {
                                EmpID = sqlDataReader.IsDBNull("EmpID") ? 0 : sqlDataReader.GetInt32("EmpID"),
                                EmpName = sqlDataReader.IsDBNull("EmpName") ? string.Empty : sqlDataReader.GetString("EmpName"),
                                EmpProfileImage = sqlDataReader.IsDBNull("EmpProfileImage") ? string.Empty : sqlDataReader.GetString("EmpProfileImage"),
                                EmpGender = sqlDataReader.IsDBNull("EmpGender") ? string.Empty : sqlDataReader.GetString("EmpGender"),
                                EmpDepartment = sqlDataReader.IsDBNull("EmpDepartment") ? string.Empty : sqlDataReader.GetString("EmpDepartment"),
                                EmpSalary = sqlDataReader.IsDBNull("EmpSalary") ? 0 : sqlDataReader.GetInt32("EmpSalary"),
                            };
                            employeeList.Add(employeeModel);

                        }
                        return employeeList;
                    }

                    return null;
                }

                

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }

        public EmployeeModel GetEmployeesById(int empId)
        {
            try
            {

                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("GetEmployeeByID", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@EmpID", empId);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    EmployeeModel employeeModel = new EmployeeModel();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            
                            
                            employeeModel.EmpName = sqlDataReader.IsDBNull("EmpName") ? string.Empty : sqlDataReader.GetString("EmpName");
                            employeeModel.EmpProfileImage = sqlDataReader.IsDBNull("EmpProfileImage") ? string.Empty : sqlDataReader.GetString("EmpProfileImage");
                            employeeModel.EmpGender = sqlDataReader.IsDBNull("EmpGender") ? string.Empty : sqlDataReader.GetString("EmpGender");
                            employeeModel.EmpDepartment = sqlDataReader.IsDBNull("EmpDepartment") ? string.Empty : sqlDataReader.GetString("EmpDepartment");
                            employeeModel.EmpSalary = sqlDataReader.IsDBNull("EmpSalary") ? 0 : sqlDataReader.GetInt32("EmpSalary");
                            

                        }
                        return employeeModel;
                    }

                    return null;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }

        //public string EncryptPass(string password)
        //{
        //    try
        //    {
        //        if(password != string.Empty)
        //        {
        //            byte[] passBytes = new byte[password.Length);
        //            passBytes = Encoding.UTF8.GetBytes(password);
        //            string encodePassword = Convert.ToBase64String(passBytes);
        //            return encodePassword;

        //        }
        //        return "Password is Empty";
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
