using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Department
{
    public class ExportDepartmentModel
    {
        [Column("department_name")]
        public string DepartmentName { get; set; }
    }
}