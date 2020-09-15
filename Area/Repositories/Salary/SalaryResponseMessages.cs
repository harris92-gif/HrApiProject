using System;

namespace HrApiProject.Area.Repositories.Salary
{
    public class ResponseCodesAndMessages
    {
        public int ResponseCode {get; set;}
        public string ResponseMessage {get; set;}
    }
    public class SalaryResponseMessages
    {

        public object SalaryAddedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Employee Salary Added Successfully !!";
            return rcam;

        }

         public object SalaryUpdatedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Employee Salary Updated Successfully !!";
            return rcam;

        }

        public object SalaryAddedFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2001;
            rcam.ResponseMessage = "Employee Salary Addition Failed";
            return rcam;

        }

        
         public object InValidSalary()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2002;
            rcam.ResponseMessage = "Salary Must be Greater then 0";
            return rcam;

        }

        
         public object SalaryAlreadyAssigned(Guid employeeId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2003;
            rcam.ResponseMessage = "salery is already assigned to employee having id "+employeeId;
            return rcam;

        }

        public object SalaryUpdatedFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2004;
            rcam.ResponseMessage = "Employee Salary Updation Failed";
            return rcam;

        }
        
    }
}