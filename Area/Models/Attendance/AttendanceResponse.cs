using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.Attendance
{
    public class AttendanceResponse
    {
        [Key]
        [Column("attendance_id")]
        public Guid AttendanceID { get; set; }

        [Column("emp_id")]
        public Guid EmployeeID { get; set; }

        [Column("attendance")]
        public bool Attendance { get; set; }

        [Column("attendance_date")]
        public string AttendanceDate { get; set; }


    }
}