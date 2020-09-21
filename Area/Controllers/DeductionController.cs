using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Deductions;
using HrApiProject.Area.Repositories.Common;
using HrApiProject.Area.Repositories.Deductions;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeductionController
    {
        private readonly IDeductionLogic _deductionLogic;
        private readonly DeductionValidation _deductionValidation;
        private readonly ICommonLogic _commonLogic;
        private readonly CommonValidation _commonValidation;

        public DeductionController(IDeductionLogic deductionLogic,DeductionValidation deductionValidation,ICommonLogic commonLogic,CommonValidation commonValidation)
        {
            _deductionLogic=deductionLogic;
            _deductionValidation=deductionValidation;
            _commonLogic = commonLogic;
            _commonValidation = commonValidation;

        }

        [HttpPost("AddDeduction")]
        public async Task<object> AddDeduction(Guid businessID ,[FromBody] DeductionModel deductionModel)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                var errors = _deductionValidation.ValidateDeductionData(deductionModel);
                if(errors!=null)
                {
                    return errors;
                }
                                
                var response = await _deductionLogic.AddDeduction(businessID,deductionModel);
             
                if(response ==null)
                {
                    return _deductionValidation.DeductionAddedSuccess();          
                }
               

                return _commonValidation.TheseEmployeesIdsNotFound(response);

            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }

        [HttpGet("ShowAllDeduction")]
        public  async Task<object> ShowAllDeduction(Guid businessID)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {                              
                var response = await _deductionLogic.ShowAllDeduction(businessID);
                if(response!=null)
                {
                    return response;
                }
                return _commonValidation.NoRecordFound();
            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }

        [HttpGet("ShowDeductionById")]
        public  async Task<object> ShowDeductionById(Guid businessID,Guid deductionID)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {                              
                var response = await _deductionLogic.ShowDeductionById(businessID,deductionID);
                if(response!=null)
                {
                    return response;
                }
                return _commonValidation.NoRecordFound();
            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }

        [HttpPut("UpdateDeductionByID")]
        public async Task<object> UpdateDeductionByID(Guid businessID, Guid deductionID,[FromBody] UpdateDeductionModel updateDeductionModel)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                 var checkDeductionId = await _commonLogic.CheckDeductionID(businessID,deductionID);
                 if(checkDeductionId)
                 {
                    var errors = _deductionValidation.ValidateUpdateDeductionData(updateDeductionModel);
                    if(errors!=null)
                    {
                        return errors;
                    }
                    _deductionLogic.UpdateDeductionByID(businessID,deductionID,updateDeductionModel);

                    return _deductionValidation.DeductionUpdatedSuccess();
                 }
                 return _commonValidation.DeductionIdNotExists(deductionID);

            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }


        [HttpGet("ShowDeductionsByEmployeeId")]
        public async Task<object> ShowDeductionsByEmployeeId(Guid businessID, Guid employeeID)
        {
             var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                var response = await _deductionLogic.ShowDeductionsByEmployeeId(businessID , employeeID);
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