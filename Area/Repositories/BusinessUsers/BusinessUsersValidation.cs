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

        


    }
}