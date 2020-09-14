using System;
using System.ComponentModel.DataAnnotations;

namespace HrApiProject.Area.Models.Salary
{
    public class SalaryModel
    {
        [Key]
        
        public Guid SalaryID { get; set; } 
        public Guid EmployeeID { get; set; }
        public int Salary { get; set; }

    }
}