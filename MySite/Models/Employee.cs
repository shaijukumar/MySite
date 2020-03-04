using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    public class Employee
    {
        [DisplayName("Employee Id")]
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [DisplayName("Employee Salary")]
        [Range(10000, 18000)]
        public float Salary { get; set; }
    }
}