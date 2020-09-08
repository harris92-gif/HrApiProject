using System;

namespace HrApiProject.Area.Repositories.Department
{
    public class ErrorCode
    {
        public int ResponseCode {get; set;} 
        public string Message {get; set;}
    }
    public class DepartmentResponseMessages
    {
       public object EnterDepartmentName()
       {
           ErrorCode ec= new ErrorCode ();
           ec.ResponseCode=2002;
           ec.Message = "Plz Enter Department Name";
           return ec;
       }

    public object InvalidDepartmentName()
       {
           ErrorCode ec= new ErrorCode ();
           ec.ResponseCode=2003;
           ec.Message = "Department Name should contain only letters and  spaces";
           return ec;
       }
        public object DepartmentAdded()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 1001;
            ec.Message = "Department Added Successfully !!";
            return ec;
        }
         public object DepartmentNameUpdated()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 1002;
            ec.Message = "Department Name Updated Successfully";
            return ec;
        }
        
         public object DepartmentInActivated()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 1003;
            ec.Message = "Department status Inactivated Successfully";
            return ec;
        }

          public object DepartmentActivated()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 1003;
            ec.Message = "Department status Activated Successfully";
            return ec;
        }

        public object DepartmentInsertionFailed()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 2001;
            ec.Message = "Department Insertion Failed";
            return ec;
        }

        
         public object IdDoesNotExists(Guid Id)
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 2002;
            ec.Message =  "This id ("+Id+") does not exists";
            return ec;
        }
        
    }
}