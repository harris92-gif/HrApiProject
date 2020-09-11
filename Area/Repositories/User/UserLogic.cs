using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.User;

namespace HrApiProject.Area.Repositories.User
{
    public class UserLogic : IUserLogic
    {
        private readonly UserDAL _userDAL;

        public UserLogic(UserDAL userDAL)
        {
            _userDAL=userDAL;
        }
        public Task<bool> AddUser(UserModel userModel)
        {
            return _userDAL.AddUser(userModel);
        }

       
        public Task<bool> UpdateUserById(Guid userID, UserModel userModel)
        {
            return _userDAL.UpdateUserById(userID , userModel);
        }

         public Task<bool> DeactivateUserById(Guid userID)
        {
           return _userDAL.DeactivateUserById(userID);
        }

         public Task<bool> ActivateUserById(Guid userID)
        {
           return _userDAL.ActivateUserById(userID);
        }

        public Task<object> ShowAllUsers()
        {
            return _userDAL.ShowAllUsers();
        }

        public Task<object> ShowUserById(Guid userID)
        {
            return _userDAL.ShowUserById(userID);
        }
    }
}