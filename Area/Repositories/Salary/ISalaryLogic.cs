using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Salary;

namespace HrApiProject.Area.Repositories.Salary
{
    public interface ISalaryLogic
    {
        Task<bool> AddEmployeeSalary(Guid businessID , SalaryModel salaryModel);         
    }
}