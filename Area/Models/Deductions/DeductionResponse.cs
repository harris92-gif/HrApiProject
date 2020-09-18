using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Deductions
{
    public class DeductionResponse
    {
        [Key]
        public Guid DeductionID { get; set; }
        public Guid EmployeeID { get; set; }
        public decimal Amount { get; set; }
        public string DeductionDate { get; set; }
        public string Description { get; set; }
        
    }

    public class DeductionResponseInJson
    {
        [Column("deductiondetails")]
        public string DeductionsDetails {get; set;}
    }


    public class DeductionAddingButEmployeeIDsNotPresent
    {
        [Column("notfoundsempids")]
        public Guid[] NotFoundEmployeesIds {get; set;}
    }
}