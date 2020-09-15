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
            var checkBusinessID = await _commonlogic.CheckBusinessID(businessID);  //check that this business is available
            if(checkBusinessID)
            {
               
                var checkEmployeeID= await _commonlogic.CheckEmployeeID(businessID,salaryModel.EmployeeID); //check that this employee id is available in above business
                if(checkEmployeeID)
                {
                   var checkIfSalaryIsAlreadyAssigned = await _salaryLogic.CheckIfEmployeeHasAlreaySaleryAssigned(businessID,salaryModel.EmployeeID); //checking if salery is already assigned to this employee
                    if(checkIfSalaryIsAlreadyAssigned)
                    {
                        return _salaryValidation.SalaryAlreadyAssigned(salaryModel.EmployeeID); 
                    }

                    //insertion starts here
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

        [HttpPut("UpdateEmployeeSalaryBySalaryID")]
        public async Task<Object> UpdateEmployeeSalaryBySalaryID(Guid businessID ,Guid salaryID,[FromForm] UpdateSalaryModel updateSalaryModel)
        {
            var checkBusinessID = await _commonlogic.CheckBusinessID(businessID);  //check that this business is available
            if(checkBusinessID)
            {
               
                var checkSalaryID= await _commonlogic.CheckSalaryID(businessID,salaryID); //check that this salary id is available in above business
                if(checkSalaryID)
                {
                    //updation starts here
                    var errors = _salaryValidation.ValidateUpdateSalaryData(updateSalaryModel);
                    if(errors!=null)
                    {
                        return errors;    
                    }

                    bool response = await _salaryLogic.UpdateEmployeeSalaryBySalaryID(businessID ,salaryID, updateSalaryModel);
                    if(response)
                    {
                        return _salaryValidation.SalaryUpdatedSuccess();
                    }

                    return _salaryValidation.SalaryUpdatedFailed();

                }

                return _commonValidation.SalaryIdNotExists(salaryID);
            }

            return _commonValidation.BusinessIdNotExists(businessID);           
           
        }

        [HttpGet("ShowEmployeeSalariesByEmployeeIds")]
        public async Task<Object> ShowEmployeeSalariesByEmployeeIds(Guid businessID ,[FromForm] Guid[] employeeIDs)
        {
            var checkBusinessID = await _commonlogic.CheckBusinessID(businessID);  //check that this business is available
            if(checkBusinessID)
            {                    

                    var response = await _salaryLogic.ShowEmployeeSalariesByEmployeeIds(businessID ,employeeIDs);
                    if(response!=null)
                    {
                        return response;
                    }

                    return _commonValidation.NoRecordFound();

               
            }

            return _commonValidation.BusinessIdNotExists(businessID);           
           
        }

        [HttpGet("ShowAllEmployeeNameAndSalaries")]
        public async Task<Object> ShowAllEmployeeNameAndSalaries(Guid businessID)
        {
            var checkBusinessID = await _commonlogic.CheckBusinessID(businessID);  //check that this business is available
            if(checkBusinessID)
            {                    

                    var response = await _salaryLogic.ShowAllEmployeeNameAndSalaries(businessID);
                    if(response!=null)
                    {
                        return response;
                    }

                    return _commonValidation.NoRecordFound();

               
            }

            return _commonValidation.BusinessIdNotExists(businessID);           
           
        }

    }
}