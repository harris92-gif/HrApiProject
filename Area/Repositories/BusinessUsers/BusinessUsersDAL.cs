using System;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using Microsoft.EntityFrameworkCore;

namespace HrApiProject.Area.Repositories.BusinessUsers
{
    public class BusinessUsersDAL
    {
        private  readonly ProjectContextDB _projectContextDB;

        public BusinessUsersDAL(ProjectContextDB projectContextDB)
        {
            _projectContextDB = projectContextDB;
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
    }
}