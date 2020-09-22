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

        Task<bool> CheckBusinessUserID(Guid businessID,Guid businessUserID);
        Task<bool> CheckDeductionID(Guid businessID,Guid deductionID);

        Task<bool> CheckIncrementID(Guid businessID,Guid incrementID);

        string ExportToExcel(dynamic data , string folderName);
    }
}