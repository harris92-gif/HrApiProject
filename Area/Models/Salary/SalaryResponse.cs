using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Salary
{
    public class SalaryResponse
    {
        [Key]
        [Column("salaryid")]
        public Guid SalaryID { get; set; }
        
        [Column("empid")]
        public Guid EmployeeID { get; set; }
        
        [Column("empsalary")]
        public decimal Salary { get; set; }

        [Column("empname")]
        public string EmployeeName { get; set; }

    }
    public class SalaryWithEmployeeNameResponse
    {
       
        [Column("empname")]
        public string EmployeeName { get; set; }
        
        [Column("empsalary")]
        public decimal Salary { get; set; }

       

    }
}