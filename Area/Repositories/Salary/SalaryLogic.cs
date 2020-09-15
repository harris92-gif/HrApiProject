using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Salary;

namespace HrApiProject.Area.Repositories.Salary
{
    public class SalaryLogic : ISalaryLogic
    {
        private  readonly SalaryDAL _salaryDAL;

        public SalaryLogic(SalaryDAL salaryDAL)
        {
            _salaryDAL= salaryDAL;
        }

        public Task<bool> AddEmployeeSalary(Guid businessID, SalaryModel salaryModel)
        {
            return _salaryDAL.AddEmployeeSalary(businessID , salaryModel);
        }

        public Task<bool> CheckIfEmployeeHasAlreaySaleryAssigned(Guid businessID, Guid employeeID)
        {
            return _salaryDAL.CheckIfEmployeeHasAlreaySaleryAssigned(businessID,employeeID);
        }

    

        public Task<bool> UpdateEmployeeSalaryBySalaryID(Guid businessID, Guid SalaryID, UpdateSalaryModel updateSalaryModel)
        {
            return _salaryDAL.UpdateEmployeeSalaryBySalaryID(businessID , SalaryID , updateSalaryModel);   
        }

            public Task<object> ShowEmployeeSalariesByEmployeeIds(Guid businessID, Guid[] employeeIDs)
        {
            return _salaryDAL.ShowEmployeeSalariesByEmployeeIds(businessID,employeeIDs);
        }

        public Task<object> ShowAllEmployeeNameAndSalaries(Guid businessID)
        {
            return _salaryDAL.ShowAllEmployeeNameAndSalaries(businessID);
        }
    }
}