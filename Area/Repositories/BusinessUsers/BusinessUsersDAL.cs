using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.BusinessUsers;
using HrApiProject.Area.Models.CommonModels;
using Microsoft.EntityFrameworkCore;
using HrApiProject.Area.Repositories.Common;

namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public class BusinessUsersDAL
    {
        private  readonly ProjectContextDB _projectContextDB;
        private readonly ICommonLogic _commonLogic;

        public BusinessUsersDAL(ProjectContextDB projectContextDB, ICommonLogic commonLogic)
        {
            _projectContextDB = projectContextDB;
            _commonLogic = commonLogic;
        }

         public async Task<bool> AddBusinessUser(Guid businessID ,Guid userID) 
        {
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var userId = new Npgsql.NpgsqlParameter("@theuserid",userID);           
           

            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from addbusinessuser(@thebusinessid,@theuserid) as status",businessId,userId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status; 

        }

        public async Task<bool> DeactivateBusinessUserById(Guid businessID ,Guid businesUserID) 
        {

            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var businesUserId = new Npgsql.NpgsqlParameter("@thebuid",businesUserID);       
           

            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from deactivatebusinessuser(@thebusinessid,@thebuid) as status",businessId,businesUserId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status; 
          
        }

         public async Task<bool> ActivateBusinessUserById(Guid businessID ,Guid businesUserID) 
        {

            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var businesUserId = new Npgsql.NpgsqlParameter("@thebuid",businesUserID);       
           

            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from activatebusinessuser(@thebusinessid,@thebuid) as status",businessId,businesUserId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status;           
        }

        public async Task<object> ShowAllBusinessUsers(Guid businessID) 
        {            
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

            List<AllBusinessUsersResponse> allBusinessUsersResponse = await Task.Run(()=>_projectContextDB.AllBusinessUsersResponse.FromSqlRaw("select * from showallbusinessuser(@thebusinessid) ",businessId)
            .Select(e => new AllBusinessUsersResponse()
            {
               AllBusinessUsersInOneJson = e.AllBusinessUsersInOneJson

            }).ToList());  

             List<BusinessUsersResponse> businessUsersResponses = JsonConvert.DeserializeObject<List<BusinessUsersResponse>>(allBusinessUsersResponse.FirstOrDefault().AllBusinessUsersInOneJson);
            
            if(businessUsersResponses.Count>0)
            {
                var Response = new {Success = "OK" ,businessUsersResponses=businessUsersResponses };
                return Response;
            }
            return null;             
        }

        public async Task<object> ShowBusinessUserByBuId(Guid businessID,Guid businesUserID) 
        {
            
            var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);
            var businesUserId = new Npgsql.NpgsqlParameter("@thebuid",businesUserID);       


            AllBusinessUsersResponse allBusinessUsersResponse = await Task.Run(()=>_projectContextDB.AllBusinessUsersResponse.FromSqlRaw("select * from showbusinessuserbyid(@thebusinessid,@thebuid) ",businessId,businesUserId)
            .Select(e => new AllBusinessUsersResponse()
            {
               AllBusinessUsersInOneJson = e.AllBusinessUsersInOneJson

            }).FirstOrDefault());
        
             BusinessUsersResponse businessUsersResponses = JsonConvert.DeserializeObject<BusinessUsersResponse>(allBusinessUsersResponse.AllBusinessUsersInOneJson);
            
            if(businessUsersResponses!=null)
            {
                var Response = new {Success = "OK", businessUsersResponses};
                return Response;
            }
            return null;            
          
        }


        public async Task<Object> ExportAllBusinessUsers(Guid businessID , string fileType)
        {

            try
            {
                string downloadUrl = null;
                string folder = FoldersNames.ExportedData;

                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

                var listOfBusinessUsersToExport = await Task.Run(()=>_projectContextDB.ExportBusinessUsersModel.
                FromSqlRaw("select * from exportallbusinessusers(@thebusinessid)",businessId)
                .Select(e=>new ExportBusinessUsersModel()
                {
                    BusinessName = e.BusinessName,
                    UserName = e.UserName
                }).ToList());

                if(fileType.ToLower() == "excel")
                {
                    downloadUrl = _commonLogic.ExportToExcel(listOfBusinessUsersToExport,folder);
                }

                //create a datatable of this data
                var listOfBusinessUsersInDataTable = _commonLogic.ToDataTable(listOfBusinessUsersToExport);


                if(fileType.ToLower()=="csv")
                {
                    downloadUrl = _commonLogic.ExportToCsv(listOfBusinessUsersInDataTable,folder);
                }

                if(fileType.ToLower()=="pdf")
                {
                    downloadUrl = _commonLogic.ExportToPdf(listOfBusinessUsersInDataTable,folder);
                }

                var exportedData = new {Success = "OK" , Data = downloadUrl};

                return exportedData;
            }

            catch(Exception e)
            {
                return null;
            }

        }



    }
}