using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.User;
using HrApiProject.Area.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController
    {
        private readonly IUserLogic _userLogic;
        private readonly UserValidations _userValidations;

        public UserController(IUserLogic userLogic,UserValidations userValidations)
        {
            _userLogic=userLogic;
            _userValidations=userValidations;
        }

      
        [HttpPost("AddUser")]
        public async Task<object> AddUser( [FromBody]UserModel userModel) 
        {
            var errors = _userValidations.ValidateUserData(userModel,"insertion");
            if(errors!=null)
            {
                return errors;
            }
            
            var response = await _userLogic.AddUser(userModel);
            if(response)
            {
                return  _userValidations.UserAddedSuccess();
            }

            return  _userValidations.UserAddedFailed();
        }
        [HttpPut("UpdateUserById")]
        public async Task<object> UpdateUserById(Guid userId, [FromBody]UserModel userModel) 
        {
            var errors = _userValidations.ValidateUserData(userModel,"updation");
            if(errors!=null)
            {
                return errors;
            }
            
            var response = await _userLogic.UpdateUserById(userId,userModel);
            if(response)
            {
                return  _userValidations.UserUpdatedSuccess();
            }

            return  _userValidations.UserIdNotFound(userId);
        }


        [HttpPost("DeactivateUserById")]
        public async Task<object> DeactivateUserById(Guid userId) 
        {
            var response = await _userLogic.DeactivateUserById(userId);
            if(response)
            {
                return    _userValidations.UserDeactivatedSuccess();
            }
            
            return  _userValidations.UserIdNotFound(userId);

            
        }

        [HttpPost("ActivateUserById")]
        public async Task<object> ActivateUserById(Guid userId) 
        {
            var response = await _userLogic.ActivateUserById(userId);
            if(response)
            {
                return    _userValidations.UserActivatedSuccess();
            }
            
            return  _userValidations.UserIdNotFound(userId);

            
        }

        [HttpGet("ShowAllUsers")]
        public async Task<object> ShowAllUsers() 
        {
            var response = await _userLogic.ShowAllUsers();
            if(response!=null)
            {
                return   response;
            }
            
            return  _userValidations.NoRecordFound();             
        }

        [HttpGet("ShowUserById")]
        public async Task<object> ShowUserById(Guid userID) 
        {
            var response = await _userLogic.ShowUserById(userID);
            if(response!=null)
            {
                return   response;
            }
            
           return  _userValidations.UserIdNotFound(userID);
            
        }


    }
}