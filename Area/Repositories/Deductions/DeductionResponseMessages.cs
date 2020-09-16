namespace HrApiProject.Area.Repositories.Deductions
{
     public class ResponseCodesAndMessages
    {
        public int ResponseCode {get; set;}
        public string ResponseMessage {get; set;}
    }
    public class DeductionResponseMessages
    {

        
        public object DeductionAddedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Deduction Added Successfully ";
            return rcam;

        }

        public object DeductionAdditionFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Deduction Addition Failed ";
            return rcam;

        }

        
    }
}