using System;

namespace HrApiProject.Area.Repositories.Employee
{
    public class EmployeeResponseMessages
    {

        public class ErrorCodes
        {
            public int ResponseCode {get; set;}
            public string Message {get; set;}
        }

        public object EmployeeAddedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1001;
            ec.Message = "Employee Added SuccessFully";
            return ec;

        }
         public object EmployeeUpdatedSucces()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1002;
            ec.Message = "Employee Updated SuccessFully";
            return ec;

        }
        
         public object EmployeeDeactivatedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1003;
            ec.Message = "Employee Deactivated SuccessFully";
            return ec;

        }

        public object EmployeeActivatedSuccess() 
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1004;
            ec.Message = "Employee Activated SuccessFully";
            return ec;
        }

        public object EmployeeAddedFailed()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2001;
            ec.Message = "Employee Insertion Failed ";
            return ec;

        }

        public object DepartmentIdDoesNotExist(Guid DepartmentId)
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2002;
            ec.Message = "This Department id ( " + DepartmentId +" ) does not exists ";
            return ec;
        }
        public object EmployeeIdDoesNotExist(Guid empId)
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2003;
            ec.Message = "This Employee id ( " + empId +" ) does not exists ";
            return ec;
        }
        
        public object NoEmployeeFound()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2004;
            ec.Message = "No Employee Record Found ";
            return ec;
        }

   

        
    }
}