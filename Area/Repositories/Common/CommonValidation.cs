using System;
using System.Collections.Generic;

namespace HrApiProject.Area.Repositories.Common
{
    public class CommonValidation
    {
        private readonly CommonResponseMessages _commonResponseMessages;

        public CommonValidation(CommonResponseMessages commonResponseMessages)
        {
            _commonResponseMessages = commonResponseMessages;
            
        }
        
        public string Success {get; set;}
        public List<object> ResponseList {get; set;}

         public object BusinessIdNotExists(Guid businessId)
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.BusinessIdNotExists(businessId));
            return this;

        }

        public object EmployeeIdNotExists(Guid employeeId)
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.EmployeeIdNotExists(employeeId));
            return this;

        }

        
    }
}