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
                                
                var response = await _deductionLogic.AddDeduction(businessID,deductionModel);
                if(response)
                {
                    return _deductionValidation.DeductionAddedSuccess();
                }
                return _deductionValidation.DeductionAdditionFailed();

            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }



    }
}