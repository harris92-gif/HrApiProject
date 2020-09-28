using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Attendance;

namespace HrApiProject.Area.Repositories.Attendance
{
    public class AttendanceLogic : IAttendanceLogic
    {
        private readonly AttendanceDAL attendanceDAL;

        public AttendanceLogic(AttendanceDAL attendanceDAL)
        {
            this.attendanceDAL = attendanceDAL;
        }

        public Task<bool> AddAttendance(Guid businessID, AttendanceModel attendanceModel)
        {
            
            return attendanceDAL.AddAttendance(businessID,attendanceModel);
        }

        

        public Task<bool> UpdateAttendance(Guid businessID, Guid attendanceID, UpdateAttendanceModel updateAttendanceModel)
        {
           return attendanceDAL.UpdateAttendance(businessID,attendanceID,updateAttendanceModel);
        }

        public Task<object> ShowAttendanceByDate(Guid businessID, string fromDate, string toDate)
        {
             return attendanceDAL.ShowAttendanceByDate(businessID,fromDate,toDate);
        }


    }
}