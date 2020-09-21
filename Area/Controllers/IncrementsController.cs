using Microsoft.AspNetCore.Mvc;
using HrApiProject.Area.Repositories.Increments;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Increments;
using System;
using HrApiProject.Area.Repositories.Common;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncrementsController : ControllerBase
    {
        private readonly IIncrementsLogic _incrementsLogic;
        private readonly IncrementsValidation _incrementsValidation;
        private readonly ICommonLogic _commonLogic;
        private readonly CommonValidation _commonValidation;

        public IncrementsController(IIncrementsLogic incrementsLogic ,IncrementsValidation incrementsValidation, ICommonLogic commonLogic, CommonValidation commonValidation)
        {
            _incrementsLogic = incrementsLogic;
            _incrementsValidation= incrementsValidation;
            _commonLogic=commonLogic;
            _commonValidation = commonValidation;
        }

        [HttpPost("AddIncrements")]
        public async Task<object> AddIncrements(Guid businessID,[FromBody] IncrementsModel incrementsModel)
        {
            var checkBusinessId  =  await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                var errors = _incrementsValidation.ValidateIncrementsData(incrementsModel);
                if(errors!=null)
                {
                    return errors;
                }

                var response = await _incrementsLogic.AddIncrements(businessID,incrementsModel);
                if(response == null)
                {
                    return _incrementsValidation.IncrementsAddedSuccess();
                }
                return _commonValidation.TheseEmployeesIdsNotFound(response);
            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }


        [HttpPut("UpdateIncrementByID")]
        public async Task<object> UpdateIncrementByID(Guid businessID ,Guid incrementID , IncrementsUpdateModel incrementsUpdateModel)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                 var checkIncrementId = await _commonLogic.CheckIncrementID(businessID,incrementID);
                 if(checkIncrementId)
                 {
                    var errors = _incrementsValidation.ValidateUpdateIncrementData(incrementsUpdateModel);
                    if(errors!=null)
                    {
                        return errors;
                    }
                    _incrementsLogic.UpdateIncrementByID(businessID,incrementID,incrementsUpdateModel);

                    return _incrementsValidation.IncrementUpdatedSuccess();

                 }
                 return _commonValidation.IncrementIdNotExists(incrementID);

            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }


        [HttpGet("ShowAllIncrements")]
        public async Task<object> ShowAllIncrements(Guid businessID)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                var response = await _incrementsLogic.ShowAllIncrements(businessID);
                if(response!=null)
                {
                    return response;
                }
                return _commonValidation.NoRecordFound();

            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }

        [HttpGet("ShowIncrementById")]
        public async Task<object> ShowIncrementById(Guid businessID,Guid incrementID)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                var checkIncrementId = await _commonLogic.CheckIncrementID(businessID,incrementID);
                if(checkIncrementId)
                {
                    var response = await _incrementsLogic.ShowIncrementById(businessID,incrementID);
                    if(response!=null)
                    {
                        return response;
                    }
                }    
                return _commonValidation.IncrementIdNotExists(incrementID);

            }
            return _commonValidation.BusinessIdNotExists(businessID);
        }

        [HttpGet("ShowIncrementsByEmployeeId")]
        public async Task<object> ShowIncrementsByEmployeeId(Guid businessID,Guid employeeID)
        {
            var checkBusinessId = await _commonLogic.CheckBusinessID(businessID);
            if(checkBusinessId)
            {
                
                    var response = await _incrementsLogic.ShowIncrementsByemployeeId(businessID,employeeID);
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