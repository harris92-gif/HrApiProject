using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.Increments;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NpgsqlTypes;

namespace HrApiProject.Area.Repositories.Increments 
{
    public class IncrementsDAL
    {
        private readonly ProjectContextDB _projectContextDB;

        public IncrementsDAL(ProjectContextDB projectContextDB)
        {
            _projectContextDB = projectContextDB;
        }

        public async Task<Guid[]> AddIncrements (Guid businessID  , IncrementsModel incrementsModel) 
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var incrementsDetails = new Npgsql.NpgsqlParameter("@theincrementsdetails",NpgsqlDbType.Json)
            {
                Direction = ParameterDirection.InputOutput,
                Value = incrementsModel.IncrementsDetails ?? (object)DBNull.Value
            };

            IncrementsAddingButEmployeeIDsNotPresent incrementsAddingButEmployeeIDsNotPresent = await Task.Run(()=>_projectContextDB.IncrementsAddingButEmployeeIDsNotPresent.
            FromSqlRaw("select * from addincrements(@thebusinessid,@theincrementsdetails)",businessId,incrementsDetails)
            .Select(e=> new IncrementsAddingButEmployeeIDsNotPresent()
            {
                NotFoundEmployeesIds = e.NotFoundEmployeesIds
            }).FirstOrDefault());

            if(incrementsAddingButEmployeeIDsNotPresent.NotFoundEmployeesIds.Length == 0)
            {
                return null;
            }
            return incrementsAddingButEmployeeIDsNotPresent.NotFoundEmployeesIds;           

        }


        public async Task UpdateIncrementByID(Guid businessID ,Guid incrementID , IncrementsUpdateModel incrementsUpdateModel)
        {
                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
                var incrementId = new Npgsql.NpgsqlParameter("@theincrementid",incrementID);
                var amount = new Npgsql.NpgsqlParameter("@theamount",incrementsUpdateModel.IncrementAmount);
                var description  = new Npgsql.NpgsqlParameter("@thedescription",incrementsUpdateModel.Description);


                await Task.Run(()=>_projectContextDB.Database.ExecuteSqlRaw("call updateincrementbyid(@thebusinessid,@theincrementid,@theamount,@thedescription)",businessId,incrementId,amount,description));
            
        } 

        public async Task<object> ShowAllIncrements(Guid businessID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

            List<IncrementResponseInJson> incrementResponseInJson = await Task.Run(()=>_projectContextDB.IncrementResponseInJson.
            FromSqlRaw("select * from showallincrements(@thebusinessid)",businessId).
            Select(e=> new IncrementResponseInJson()
            {
                IncrementDetails = e.IncrementDetails
            }).ToList());

            foreach(IncrementResponseInJson ir in incrementResponseInJson)
            {
                if(ir.IncrementDetails!=null)
                {
                    List<IncrementsResponse> incrementsResponse = JsonConvert.DeserializeObject<List<IncrementsResponse>>(incrementResponseInJson.FirstOrDefault().IncrementDetails);

                    var response = new {Success = "OK" , incrementsResponse};
                    return response; 

                }
                
            }
            return null;    
        }


        public async Task<object> ShowIncrementById(Guid businessID,Guid incrementID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var incrementId = new Npgsql.NpgsqlParameter("@theincrementid",incrementID);


            IncrementResponseInJson incrementResponseInJson = await Task.Run(()=>_projectContextDB.IncrementResponseInJson.
            FromSqlRaw("select * from showincrementbyid(@thebusinessid,@theincrementid)",businessId,incrementId).
            Select(e=> new IncrementResponseInJson()
            {
                IncrementDetails = e.IncrementDetails
            }).FirstOrDefault());

           
                if(incrementResponseInJson.IncrementDetails!=null)
                {
                    IncrementsResponse incrementsResponse = JsonConvert.DeserializeObject<IncrementsResponse>(incrementResponseInJson.IncrementDetails);

                    var response = new {Success = "OK" , incrementsResponse};
                    return response; 

                }
                
          
            return null;    
        }

        public async Task<object> ShowIncrementsByemployeeId(Guid businessID,Guid employeeID)
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var employeeId = new Npgsql.NpgsqlParameter("@theemployeeid",employeeID);


            List<IncrementResponseInJson> incrementResponseInJson = await Task.Run(()=>_projectContextDB.IncrementResponseInJson.
            FromSqlRaw("select * from showincrementsbyemployeeid(@thebusinessid,@theemployeeid)",businessId,employeeId).
            Select(e=> new IncrementResponseInJson()
            {
                IncrementDetails = e.IncrementDetails
            }).ToList());

           foreach(IncrementResponseInJson ir in incrementResponseInJson)
           {
               if(ir.IncrementDetails!=null)
               {                 
                    List<IncrementsResponse> incrementsResponse = JsonConvert.DeserializeObject<List<IncrementsResponse>>(incrementResponseInJson.FirstOrDefault().IncrementDetails);
                    var response = new {Success = "OK" , incrementsResponse};
                    return response;                 
               }
           }               
          
            return null;    
        }
    }
}