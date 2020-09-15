using System;
using System.Threading.Tasks;

namespace HrApiProject.Area.Repositories.Common
{
    public interface ICommonLogic
    {
        Task<bool> CheckBusinessID(Guid businessID);
        Task<bool> CheckEmployeeID(Guid businessID,Guid employeeID);
        Task<bool> CheckSalaryID(Guid businessID,Guid salaryID);

        Task<bool> CheckUserID(Guid userID);




    }
}