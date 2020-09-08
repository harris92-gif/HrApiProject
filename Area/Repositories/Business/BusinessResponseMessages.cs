namespace HrApiProject.Area.Repositories.Business
{
    public class ErrorCode
    {
        public int ResponseCode {get; set;}
        public string Message {get; set;}
    }
    public class BusinessResponseMessages
    {
        public object BusinessAdded ()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 1001;
            ec.Message = "Business Added Successfully";
            return ec;
        }
         public object BusinessInsertionFailed ()
        {
            ErrorCode ec = new ErrorCode();
            ec.ResponseCode = 2001;
            ec.Message = "Business Addition Failed ";
            return ec;
        }
        
    }
}