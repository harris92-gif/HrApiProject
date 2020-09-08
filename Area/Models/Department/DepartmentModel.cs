using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Department
{
    public class DepartmentModel
    {
        [Key]
        [Column("dept_id")]
        public Guid DepartmentID {get ; set;}
        public string DepartmentName { get; set; }
    }
}