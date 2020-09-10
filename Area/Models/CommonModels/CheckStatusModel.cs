using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.CommonModels
{
    public class CheckStatusModel
    {
        [Column("status")]
        public bool Status {get; set;}
        
    }
}