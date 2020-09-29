using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.User;

namespace HrApiProject.Area.Repositories.User
{
    public interface IUserLogic
    {
        Task<bool> AddUser( UserModel userModel);
        Task<bool> UpdateUserById(Guid userID,  UserModel userModel) ;
        Task<bool> DeactivateUserById(Guid userID) ;
        Task<bool> ActivateUserById(Guid userID) ;
        Task<object> ShowAllUsers() ;
        Task<object> ShowUserById(Guid userID) ;

        Task<Object> ExportAllUsers(string fileType);







         
    }
}