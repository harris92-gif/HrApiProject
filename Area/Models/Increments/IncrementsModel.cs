using System;
using System.Collections.Generic;

namespace HrApiProject.Area.Models.Increments
{
    public class IncrementsModel
    {
        public List<IncrementsDetails> IncrementsDetails{get; set;}
    }

    public class IncrementsDetails
    {
         public Guid EmpID { get; set; }        
        public int IncrementAmount { get; set; }        
        public string  Description  { get; set; } 
        public string IncrementDate { get; set; }         

    }


    public class IncrementsUpdateModel
    {
        
        public int IncrementAmount { get; set; }        
        public string  Description  { get; set; } 
              

    }


}