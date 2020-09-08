using System.Collections.Generic;
using HrApiProject.Area.Models;

namespace HrApiProject.Area.Repositories.Business
{
    public class BusinessValidations
    {
        private readonly BusinessResponseMessages businessResponseMessages;

        public BusinessValidations(BusinessResponseMessages businessResponseMessages)
        {
            this.businessResponseMessages=businessResponseMessages;
        }

        public string Success {get; set;}
        public List<object> ErrorsList {get; set;}

        public object ValidateBusinessData(BusinessModel businessModel)
        {
            return true; 
        }

        public object BusinessAdded()
        {
            ErrorsList = new List<object>();
            Success="OK";
            ErrorsList.Add(businessResponseMessages.BusinessAdded());
            return this;

        }
        public object BusinessInsertionFailed()
        {
            ErrorsList = new List<object>();
            Success="Failed";
            ErrorsList.Add(businessResponseMessages.BusinessInsertionFailed());
            return this;

        }


    }
}