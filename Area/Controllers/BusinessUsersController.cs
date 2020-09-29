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

        [HttpPost("DeactivateBusinessUserById")]
        public async Task<object> DeactivateBusinessUserById(Guid businessID ,Guid businessUserID) 
        {
            var checkBusinessId =   await _commonLogic.CheckBusinessID(businessID); 
            if(checkBusinessId)
            {
                bool checkBusinessUserId = await _commonLogic.CheckBusinessUserID(businessID,businessUserID);
                if(checkBusinessUserId)
                {
                    var response = await _businessUsersLogic.DeactivateBusinessUserById(businessID,businessUserID);
                    if(response) 
                    {
                        return _businessUsersValidation.BusinessUserDeactivatedSuccess();
                    }
                     return _businessUsersValidation.BusinessUserDeactivatedFailed();
                    
                }
                return   _commonValidation.BusinessUserIdNotExists(businessUserID);  

            }   
            return   _commonValidation.BusinessIdNotExists(businessID);    
        }

        [HttpPost("ActivateBusinessUserById")]
        public async Task<object> ActivateBusinessUserById(Guid businessID ,Guid businessUserID) 
        {
            var checkBusinessId =   await _commonLogic.CheckBusinessID(businessID); 
            if(checkBusinessId)
            {
                bool checkBusinessUserId = await _commonLogic.CheckBusinessUserID(businessID,businessUserID);
                if(checkBusinessUserId)
                {
                    var response = await _businessUsersLogic.ActivateBusinessUserById(businessID,businessUserID);
                    if(response) 
                    {
                        return _businessUsersValidation.BusinessUserActivatedSuccess();
                    }
                     return _businessUsersValidation.BusinessUserActivatedFailed();
                    
                }
                return   _commonValidation.BusinessUserIdNotExists(businessUserID);  

            }   
            return   _commonValidation.BusinessIdNotExists(businessID);    
        }



        [HttpGet("ShowAllBusinessUsers")]
         public async Task<object> ShowAllBusinessUsers(Guid businessID)
         {
             var checkBusinessId =   await _commonLogic.CheckBusinessID(businessID); 
            if(checkBusinessId)
            {
                    var response = await _businessUsersLogic.ShowAllBusinessUsers(businessID);
                    if(response!=null)
                    {
                        return response;
                    }
                    return _commonValidation.NoRecordFound();
                    
            }   
            return   _commonValidation.BusinessIdNotExists(businessID);   
         }

         [HttpGet("ShowAllBusinessUsersByBusinessUserId")]
         public async Task<object> ShowAllBusinessUsersByBuId(Guid businessID,Guid businessUserID)
         {
            var checkBusinessId =   await _commonLogic.CheckBusinessID(businessID); 
            if(checkBusinessId)
            {
                bool checkBusinessUserId = await _commonLogic.CheckBusinessUserID(businessID,businessUserID);
                if(checkBusinessUserId)
                {
                    var response = await _businessUsersLogic.ShowBusinessUserByBuId(businessID,businessUserID);
                    if(response!=null)
                    {
                        return response;
                    }
                    return _commonValidation.NoRecordFound();
                    
                }
                return   _commonValidation.BusinessUserIdNotExists(businessUserID);  

            }   
            return   _commonValidation.BusinessIdNotExists(businessID);   

         }

         [HttpGet("ExportAllBusinessUsers")]
         public async Task<object> ExportAllBusinessUsers(Guid businessID,string fileType)
         {
            var checkBusinessId =   await _commonLogic.CheckBusinessID(businessID); 
            if(checkBusinessId)
            {
                return await _businessUsersLogic.ExportAllBusinessUsers(businessID,fileType);

            }   
            return   _commonValidation.BusinessIdNotExists(businessID);   

         }


        
    }
}