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

        
    }
}