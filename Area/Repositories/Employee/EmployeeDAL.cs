using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.Employee;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace HrApiProject.Area.Repositories.Employee
{
    public class EmployeeDAL
    {
        private ProjectContextDB _projectContextDB;
        public EmployeeDAL(ProjectContextDB projectContextDB)
        {
            _projectContextDB= projectContextDB;
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


    }
}