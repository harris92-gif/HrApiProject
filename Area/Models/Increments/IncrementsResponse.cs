using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Increments
{
    public class IncrementsResponse
    {
        [Key]
        public Guid Incr_ID { get; set; }
        public Guid Emp_Id { get; set; }
        public decimal incr_Amount { get; set; }
        
        public string Description { get; set; }

        public string Incr_Date { get; set; }
    }

   
    public class IncrementResponseInJson
    {
        [Column("incrementdetails")]
        public string IncrementDetails {get; set;}
    }

    public class IncrementsAddingButEmployeeIDsNotPresent
    {
        [Column("notfoundsempids")]
        public Guid[] NotFoundEmployeesIds {get; set;}
    }
}