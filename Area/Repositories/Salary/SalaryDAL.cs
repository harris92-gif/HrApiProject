using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Salary;
using Microsoft.EntityFrameworkCore;

namespace HrApiProject.Area.Repositories.Salary
{
    public class SalaryDAL
    {
        private readonly ProjectContextDB _projectContextDB;

        public SalaryDAL(ProjectContextDB projectContextDB)
        {
            _projectContextDB= projectContextDB;   
        }

        public async Task<bool> AddEmployeeSalary(Guid businessID , SalaryModel salaryModel)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeId = new Npgsql.NpgsqlParameter("@theempid",salaryModel.EmployeeID);
            var salary = new Npgsql.NpgsqlParameter("@thesalary",salaryModel.Salary);

             CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from addsalary(@thebusinessid,@theempid,"+
            "@thesalary)",businessId, employeeId,salary)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

           return checkStatusModel.Status;
        }

        public async Task<bool> CheckIfEmployeeHasAlreaySaleryAssigned(Guid businessID,Guid employeeID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeId = new Npgsql.NpgsqlParameter("@theempid",employeeID);

            
              CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from checkemployeeidhavingsaleryassigned(@thebusinessid,@theempid) as checkemployeeid",businessId,employeeId)
            .Select(e => new CheckStatusModel()
            {
                EmployeeIDStatus = e.EmployeeIDStatus
            }).FirstOrDefault());

           return checkStatusModel.EmployeeIDStatus; 

        }


         public async Task<bool> UpdateEmployeeSalaryBySalaryID(Guid businessID ,Guid SalaryID, UpdateSalaryModel updateSalaryModel)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var salaryId = new Npgsql.NpgsqlParameter("@thesalaryid",SalaryID);
            var salary = new Npgsql.NpgsqlParameter("@thesalary",updateSalaryModel.Salary);

             CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from updatesalarybyid(@thebusinessid,@thesalaryid,"+
            "@thesalary) as salaryupdatastatus",businessId, salaryId,salary)
            .Select(e => new CheckStatusModel()
            {
                salaryUpdateStatus = e.salaryUpdateStatus
            }).FirstOrDefault());

           return checkStatusModel.salaryUpdateStatus;
        }

         public async Task<object> ShowEmployeeSalariesByEmployeeIds(Guid businessID ,Guid[] employeeIDs)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeIds = new Npgsql.NpgsqlParameter("@theempid",employeeIDs);
           

             List<SalaryResponse> salaryResponse = await Task.Run(()=>_projectContextDB.salaryResponse.FromSqlRaw("select * from showsalary(@thebusinessid,@theempid)",businessId,employeeIds)
            .Select(e => new SalaryResponse()
            {
                SalaryID = e.SalaryID,
                EmployeeID = e.EmployeeID,
                Salary = e.Salary
            }).ToList());

           if(salaryResponse.Count>0)
           {
               var Response = new {Success = "OK",salaryResponse=salaryResponse};
               return Response;
           }
           return null;
        }

         public async Task<object> ShowAllEmployeeNameAndSalaries(Guid businessID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
           

             List<SalaryWithEmployeeNameResponse> salaryWithEmployeeNameResponses = await Task.Run(()=>_projectContextDB.SalaryWithEmployeeNameResponse.FromSqlRaw("select * from showallemployeesalaries(@thebusinessid)",businessId)
            .Select(e => new SalaryWithEmployeeNameResponse()
            {
                EmployeeName=e.EmployeeName,
                Salary = e.Salary
            }).ToList());

           if(salaryWithEmployeeNameResponses.Count>0)
           {
            //    var Response = new {Success = "OK",salaryWithEmployeeNameResponses=salaryWithEmployeeNameResponses};
            //    return Response;
            return salaryWithEmployeeNameResponses;
           }
           return null;
        }



    }
}