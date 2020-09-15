using System;
using System.Threading.Tasks;

namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public interface IBusinessUsersLogic
    {
        Task<bool> AddBusinessUser(Guid businessID ,Guid userID) ;
         
    }
}