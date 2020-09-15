using System;

namespace HrApiProject.Area.Repositories.Common
{

     public class ResponseCodesAndMessages
    {
        public int ResponseCode {get; set;}
        public string ResponseMessage {get; set;}
    }
        
    public class CommonResponseMessages
    {
        public object BusinessIdNotExists(Guid businessId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2001;
            rcam.ResponseMessage = "This business ID (" +businessId + " does not exists)";
            return rcam;

        }
         public object EmployeeIdNotExists(Guid employeeId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2002;
            rcam.ResponseMessage = "Employee ID (" +employeeId + " does not exists)";
            return rcam;

        }

         public object SalaryIdNotExists(Guid salaryId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2003;
            rcam.ResponseMessage = "Salary ID (" +salaryId + " does not exists)";
            return rcam;

        }

        
         public object NoRecordFound()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2004;
            rcam.ResponseMessage = "No Record Found";
            return rcam;

        }
       
        
    }
}