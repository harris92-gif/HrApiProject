using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Salary;
using HrApiProject.Area.Repositories.Common;
using HrApiProject.Area.Repositories.Salary;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController
    {
        private readonly ISalaryLogic _salaryLogic;
        private readonly SalaryValidation _salaryValidation;
        private readonly ICommonLogic _commonlogic;
        private readonly CommonValidation _commonValidation;

        public SalaryController(ISalaryLogic salaryLogic,SalaryValidation salaryValidation,ICommonLogic commonlogic,CommonValidation commonValidation)
        {
            _salaryLogic= salaryLogic;   
            _salaryValidation = salaryValidation;
            _commonlogic = commonlogic;
            _commonValidation = commonValidation;

        }

        [HttpPost("AddEmployeeSalary")]
        public async Task<Object> AddEmployeeSalary(Guid businessID ,[FromBody] SalaryModel salaryModel)
        {
            var checkBusinessID = await _commonlogic.CheckBusinessID(businessID);
            if(checkBusinessID)
            {
               
                var checkEmployeeID= await _commonlogic.CheckEmployeeID(businessID,salaryModel.EmployeeID);
                if(checkEmployeeID)
                {
                    var errors = _salaryValidation.ValidateSalaryData(salaryModel);
                    if(errors!=null)
                    {
                        return errors;
                    }
                    bool response = await _salaryLogic.AddEmployeeSalary(businessID , salaryModel);
                    if(response)
                    {
                        return _salaryValidation.SalaryAddedSuccess();
                    }

                    return _salaryValidation.SalaryAddedFailed();
                }
                return _commonValidation.EmployeeIdNotExists(salaryModel.EmployeeID);
            }

            return _commonValidation.BusinessIdNotExists(businessID);


            
           
        }

    }
}