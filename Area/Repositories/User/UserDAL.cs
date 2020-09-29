using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.User;
using HrApiProject.Area.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace HrApiProject.Area.Repositories.User
{
    public class UserDAL
    {
        private readonly ProjectContextDB _projectContextDB;
        private readonly ICommonLogic _commonLogic;

        public UserDAL(ProjectContextDB projectContextDB, ICommonLogic commonLogic)
        {
            _projectContextDB=projectContextDB;     
            _commonLogic = commonLogic;       
        }

        public async Task<bool> AddUser( UserModel userModel) 
        {
            var userName = new Npgsql.NpgsqlParameter("@theusername",userModel.UserName);
            var userPass = new Npgsql.NpgsqlParameter("@theuserpassword",userModel.UserPassword);
            var userFName = new Npgsql.NpgsqlParameter("@thefirstname",userModel.UserFirstName);
            var userLName = new Npgsql.NpgsqlParameter("@thelastname",userModel.UserLastName);
            var userEmail = new Npgsql.NpgsqlParameter("@theuseremail",userModel.UserEmail);
            var userContact = new Npgsql.NpgsqlParameter("@thecontact",userModel.UserContact);

            UserModel userModel1 = await Task.Run(()=>_projectContextDB.UserModel.FromSqlRaw("select * from adduser(@theusername,@theuserpassword,"+
            "@thefirstname,@thelastname,@theuseremail,@thecontact)",userName,userPass,userFName,userLName,userEmail,userContact)
            .Select(e => new UserModel()
            {
                UserID = e.UserID
            }).FirstOrDefault());

            if(userModel1.UserID!= null)
            {
                return true;
            }

            return false;
          
        }

        public async Task<bool> UpdateUserById(Guid userID,  UserModel userModel) 
        {
            var userId = new Npgsql.NpgsqlParameter("@theuserid",userID);
            var userName = new Npgsql.NpgsqlParameter("@theusername",userModel.UserName);
            var userFName = new Npgsql.NpgsqlParameter("@thefirstname",userModel.UserFirstName);
            var userLName = new Npgsql.NpgsqlParameter("@thelastname",userModel.UserLastName);
            var userEmail = new Npgsql.NpgsqlParameter("@theuseremail",userModel.UserEmail);
            var userContact = new Npgsql.NpgsqlParameter("@thecontact",userModel.UserContact);

            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from updateuser(@theuserid,@theusername,"+
            "@thefirstname,@thelastname,@theuseremail,@thecontact)",userId,userName,userFName,userLName,userEmail,userContact)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status;
          
        }

        public async Task<bool> DeactivateUserById(Guid userID) 
        {
            var userId = new Npgsql.NpgsqlParameter("@theuserid",userID);

            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from deactivateuser(@theuserid)",userId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status;
          
        }

        public async Task<bool> ActivateUserById(Guid userID) 
        {
            var userId = new Npgsql.NpgsqlParameter("@theuserid",userID);

            CheckStatusModel checkStatusModel = await Task.Run(()=>_projectContextDB.CheckStatusModel.FromSqlRaw("select * from activateuser(@theuserid)",userId)
            .Select(e => new CheckStatusModel()
            {
                Status = e.Status
            }).FirstOrDefault());

            return checkStatusModel.Status;
          
        }

        public async Task<object> ShowAllUsers() 
        {

            List<UserResponse> userResponse = await Task.Run(()=>_projectContextDB.userResponse.FromSqlRaw("select * from showallusers()")
            .Select(e => new UserResponse()
            {
               UserID=e.UserID,
               UserName=e.UserName,
               UserFirstName = e.UserFirstName,
               UserLastName=e.UserLastName,
               UserEmail=e.UserEmail,
               UserContact=e.UserContact

            }).ToList());

            if(userResponse.Count>0)
            {
                var response = new{Success ="OK",userResponse=userResponse};

                return response;
            }
            return null;
          
        }

         public async Task<object> ShowUserById(Guid userID) 
        {
            var userId = new Npgsql.NpgsqlParameter("@theuserid",userID);


            List<UserResponse> userResponse = await Task.Run(()=>_projectContextDB.userResponse.FromSqlRaw("select * from showuserbyid(@theuserid)",userId)
            .Select(e => new UserResponse()
            {
               UserID=e.UserID,
               UserName=e.UserName,
               UserFirstName = e.UserFirstName,
               UserLastName=e.UserLastName,
               UserEmail=e.UserEmail,
               UserContact=e.UserContact

            }).ToList());

            if(userResponse.Count>0)
            {
                var response = new{Success ="OK",userResponse=userResponse};

                return response;
            }
            return null;
          
        }

        public async Task<Object> ExportAllUsers(string fileType)
        {
            try
            {
                string downloadUrl = null;
                string folder = FoldersNames.ExportedData;

                var listOfUsersToBeExported = await Task.Run(()=>_projectContextDB.ExportUserModel
                .FromSqlRaw("select * from Exportallusers()")
                .Select(e=>new userExportUserModel()
                {
                    UserName = e.UserName,
                    UserFirstName = e.UserFirstName,
                    UserLastName = e.UserLastName,
                    UserEmail = e.UserEmail,
                    UserContact = e.UserContact
                }).ToList());


                if(fileType.ToLower()=="excel")
                {
                    downloadUrl  = _commonLogic.ExportToExcel(listOfUsersToBeExported,folder);
                }

                var listOfUserInDataTable = _commonLogic.ToDataTable(listOfUsersToBeExported);

                if(fileType.ToLower()=="csv")
                {
                    downloadUrl  = _commonLogic.ExportToCsv(listOfUserInDataTable,folder);
                }

                if(fileType.ToLower()=="pdf")
                {
                    downloadUrl  = _commonLogic.ExportToPdf(listOfUserInDataTable,folder);
                }

                var exportedData = new {Success = "OK" , Data  = downloadUrl};

                return exportedData;

            }
            catch(Exception e)
            {
                return null;
            }
            

        }



    }
}