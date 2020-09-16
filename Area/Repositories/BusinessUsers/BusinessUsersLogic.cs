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

        public Task<bool> DeactivateBusinessUserById(Guid businessID, Guid businesUserID)
        {
            return _businessUsersDAL.DeactivateBusinessUserById(businessID,businesUserID);
        }

         public Task<bool> ActivateBusinessUserById(Guid businessID, Guid businesUserID)
        {
           return _businessUsersDAL.ActivateBusinessUserById(businessID,businesUserID);
        }

        public Task<object> ShowAllBusinessUsers(Guid businessID)
        {
            return _businessUsersDAL.ShowAllBusinessUsers(businessID);
        }

        public Task<object> ShowBusinessUserByBuId(Guid businessID, Guid businesUserID)
        {
            return _businessUsersDAL.ShowBusinessUserByBuId(businessID,businesUserID);
        }
    }
}