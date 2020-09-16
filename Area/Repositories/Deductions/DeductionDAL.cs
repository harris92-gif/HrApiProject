using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Deductions;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace HrApiProject.Area.Repositories.Deductions
{
    public class DeductionDAL
    {
        private readonly ProjectContextDB _projectContextDb;

        public DeductionDAL(ProjectContextDB projectContextDb)
        {
            _projectContextDb = projectContextDb;
        }

        public async Task<bool> AddDeduction(Guid businessID , DeductionModel deductionModel)
        {
            try
            {
                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
                var deductionDetails = new Npgsql.NpgsqlParameter("@thedeductiondetails",NpgsqlDbType.Json)
                {
                    Direction = ParameterDirection.InputOutput,
                    Value = deductionModel.DeductionDetails!=null ? deductionModel.DeductionDetails : (object)DBNull.Value
                };

                CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDb.CheckStatusModel.FromSqlRaw("select * from adddeduction(@thebusinessid,@thedeductiondetails)",businessId,deductionDetails)
                .Select(e=>new CheckStatusModel()
                {
                    Status = e.Status

                }).FirstOrDefault());

                return checkStatusModel.Status;
            }
            catch(Exception ex)
            {
                return false;
            }

            
        }

    }
}