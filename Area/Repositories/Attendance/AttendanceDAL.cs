using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.Attendance;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace HrApiProject.Area.Repositories.Attendance
{
    public class AttendanceDAL
    {
        private readonly ProjectContextDB projectContextDB;

        public AttendanceDAL(ProjectContextDB projectContextDB)
        {
            this.projectContextDB = projectContextDB;
        }

        public async Task<bool> AddAttendance(Guid businessID , AttendanceModel attendanceModel)
        {
            try
            {
                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
                var employeeId = new Npgsql.NpgsqlParameter("@theempid",attendanceModel.EmployeeID);
                var attendance = new Npgsql.NpgsqlParameter("@presentorabsent",attendanceModel.Attendance);

                await Task.Run(()=>projectContextDB.Database.ExecuteSqlRaw("call addattendance(@thebusinessid,@theempid,@presentorabsent)",businessId,employeeId,attendance));

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

        public async Task<bool> UpdateAttendance(Guid businessID ,Guid attendanceID, UpdateAttendanceModel updateAttendanceModel)
        {
            try
            {
                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
                var attendanceId = new Npgsql.NpgsqlParameter("@theattendance_id",attendanceID);
                var employeeId = new Npgsql.NpgsqlParameter("@theempid",updateAttendanceModel.EmployeeID);
                var attendance = new Npgsql.NpgsqlParameter("@presentorabsent",updateAttendanceModel.Attendance);

                await Task.Run(()=>projectContextDB.Database.ExecuteSqlRaw("call updateattendancebyid(@thebusinessid,@theattendance_id,@theempid,@presentorabsent)",businessId,attendanceId,employeeId,attendance));

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

        
         public async Task<object> ShowAttendanceByDate(Guid businessID,string theFromDate,string theToDate)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            
            var fromDate = new Npgsql.NpgsqlParameter("@fromdate",NpgsqlDbType.Date)
            {
                Direction = ParameterDirection.InputOutput,
                Value = !string.IsNullOrEmpty(theFromDate)  ? Convert.ToDateTime(theFromDate)  : (object)DBNull.Value
            };

            var toDate = new Npgsql.NpgsqlParameter("@todate",NpgsqlDbType.Date)
            {
                Direction = ParameterDirection.InputOutput,
                Value = !string.IsNullOrEmpty(theToDate)  ? Convert.ToDateTime(theToDate)  : (object)DBNull.Value
            };

            
           

             List<AttendanceResponse> attendanceResponse = await Task.Run(()=> projectContextDB.AttendanceResponse
             .FromSqlRaw("select * from showattendancebydate(@thebusinessid,@fromdate,@todate)",businessId,fromDate,toDate)
            .Select(e => new AttendanceResponse()
            {
                AttendanceID = e.AttendanceID,
                EmployeeID= e.EmployeeID,
                Attendance = e.Attendance,
                AttendanceDate = Convert.ToString(e.AttendanceDate)
                
               
            }).ToList());

           if(attendanceResponse.Count>0)
           {
                var Response = new {Success = "OK",attendanceResponse=attendanceResponse};
                return Response;
           }

           return null;
        }
        
    }
}