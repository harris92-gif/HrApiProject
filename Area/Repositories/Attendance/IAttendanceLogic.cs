using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Attendance;

namespace HrApiProject.Area.Repositories.Attendance
{
    public interface IAttendanceLogic
    {
        Task<bool> AddAttendance(Guid businessID , AttendanceModel attendanceModel);
        Task<bool> UpdateAttendance(Guid businessID ,Guid attendanceID, UpdateAttendanceModel updateAttendanceModel);

        Task<object> ShowAttendanceByDate(Guid businessID,string fromDate,string toDate);



    }
}