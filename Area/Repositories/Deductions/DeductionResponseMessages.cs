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

        

        public object InvalidAmount()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1002;
            rcam.ResponseMessage = "Amount Must Be Greater then 0";
            return rcam;

        }
        public object DescNotProvided()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1003;
            rcam.ResponseMessage = "Description Not Provided";
            return rcam;

        }
        public object DescExceedsLimit()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1004;
            rcam.ResponseMessage = "Descrition length must be less then 100 characters";
            return rcam;

        }

        

        
    }
}