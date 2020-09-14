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
    }
}