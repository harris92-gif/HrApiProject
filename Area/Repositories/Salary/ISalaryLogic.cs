using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Salary;

namespace HrApiProject.Area.Repositories.Salary
{
    public interface ISalaryLogic
    {
        Task<bool> AddEmployeeSalary(Guid businessID , SalaryModel salaryModel);  
        Task<bool> CheckIfEmployeeHasAlreaySaleryAssigned(Guid businessID,Guid employeeID);
        Task<bool> UpdateEmployeeSalaryBySalaryID(Guid businessID ,Guid SalaryID,UpdateSalaryModel updateSalaryModel);

        Task<object> ShowEmployeeSalariesByEmployeeIds(Guid businessID ,Guid[] employeeIDs);

        Task<object> ShowAllEmployeeNameAndSalaries(Guid businessID);



       
    }
}