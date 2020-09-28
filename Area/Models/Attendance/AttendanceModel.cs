using System;

namespace HrApiProject.Area.Models.Attendance
{
    public class AttendanceModel
    {
         public Guid AttendanceID { get; set; } 
        public Guid EmployeeID { get; set; }
        public bool Attendance { get; set; }
    }
    public class UpdateAttendanceModel : AttendanceModel
    {
         
    }
}