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

         public async Task<bool> CheckUserID(Guid userID)
        {
            var userId = new Npgsql.NpgsqlParameter("@theuserid",userID);
            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkuserid(@theuserid) as status",userId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status  
            }).FirstOrDefault());

           return checkStatusModel.Status; 

        }

         public async Task<bool> CheckBusinessUserID(Guid businessID,Guid businessUserID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var businessUserId = new Npgsql.NpgsqlParameter("@thebusinessuserid",businessUserID);

            
            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkbusinessuserid(@thebusinessid,@thebusinessuserid) as status",businessId,businessUserId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

           return checkStatusModel.Status; 

        }

         public async Task<bool> CheckDeductionID(Guid businessID,Guid deductionID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var deductionId = new Npgsql.NpgsqlParameter("@thedeductionid",deductionID);

            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkdeductionid(@thebusinessid,@thedeductionid)",businessId,deductionId)
            .Select(e => new CheckStatusModel()
            {
                DeductionIDStatus = e.DeductionIDStatus
            }).FirstOrDefault()); 

           return checkStatusModel.DeductionIDStatus; 

        }

         public async Task<bool> CheckIncrementID(Guid businessID,Guid incrementID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var incrementId = new Npgsql.NpgsqlParameter("@theincrementid",incrementID);

            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkincrementid(@thebusinessid,@theincrementid) ",businessId,incrementId)
            .Select(e => new CheckStatusModel()
            {
                IncrementIDStatus = e.IncrementIDStatus
            }).FirstOrDefault()); 

           return checkStatusModel.IncrementIDStatus; 

        }


         public async Task<bool> CheckAttendaceID(Guid businessID,Guid attendanceID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var attendanceId = new Npgsql.NpgsqlParameter("@theattendanceid",attendanceID);

            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkattendanceid(@thebusinessid,@theattendanceid) as checkattendanceid",businessId,attendanceId)
            .Select(e => new CheckStatusModel()
            {
                AttendanceIDStatus = e.AttendanceIDStatus
            }).FirstOrDefault()); 

           return checkStatusModel.AttendanceIDStatus; 

        }

       

        





    }
}