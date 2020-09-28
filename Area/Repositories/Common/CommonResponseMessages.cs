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

        public object UserIdNotExists(Guid userId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2005;
            rcam.ResponseMessage = "user ID (" +userId + " does not exists)";
            return rcam;

        }

        
        public object BusinessUserIdNotExists(Guid businessUserId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2006;
            rcam.ResponseMessage = "Business User ID (" +businessUserId + " does not exists)";
            return rcam;

        }

        
        public object TheseEmployeesIdsNotFound(Guid[] employeeIds)
        {
            string[] stringArray = Array.ConvertAll(employeeIds, x => x.ToString()); //converting Guid array to string array
            //now converting string array to strings
            string arrayInOneString = string.Join(" , ",stringArray);

            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2007;
            rcam.ResponseMessage = "Employee Ids (" +arrayInOneString + " ) does not exists)";
            return rcam;

        }


        
        public object DeductionIdNotExists(Guid deductionId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2008;
            rcam.ResponseMessage = "Deduction ID (" +deductionId + " does not exists)";
            return rcam;

        }
        public object IncrementIdNotExists(Guid incrementId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2008;
            rcam.ResponseMessage = "Increment ID " +incrementId + " does not exists)";
            return rcam;

        }

        public object AttendanceIdNotExists(Guid attendanceId)
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2009;
            rcam.ResponseMessage = "Attendance ID " +attendanceId + " does not exists)";
            return rcam;

        }

        
       
        
    }
}