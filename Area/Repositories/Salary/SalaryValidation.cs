using System.Collections.Generic;
using HrApiProject.Area.Models.Salary;

namespace HrApiProject.Area.Repositories.Salary
{
    public class SalaryValidation
    {
        private SalaryResponseMessages _salaryResponseMessages;

        public SalaryValidation(SalaryResponseMessages salaryResponseMessages)
        {
            _salaryResponseMessages=salaryResponseMessages;
        }
        public string Success {get; set;}
        public List<object> ResponseList {get; set;}

        public object ValidateSalaryData(SalaryModel salaryModel)
        {
            ResponseList = new List<object>();
            if(salaryModel.Salary<=0)
            {
                Success = "Failed";
                ResponseList.Add(_salaryResponseMessages.InValidSalary());
            }

            if(Success!=null)
            {
                return this;
            }
            return null;
        }

        public object SalaryAddedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(_salaryResponseMessages.SalaryAddedSuccess());
            return this;

        }
        public object SalaryAddedFailed()
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(_salaryResponseMessages.SalaryAddedSuccess());
            return this;

        }
        
    }
}