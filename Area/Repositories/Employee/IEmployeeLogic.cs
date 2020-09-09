using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Employee;

namespace HrApiProject.Area.Repositories.Employee
{
    public interface IEmployeeLogic
    {
        Task<bool> AddEmployeeWithDetails(Guid BusinessID , EmployeeModel employeeModel); 
        
    }
}