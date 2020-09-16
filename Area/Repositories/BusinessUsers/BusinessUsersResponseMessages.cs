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

        public object BusinessUserDeactivatedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1002;
            rcam.ResponseMessage = "Business User Deactivated successfully";
            return rcam;
        } 
        public object BusinessUserActivatedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1003;
            rcam.ResponseMessage = "Business User Activated successfully";
            return rcam;
        } 

        public object BusinessUserAddedFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2001;
            rcam.ResponseMessage = "Business User Addition Failed !!";
            return rcam;
        } 

         public object BusinessUserDeactivatedFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2002;
            rcam.ResponseMessage = "Business User Deactivation Failed";
            return rcam;
        } 

         public object BusinessUserActivatedFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2003;
            rcam.ResponseMessage = "Business User Activation Failed";
            return rcam;
        } 


        
         
        
    }
}