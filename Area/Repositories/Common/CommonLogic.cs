using System;
using System.Threading.Tasks;

namespace HrApiProject.Area.Repositories.Common
{
    public class CommonLogic : ICommonLogic
    {
        private readonly CommonDAL _commonDAL;

        public CommonLogic(CommonDAL commonDAL)
        {
            _commonDAL = commonDAL;
        }

        public Task<bool> CheckBusinessID(Guid businessID)
        {
            return _commonDAL.CheckBusinessID(businessID);
        }

        public Task<bool> CheckEmployeeID(Guid businessID, Guid employeeID)
        {
            return _commonDAL.CheckEmployeeID(businessID,employeeID);
        }

        public Task<bool> CheckSalaryID(Guid businessID, Guid salaryID)
        {
            return _commonDAL.CheckSalaryID(businessID , salaryID);
        }
    }
}