using System.Collections.Generic;

namespace HrApiProject.Area.Repositories.Attendance
{
    public class AttendanceValidation
    {
        private readonly AttendanceResponseMessages attendanceResponseMessages;

        public AttendanceValidation(AttendanceResponseMessages attendanceResponseMessages)
        {
            this.attendanceResponseMessages = attendanceResponseMessages;
        }

        public string Success { get; set; }
        public List<object> ResponseList {get ; set;}


        public object AttendanceAddedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(attendanceResponseMessages.AttendanceAddedSuccess());

            return this;

        }


        public object AttendanceAdditionFailed()
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(attendanceResponseMessages.AttendanceAdditionFailed());

            return this;

        }

        public object AttendanceUpdatedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(attendanceResponseMessages.AttendanceUpdatedSuccess());

            return this;

        }


        public object AttendanceUpdationFailed()
        {
            ResponseList = new List<object>();
            Success = "Failed";
            ResponseList.Add(attendanceResponseMessages.AttendanceUpdationFailed());

            return this;

        }
        
    }
}