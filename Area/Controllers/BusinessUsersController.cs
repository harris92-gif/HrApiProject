using System;
using System.Threading.Tasks;
using HrApiProject.Area.Repositories.BusinessUsers;
using HrApiProject.Area.Repositories.Common;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessUsersController
    {
        private readonly IBusinessUsersLogic _businessUsersLogic;
        private readonly BusinessUsersValidation _businessUsersValidation;
        private readonly ICommonLogic _commonLogic;
        private readonly CommonValidation _commonValidation;

        public BusinessUsersController(IBusinessUsersLogic businessUsersLogic,BusinessUsersValidation businessUsersValidation,ICommonLogic commonLogic,CommonValidation commonValidation)
        {
            _businessUsersLogic = businessUsersLogic;   
            _businessUsersValidation= businessUsersValidation ;
            _commonLogic = commonLogic;
            _commonValidation=commonValidation;
        }

        [HttpPost("AddBusinessUser")]
        public async Task<object> AddBusinessUser(Guid businessID ,Guid userID) 
        {
            var checkBusinessId =   await _commonLogic.CheckBusinessID(businessID); 
            if(checkBusinessId)
            {
                bool checkUserId = await _commonLogic.CheckUserID(userID);
                if(checkUserId)
                {
                    var response = await _businessUsersLogic.AddBusinessUser(businessID,userID);
                    if(response)
                    {
                        return _businessUsersValidation.BusinessUserAddedSuccess();
                    }
                     return _businessUsersValidation.BusinessUserAddedFailed();
                    
                }
                return   _commonValidation.UserIdNotExists(userID);  

            }   
            return   _commonValidation.BusinessIdNotExists(businessID);    
        }


        
    }
}