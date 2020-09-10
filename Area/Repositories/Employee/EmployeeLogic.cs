using HrApiProject.Area.Models.Employee;
using System;
using System.Threading.Tasks;

namespace HrApiProject.Area.Repositories.Employee
{

  
    public class EmployeeLogic : IEmployeeLogic
    {
          private readonly EmployeeDAL _employeeDAL;
        public EmployeeLogic(EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        } 
        public  Task<bool> AddEmployeeWithDetails(Guid BusinessID , EmployeeModel employeeModel)
        {
            return _employeeDAL.AddEmployeeWithDetails(BusinessID , employeeModel);
        }
       

        public Task<bool> UpdateEmployeeWithDetailsById(Guid BusinessID, Guid employeeId, UpdateEmployeeModel updateEmployeeModel)
        {
            return _employeeDAL.UpdateEmployeeWithDetailsById(BusinessID,employeeId,updateEmployeeModel);
        }

         public Task<bool> DeactivateEmployeeById(Guid BusinessID, Guid employeeId)
        {
            return _employeeDAL.DeactivateEmployeeById(BusinessID,employeeId);   
        }

        public Task<bool> ActivateEmployeeById(Guid BusinessID, Guid employeeId)
        {
            return _employeeDAL.ActivateEmployeeById(BusinessID,employeeId);
        }

        public Task<object> ShowAllEmployeesWithDetails(Guid businessID)
        {
            return _employeeDAL.ShowAllEmployeesWithDetails(businessID);
        }

        public Task<object> ShowEmployeesWithDetailsByID(Guid businessID, Guid employeeID)
        {
            return _employeeDAL.ShowEmployeesWithDetailsByID(businessID,employeeID);
        }
    }
}