using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeModel
    {
        [Key]
        public int EmpID { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public string EmpProfileImage { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public string EmpGender { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public string EmpDepartment { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public int EmpSalary { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public DateTime EmpStartDate { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Notes { get; set; }
        
    }
}
