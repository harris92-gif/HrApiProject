using System;
using System.Threading.Tasks;

namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public class BusinessUsersLogic : IBusinessUsersLogic
    {
        private readonly BusinessUsersDAL _businessUsersDAL;

        public BusinessUsersLogic(BusinessUsersDAL businessUsersDAL)
        {
            _businessUsersDAL = businessUsersDAL;
        }
        public Task<bool> AddBusinessUser(Guid businessID, Guid userID)
        {
            return _businessUsersDAL.AddBusinessUser(businessID,userID);
        }
    }
}