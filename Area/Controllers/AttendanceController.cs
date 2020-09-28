using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Attendance;
using HrApiProject.Area.Repositories.Attendance;
using HrApiProject.Area.Repositories.Common;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController
    {
        private readonly IAttendanceLogic attendanceLogic;
        private readonly ICommonLogic commonLogic;
        private readonly CommonValidation commonValidation;
        private readonly AttendanceValidation attendanceValidation;

        public AttendanceController(IAttendanceLogic attendanceLogic, AttendanceValidation attendanceValidation, ICommonLogic commonLogic, CommonValidation commonValidation)
        {
            this.attendanceValidation = attendanceValidation;
            this.commonValidation = commonValidation;
            this.commonLogic = commonLogic;
            this.attendanceLogic = attendanceLogic;
        }


        [HttpPost("AddAttendance")]
        public async Task<object> AddAttendance(Guid businessID,[FromBody] AttendanceModel attendanceModel)
        {
            var checkBusinessId = await commonLogic.CheckBusinessID(businessID);
            if (checkBusinessId)
            {
                var checkEmployeeId = await commonLogic.CheckEmployeeID(businessID, attendanceModel.EmployeeID);
                if (checkEmployeeId)
                {
                    var result = await attendanceLogic.AddAttendance(businessID, attendanceModel);
                    if (result)
                    {
                        return attendanceValidation.AttendanceAddedSuccess();
                    }

                    return attendanceValidation.AttendanceAdditionFailed();

                }

                return commonValidation.EmployeeIdNotExists(attendanceModel.EmployeeID);
            }
            return commonValidation.BusinessIdNotExists(businessID);
        }

        [HttpPut("UpdateAttendance")]
        public async Task<object> UpdateAttendance(Guid businessID,Guid attendanceID,[FromBody] UpdateAttendanceModel updateAttendanceModel)
        {
            var checkBusinessId = await commonLogic.CheckBusinessID(businessID);
            if (checkBusinessId)
            {
                var checkAttendanceId = await commonLogic.CheckAttendaceID(businessID,attendanceID);
                if(checkAttendanceId)
                {
                    var checkEmployeeId = await commonLogic.CheckEmployeeID(businessID, updateAttendanceModel.EmployeeID);
                    if (checkEmployeeId)
                    {
                        var result = await attendanceLogic.UpdateAttendance(businessID,attendanceID, updateAttendanceModel);
                        if (result)
                        {
                            return attendanceValidation.AttendanceUpdatedSuccess(); 
                        }

                        return attendanceValidation.AttendanceUpdationFailed();

                    }

                    return commonValidation.EmployeeIdNotExists(updateAttendanceModel.EmployeeID);

                }

                return commonValidation.AttendanceIdNotExists(attendanceID);

                
            }
            return commonValidation.BusinessIdNotExists(businessID);
        }


        [HttpGet("ShowAttendanceByDate")]
        public async Task<object> ShowAttendanceByDateAddAttendance(Guid businessID,string fromDate,string toDate)
        {
            var checkBusinessId = await commonLogic.CheckBusinessID(businessID);
            if (checkBusinessId)
            {
                
                    var result = await attendanceLogic.ShowAttendanceByDate(businessID, fromDate,toDate);
                    if (result!=null)
                    {
                        return result;
                    }
                    return commonValidation.NoRecordFound();
            }
            return commonValidation.BusinessIdNotExists(businessID);
        }

    }
}