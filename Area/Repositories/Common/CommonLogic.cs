using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace HrApiProject.Area.Repositories.Common
{
    public class CommonLogic : ICommonLogic
    {
        private readonly CommonDAL _commonDAL;
        private readonly HttpContext _httpContextAccessor;

        public CommonLogic(CommonDAL commonDAL, IHttpContextAccessor httpContextAccessor)
        {
            _commonDAL = commonDAL;
            _httpContextAccessor= httpContextAccessor.HttpContext;
        }

        public Task<bool> CheckBusinessID(Guid businessID)
        {
            return _commonDAL.CheckBusinessID(businessID);
        }

        

        public Task<bool> CheckEmployeeID(Guid businessID, Guid employeeID)
        {
            return _commonDAL.CheckEmployeeID(businessID,employeeID);
        }

        public Task<bool> CheckSalaryID(Guid businessID, Guid salaryID)
        {
            return _commonDAL.CheckSalaryID(businessID , salaryID);
        }

        public Task<bool> CheckUserID(Guid userID)
        {
            return _commonDAL.CheckUserID(userID);
        }

        public Task<bool> CheckBusinessUserID(Guid businessID, Guid businessUserID)
        {
            return _commonDAL.CheckBusinessUserID(businessID,businessUserID);
        }

        public Task<bool> CheckDeductionID(Guid businessID, Guid deductionID)
        {
            return _commonDAL.CheckDeductionID(businessID , deductionID);
        }

        public Task<bool> CheckIncrementID(Guid businessID, Guid incrementID)
        {
            return _commonDAL.CheckIncrementID(businessID,incrementID);
        }


         public string ExportToExcel(dynamic data , string folderName)
        {
            string excelFileName =  $"List-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx"; 
            string downloadUrl = string.Format("{0}://{1}/{2}", _httpContextAccessor.Request.Scheme, _httpContextAccessor.Request.Host, folderName + "/" + excelFileName);  

            if(!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            FileInfo file = new FileInfo(Path.Combine(folderName,excelFileName));

            if(file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(folderName,excelFileName));

            }

            using(var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("sheet1");
                workSheet.Cells.LoadFromCollection(data,true);
                package.Save();
            }

            return downloadUrl;

            
        }



    }
}