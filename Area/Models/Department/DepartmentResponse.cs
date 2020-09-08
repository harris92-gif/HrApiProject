using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Department
{
    public class DepartmentResponse
    {
        [Key]
        [Column("depatrment_id")]
        public Guid DepartmentID {get; set;}

        [Column("department_name")]

        public string DepartmentName { get; set; }
    }
}