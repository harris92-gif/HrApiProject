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

        
    }
}