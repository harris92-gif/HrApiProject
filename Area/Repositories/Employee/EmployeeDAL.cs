using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Employee;
using HrApiProject.Area.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace HrApiProject.Area.Repositories.Employee
{
    public class EmployeeDAL
    {
        private ProjectContextDB _projectContextDB;
        private readonly ICommonLogic _commonLogic;

        public EmployeeDAL(ProjectContextDB projectContextDB, ICommonLogic commonLogic)
        {
            _projectContextDB = projectContextDB;
            _commonLogic=commonLogic;
        }

        public async Task<bool> AddEmployeeWithDetails(Guid BusinessID , EmployeeModel employeeModel) 
        {
            var businessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var empName = new Npgsql.NpgsqlParameter("@theempfullname",employeeModel.EmployeeName);
            var empGender = new Npgsql.NpgsqlParameter("@theempgender",employeeModel.EmployeeGender);
            var empSSN = new Npgsql.NpgsqlParameter("@theempssn",employeeModel.EmployeeSSN);
            var empDepartmentID = new Npgsql.NpgsqlParameter("@thedeptid",employeeModel.DepartmentID);
            var empDetails = new Npgsql.NpgsqlParameter("@theempdetails",NpgsqlDbType.Json)
            {
                Direction = ParameterDirection.InputOutput,
                Value  = employeeModel.EmployeeDetails != null ? employeeModel.EmployeeDetails : (object) DBNull.Value
            };

            EmployeeModel employeeModel1 = await Task.Run(()=>_projectContextDB.EmployeeModel.FromSqlRaw("select * from addemployee(@thebusinessid,@theempfullname,"+
            "@theempgender,@theempssn,@thedeptid,@theempdetails) as emp_id",businessID,empName,empGender,empSSN,empDepartmentID,empDetails)
            .Select(e => new EmployeeModel()
            {
                EmployeeID = e.EmployeeID
            }).FirstOrDefault());

            if(employeeModel1.EmployeeID!= new Guid())
            {
                return true;
            }

            return false;
          
        }

         public async Task<bool> UpdateEmployeeWithDetailsById(Guid BusinessID ,Guid employeeId, UpdateEmployeeModel updateEmployeeModel) 
            {
            var businessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var employeeID = new Npgsql.NpgsqlParameter("@theempid",employeeId);
            var empName = new Npgsql.NpgsqlParameter("@theempfullname",updateEmployeeModel.EmployeeName);
            var empGender = new Npgsql.NpgsqlParameter("@theempgender",updateEmployeeModel.EmployeeGender);
            var empSSN = new Npgsql.NpgsqlParameter("@theempssn",updateEmployeeModel.EmployeeSSN);
            var empDepartmentID = new Npgsql.NpgsqlParameter("@thedeptid",updateEmployeeModel.DepartmentID);

            var empBps = new Npgsql.NpgsqlParameter("@bps",updateEmployeeModel.BPS);
            var empDesignation = new Npgsql.NpgsqlParameter("@theempdesignation",updateEmployeeModel.EmpDesignation);
            var empPaCountry = new Npgsql.NpgsqlParameter("@theemppacountry",updateEmployeeModel.PACountry);
            var empPaCity = new Npgsql.NpgsqlParameter("@theemppacity",updateEmployeeModel.PACity);
            var empPaProvince = new Npgsql.NpgsqlParameter("@theemppaprovince",updateEmployeeModel.PAProvince);
            var empPaZip = new Npgsql.NpgsqlParameter("@theemppazip",updateEmployeeModel.PAZip);
            var empMaCountry = new Npgsql.NpgsqlParameter("@theempmacountry",updateEmployeeModel.MACountry);
            var empMaCity = new Npgsql.NpgsqlParameter("@theempmacity",updateEmployeeModel.MACity);
            var empMaProvince = new Npgsql.NpgsqlParameter("@theempmaprovince",updateEmployeeModel.MAProvince);
            var empMaZip = new Npgsql.NpgsqlParameter("@theempmazip",updateEmployeeModel.MAZip);
            var empEmail = new Npgsql.NpgsqlParameter("@theempemail",updateEmployeeModel.EmpEmail);

            var empJoiningDate = new Npgsql.NpgsqlParameter("@theempjoiningdate",NpgsqlDbType.Date)
            {
                Direction = ParameterDirection.InputOutput,
                Value = !string.IsNullOrEmpty(updateEmployeeModel.EmpJoiningDate) ? Convert.ToDateTime(updateEmployeeModel.EmpJoiningDate) : (object)DBNull.Value
            };

            var empAppDate = new Npgsql.NpgsqlParameter("@theempappointmentdate",NpgsqlDbType.Date)
            {
                Direction = ParameterDirection.InputOutput,
                Value = !string.IsNullOrEmpty(updateEmployeeModel.EmpAppointmentDate) ? Convert.ToDateTime(updateEmployeeModel.EmpAppointmentDate) : (object)DBNull.Value
            };

            var empDesc = new Npgsql.NpgsqlParameter("@thedescription",updateEmployeeModel.Description);
            var empPhoto = new Npgsql.NpgsqlParameter("@thephoto",updateEmployeeModel.Photo);
            var empSkype = new Npgsql.NpgsqlParameter("@theskypeusername",updateEmployeeModel.SkypeUserName);
            var empOfficePhoneNo = new Npgsql.NpgsqlParameter("@theempofficephoneno",updateEmployeeModel.EmpOfficeNo);
            var empCellNo = new Npgsql.NpgsqlParameter("@theempcellno",updateEmployeeModel.EmpCellNo);

           

            UpdateEmployeeModel updateEmployeeModel1 = await Task.Run(()=>_projectContextDB.UpdateEmployeeModel.FromSqlRaw("select * from updateemployee(@thebusinessid,@theempid,@theempfullname,"+
            "@theempgender,@theempssn,@thedeptid,@bps,@theempdesignation,@theemppacountry,@theemppacity,@theemppaprovince,@theemppazip,"+
                "@theempmacountry,@theempmacity,@theempmaprovince,@theempmazip,@theempemail,@theempjoiningdate,@theempappointmentdate, " +
                "@thedescription,@thePhoto,@theskypeusername,@theempofficephoneno,@theempcellno) as emp_id ",businessID,employeeID,empName,empGender,empSSN,empDepartmentID,empBps,empDesignation,
                empPaCountry,empPaCity,empPaProvince, empPaZip,empMaCountry,empMaCity , empMaProvince,empMaZip, empEmail,empJoiningDate,empAppDate,
                empDesc,empPhoto,empSkype,empOfficePhoneNo,empCellNo)
            .Select(e => new UpdateEmployeeModel()
            {
                EmployeeID = e.EmployeeID
            }).FirstOrDefault());

            if(updateEmployeeModel1.EmployeeID!= new Guid())
            {
                return true;
            }

            return false;
          
        }

        public  async Task<bool> DeactivateEmployeeById(Guid BusinessID ,Guid employeeId)
        {
            var businessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var employeeID = new Npgsql.NpgsqlParameter("@theempid",employeeId);

             CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from deactivateemployee(@thebusinessid,@theempid)",businessID,employeeID)
            .Select(e=> new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status;

        }

         public  async Task<bool> ActivateEmployeeById(Guid BusinessID ,Guid employeeId)
        {
            var businessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var employeeID = new Npgsql.NpgsqlParameter("@theempid",employeeId);

             CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from activateemployeebyid(@thebusinessid,@theempid)",businessID,employeeID)
            .Select(e=> new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status;

        }

         public async Task<object> ShowAllEmployeesWithDetails(Guid businessID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

            List<EmployeeResponse> employeeResponse = await Task.Run(()=>_projectContextDB.EmployeeResponse
            .FromSqlRaw("select* from showallemployeewithdetails(@thebusinessid)",businessId)
            .Select(e=>new EmployeeResponse()
            {

                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                EmployeeGender=e.EmployeeGender,
                EmployeeSSN=e.EmployeeSSN,
                DepartmentID=e.DepartmentID,
                EmployeeCreationDate = e.EmployeeCreationDate,
                EmployeeStatus = e.EmployeeStatus,
                EmployeeDetailsId =e.EmployeeDetailsId,
                BPS=e.BPS,
                EmpDesignation=e.EmpDesignation,
                PACountry = e.PACountry,
                PACity = e.PACity,
                PAProvince = e.PAProvince,
                PAZip = e.PAZip,
                MACountry = e.MACountry,
                MACity=e.MACity,
                MAProvince=e.MAProvince,
                MAZip=e.MAZip,
                EmpEmail=e.EmpEmail,
                EmpJoiningDate=Convert.ToString(e.EmpJoiningDate),
                EmpAppointmentDate=Convert.ToString(e.EmpAppointmentDate),
                Description =e.Description,
                Photo=e.Photo,
                SkypeUserName=e.SkypeUserName,
                EmpOfficeNo = e.EmpOfficeNo,
                EmpCellNo = e.EmpCellNo



            }).ToList());

            if(employeeResponse.Count()>0)
            {
                var Response = new{Success ="OK",employeeResponse=employeeResponse};
                return Response;
            }
            return null;
        }

        public async Task<object> ShowEmployeesWithDetailsByID(Guid businessID,Guid employeeID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeId = new Npgsql.NpgsqlParameter("@theempid",employeeID);


            List<EmployeeResponse> employeeResponse = await Task.Run(()=>_projectContextDB.EmployeeResponse
            .FromSqlRaw("select* from showemployeewithdetailsbyid(@thebusinessid,@theempid)",businessId,employeeId)
            .Select(e=>new EmployeeResponse()
            {

                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                EmployeeGender=e.EmployeeGender,
                EmployeeSSN=e.EmployeeSSN,
                DepartmentID=e.DepartmentID,
                EmployeeCreationDate = e.EmployeeCreationDate,
                EmployeeStatus = e.EmployeeStatus,
                EmployeeDetailsId =e.EmployeeDetailsId,
                BPS=e.BPS,
                EmpDesignation=e.EmpDesignation,
                PACountry = e.PACountry,
                PACity = e.PACity,
                PAProvince = e.PAProvince,
                PAZip = e.PAZip,
                MACountry = e.MACountry,
                MACity=e.MACity,
                MAProvince=e.MAProvince,
                MAZip=e.MAZip,
                EmpEmail=e.EmpEmail,
                EmpJoiningDate=Convert.ToString(e.EmpJoiningDate),
                EmpAppointmentDate=Convert.ToString(e.EmpAppointmentDate),
                Description =e.Description,
                Photo=e.Photo,
                SkypeUserName=e.SkypeUserName,
                EmpOfficeNo = e.EmpOfficeNo,
                EmpCellNo = e.EmpCellNo



            }).ToList());

            if(employeeResponse.Count()>0)
            {
                return employeeResponse;
            }
            return null;
             
        }

        public async Task<object> ExportAllEmployees(Guid businessID,string fileType)
        {
            try 
            {
            
                string downlaodUrl = null;
                string folder = FoldersNames.ExportedData;

                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

                var listOfEmployeesDataToBeExport = await Task.Run(()=>_projectContextDB.ExportEmployeeModels.
                FromSqlRaw("select * from exportallemployees(@thebusinessid)",businessId)
                .Select(e=> new ExportEmployeeModel()
                {
                    EmployeeName = e.EmployeeName,
                    EmployeeGender =e.EmployeeGender,
                    EmployeeSSN =e.EmployeeSSN,
                    DepartmentName=e.DepartmentName,select * from  "ba9664be-b8a3-4b30-9f98-6c7f3fe87e48".tblemployeedetails t2 

                    CreationDate= Convert.ToString(e.CreationDate),
                    Status= e.Status,
                    BPS=e.BPS,
                    EmpDesignation = e.EmpDesignation,
                    PACountry=e.PACountry,
                    PACity = e.PACity,
                    PAProvince = e.PAProvince,
                    PAZip = e.PAZip,
                    MACountry = e.MACountry,
                    MACity = e.MACity,
                    MAProvince = e.MAProvince,
                    MAZip = e.MAZip,
                    EmpEmail = e.EmpEmail,
                    EmpJoiningDate=Convert.ToString(e.EmpJoiningDate),
                    EmpAppointmentDate=Convert.ToString(e.EmpAppointmentDate),
                    Description =e.Description,
                    Photo = e.Photo,
                    SkypeUserName= e.SkypeUserName,
                    EmpOfficeNo= e.EmpOfficeNo,
                    EmpCellNo = e.EmpCellNo
                    
                }).ToList());


                if(fileType.ToLower()=="excel")
                {
                    downlaodUrl = _commonLogic.ExportToExcel(listOfEmployeesDataToBeExport,folder);
                }
                
                var exportedData = new {Success = "OK" , Data = downlaodUrl};

                return exportedData;
            }    
            catch(Exception e)
            {
                return null;
            }

        }



    }
}