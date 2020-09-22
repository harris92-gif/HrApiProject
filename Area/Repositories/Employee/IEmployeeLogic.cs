using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Employee;

namespace HrApiProject.Area.Repositories.Employee
{
    public interface IEmployeeLogic
    {
        Task<bool> AddEmployeeWithDetails(Guid BusinessID , EmployeeModel employeeModel); 
        Task<bool> UpdateEmployeeWithDetailsById(Guid BusinessID ,Guid employeeId, UpdateEmployeeModel updateEmployeeModel);
        Task<bool> DeactivateEmployeeById(Guid BusinessID ,Guid employeeId);   
        Task<bool> ActivateEmployeeById(Guid BusinessID ,Guid employeeId);  
        Task<object> ShowAllEmployeesWithDetails(Guid businessID);  
        Task<object> ShowEmployeesWithDetailsByID(Guid businessID,Guid employeeID); 

        Task<object> ExportAllEmployees(Guid businessID,string fileType);




        
    }
}