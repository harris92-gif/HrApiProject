namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public class ResponseCodesAndMessages
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class BusinessUsersResponseMessages
    {
        public object BusinessUserAddedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Business User Added Successfully !!";
            return rcam;

        } 

        public object BusinessUserAddedFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2001;
            rcam.ResponseMessage = "Business User Addition Failed !!";
            return rcam;

        } 
        
    }
}