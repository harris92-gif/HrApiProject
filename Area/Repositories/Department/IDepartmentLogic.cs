using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Department;

namespace HrApiProject.Area.Repositories.Department
{
    public interface IDepartmentLogic
    {
         Task<object> AddNewDepartment(Guid BusinessId , DepartmentModel departmentModel);
        Task<object> ShowAllDepartments(Guid BusinessID);
        Task<object> ShowDepartmentById(Guid BusinessID,Guid DepartmentID);
        
        Task<bool> UpdateDepartmentById(Guid BusinessID,Guid DepartmentID,DepartmentModel departmentModel );
        Task<bool> InActivateDepartmentById(Guid BusinessID,Guid DepartmentID);
        Task<bool> ActivateDepartmentById(Guid BusinessID,Guid DepartmentID);




         
    }
}