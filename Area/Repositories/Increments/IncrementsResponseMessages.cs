namespace HrApiProject.Area.Repositories.Increments
{
    public class ResponseCodesAndMessages
    {
        public int ResponseCode {get; set;}
        public string ResponseMessage {get; set;}
    }
    public class IncrementsResponseMessages
    {

        public object IncrementsAddedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Increments Added Successfully";
            return rcam;
        }
        public object IncrementUpdatedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1002;
            rcam.ResponseMessage = "Increments Updated Successfully";
            return rcam;
        }

         public object InvalidAmount()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2001;
            rcam.ResponseMessage = "Amount Must Be Greater then 0";
            return rcam;

        }
        public object DescNotProvided()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2002;
            rcam.ResponseMessage = "Description Not Provided";
            return rcam;

        }
        public object DescExceedsLimit()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2003;
            rcam.ResponseMessage = "Descrition length must be less then 100 characters";
            return rcam;

        }

        public object DateNotProvided()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2004;
            rcam.ResponseMessage = "Date Not Provided";
            return rcam;

        }
        public object InvalidDateFormat()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2005;
            rcam.ResponseMessage = "Invalid Date Format (enter YYYY-MM-DD format for date)";
            return rcam;

        }

       
        
    }
}