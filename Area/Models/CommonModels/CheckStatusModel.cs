using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.CommonModels
{
    public class CheckStatusModel
    {
        [Column("status")]
        public bool Status {get; set;}

        [Column("checkbusinessid")]
         public bool BusinessIDStatus {get; set;}

         [Column("checkemployeeid")]
        public bool EmployeeIDStatus {get; set;}

        [Column("salaryupdatastatus")]
        public bool salaryUpdateStatus {get; set;}

        [Column("checksalaryid")]
        public bool SalaryIDStatus {get; set;}

        [Column("checkdeductionid")]
        public bool DeductionIDStatus {get; set;}

        
    }
}