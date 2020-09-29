using System;
using System.Threading.Tasks;

namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public interface IBusinessUsersLogic
    {
        Task<bool> AddBusinessUser(Guid businessID ,Guid userID) ;
        Task<bool> DeactivateBusinessUserById(Guid businessID ,Guid businesUserID) ;
        Task<bool> ActivateBusinessUserById(Guid businessID ,Guid businesUserID) ;
        Task<object> ShowAllBusinessUsers(Guid businessID) ;
        Task<object> ShowBusinessUserByBuId(Guid businessID,Guid businesUserID) ;

        Task<Object> ExportAllBusinessUsers(Guid businessID , string fileType);





         
    }
}