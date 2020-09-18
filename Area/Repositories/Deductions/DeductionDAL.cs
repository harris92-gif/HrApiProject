using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Deductions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public async Task<Guid[]> AddDeduction(Guid businessID , DeductionModel deductionModel)
        {
            try
            {
                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
                var deductionDetails = new Npgsql.NpgsqlParameter("@thedeductiondetails",NpgsqlDbType.Json)
                {
                    Direction = ParameterDirection.InputOutput,
                    Value = deductionModel.DeductionDetails!=null ? deductionModel.DeductionDetails : (object)DBNull.Value
                };

                DeductionAddingButEmployeeIDsNotPresent deductionAddingButEmployeeIDsNotPresent = await Task.Run(()=>_projectContextDb.DeductionAddingButEmployeeIDsNotPresent.FromSqlRaw("select * from adddeduction(@thebusinessid,@thedeductiondetails)",businessId,deductionDetails)
                .Select(e=>new DeductionAddingButEmployeeIDsNotPresent()
                {
                    NotFoundEmployeesIds = e.NotFoundEmployeesIds

                }).FirstOrDefault());

                if( deductionAddingButEmployeeIDsNotPresent.NotFoundEmployeesIds.Length ==0)
                {
                    return null;
                }

                return deductionAddingButEmployeeIDsNotPresent.NotFoundEmployeesIds;


                
            }
            catch(Exception ex)
            {
                return null;
            }

            
        }
        
        public async Task<object> ShowAllDeduction(Guid businessID )
        {
              var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

              List<DeductionResponseInJson> deductionResponseInJson = await Task.Run(()=>_projectContextDb.DeductionResponseInJson.FromSqlRaw("select * from showdeduction(@thebusinessid)",businessId)
              .Select(e=> new DeductionResponseInJson()
              {
                  DeductionsDetails = e.DeductionsDetails
              }).ToList());

              foreach(DeductionResponseInJson dd in deductionResponseInJson)
              {
                if(dd.DeductionsDetails!=null)
                {
                        List<DeductionResponse> deductionResponse = JsonConvert.DeserializeObject<List<DeductionResponse>>(deductionResponseInJson.FirstOrDefault().DeductionsDetails);

                        var response = new {Success = "OK" , deductionResponse};
                        return response;
                }     
              }    
                 
        
              return null;
        }

        public async Task<object> ShowDeductionById(Guid businessID ,Guid deductionID)
        {
            try
            {
                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
                var deductionId = new Npgsql.NpgsqlParameter("@thedeductionid",deductionID);


                DeductionResponseInJson deductionResponseInJson = await Task.Run(()=>_projectContextDb.DeductionResponseInJson.FromSqlRaw("select * from showdeductionbyid(@thebusinessid,@thedeductionid)",businessId,deductionId)
                .Select(e=> new DeductionResponseInJson()
                {
                    DeductionsDetails = e.DeductionsDetails
                }).FirstOrDefault());

                
                    if(deductionResponseInJson.DeductionsDetails!=null)
                    {
                            DeductionResponse deductionResponse = JsonConvert.DeserializeObject<DeductionResponse>(deductionResponseInJson.DeductionsDetails);

                            var response = new {Success = "OK" , deductionResponse};
                            return response;
                    }     
                
            
                return null;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

    }
}