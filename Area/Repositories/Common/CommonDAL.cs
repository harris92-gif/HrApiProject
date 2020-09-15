using System;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels; 
using Microsoft.EntityFrameworkCore;

namespace HrApiProject.Area.Repositories.Common
{
    public class CommonDAL
    {
        private readonly ProjectContextDB _projectContextDB;

        public CommonDAL(ProjectContextDB projectContextDB)
        {
            _projectContextDB= projectContextDB;
        }
        public async Task<bool> CheckBusinessID(Guid businessID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkbusinessid(@thebusinessid) as checkbusinessid",businessId)
            .Select(e => new CheckStatusModel()
            {
                BusinessIDStatus = e.BusinessIDStatus  
            }).FirstOrDefault());

           return checkStatusModel.BusinessIDStatus; 

        }

         public async Task<bool> CheckEmployeeID(Guid businessID,Guid employeeID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeId = new Npgsql.NpgsqlParameter("@theempid",employeeID);

            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkemployeeid(@thebusinessid,@theempid) as checkemployeeid",businessId,employeeId)
            .Select(e => new CheckStatusModel()
            {
                EmployeeIDStatus = e.EmployeeIDStatus
            }).FirstOrDefault());

           return checkStatusModel.EmployeeIDStatus; 

        }

         public async Task<bool> CheckSalaryID(Guid businessID,Guid salaryID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var salaryId = new Npgsql.NpgsqlParameter("@thesalaryid",salaryID);

            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checksalaryid(@thebusinessid,@thesalaryid) as checksalaryid",businessId,salaryId)
            .Select(e => new CheckStatusModel()
            {
                SalaryIDStatus = e.SalaryIDStatus
            }).FirstOrDefault());

           return checkStatusModel.SalaryIDStatus; 

        }

        





    }
}