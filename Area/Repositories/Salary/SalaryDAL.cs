using System;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Salary;
using Microsoft.EntityFrameworkCore;

namespace HrApiProject.Area.Repositories.Salary
{
    public class SalaryDAL
    {
        private readonly ProjectContextDB _projectContextDB;

        public SalaryDAL(ProjectContextDB projectContextDB)
        {
            _projectContextDB= projectContextDB;   
        }

        public async Task<bool> AddEmployeeSalary(Guid businessID , SalaryModel salaryModel)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeId = new Npgsql.NpgsqlParameter("@theempid",salaryModel.EmployeeID);
            var salary = new Npgsql.NpgsqlParameter("@thesalary",salaryModel.Salary);

             CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from addsalary(@thebusinessid,@theempid,"+
            "@thesalary)",businessId, employeeId,salary)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

           return checkStatusModel.Status;
        }
    }
}