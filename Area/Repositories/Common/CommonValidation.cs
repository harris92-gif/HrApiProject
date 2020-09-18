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
        public object SalaryIdNotExists(Guid salaryId)
        {
            ResponseList = new List<object>(); 
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.SalaryIdNotExists(salaryId));
            return this;

        }

        
        public object NoRecordFound()
        {
            ResponseList = new List<object>(); 
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.NoRecordFound());
            return this;

        }

        public object UserIdNotExists(Guid userId)
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.UserIdNotExists(userId));
            return this;

        }

         public object BusinessUserIdNotExists(Guid businessUserId)
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.BusinessUserIdNotExists(businessUserId));
            return this;

        }

        

        public object TheseEmployeesIdsNotFound(Guid[] employeeIds)
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_commonResponseMessages.TheseEmployeesIdsNotFound(employeeIds));
            return this;

        }

        
    }
}