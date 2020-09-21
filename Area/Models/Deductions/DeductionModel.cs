using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Deductions
{
    public class DeductionModel
    {
        public List<DeductionDetails> DeductionDetails {get; set;}
        
    }

    public class DeductionDetails
    {
        public Guid EmpID { get; set; }        
        public int Amount { get; set; }        
        public DateTime DeductDate { get; set; }         
        public string  Description  { get; set; }        
        
    }

    public class UpdateDeductionModel
    {
           
        public int Amount { get; set; }                 
        public string  Description  { get; set; }        
        
    }




}