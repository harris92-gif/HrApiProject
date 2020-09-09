namespace HrApiProject.Area.Repositories.Employee
{
    public class EmployeeResponseMessages
    {

        public class ErrorCodes
        {
            public int ResponseCode {get; set;}
            public string Message {get; set;}
        }

        public object EmployeeAddedSucces()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1001;
            ec.Message = "Employee Added SuccessFully";
            return ec;

        }

        public object EmployeeAddedFailed()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2001;
            ec.Message = "Employee Insertion Failed ";
            return ec;

        }
        
    }
}