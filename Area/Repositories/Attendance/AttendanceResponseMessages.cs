namespace HrApiProject.Area.Repositories.Attendance
{
    public class ResponseCodesAndMessages
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage {get; set;}
    }
    public class AttendanceResponseMessages
    {
        
        public object AttendanceAddedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1001;
            rcam.ResponseMessage = "Attendance added successfully";
            return rcam;
        }

        public object AttendanceUpdatedSuccess()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 1002;
            rcam.ResponseMessage = "Attendance Updated successfully";
            return rcam;
        }



        public object AttendanceAdditionFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2001;
            rcam.ResponseMessage = "Attendance addition Failed";
            return rcam;
        }

        public object AttendanceUpdationFailed()
        {
            ResponseCodesAndMessages rcam = new ResponseCodesAndMessages();
            rcam.ResponseCode = 2002;
            rcam.ResponseMessage = "Attendance Updation Failed";
            return rcam;
        }
    }
}