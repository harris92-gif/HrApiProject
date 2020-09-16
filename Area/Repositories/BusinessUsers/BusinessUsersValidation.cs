using System.Collections.Generic;

namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public class BusinessUsersValidation
    {
        private readonly BusinessUsersResponseMessages _businessUsersResponseMessages;

        public BusinessUsersValidation(BusinessUsersResponseMessages businessUsersResponseMessages)
        {
            _businessUsersResponseMessages= businessUsersResponseMessages;
        }


         public string Success {get; set;}
        public List<object> ResponseList {get; set;}

        

        public object BusinessUserAddedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(_businessUsersResponseMessages.BusinessUserAddedSuccess());
            return this;

        }
        public object BusinessUserAddedFailed()
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_businessUsersResponseMessages.BusinessUserAddedFailed());
            return this;

        }

         public object BusinessUserDeactivatedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(_businessUsersResponseMessages.BusinessUserDeactivatedSuccess());
            return this;

        }

        public object BusinessUserDeactivatedFailed()
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_businessUsersResponseMessages.BusinessUserDeactivatedFailed());
            return this;

        }

         public object BusinessUserActivatedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(_businessUsersResponseMessages.BusinessUserActivatedSuccess());
            return this;

        }

        public object BusinessUserActivatedFailed()
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_businessUsersResponseMessages.BusinessUserActivatedFailed());
            return this;

        }

        


    }
}