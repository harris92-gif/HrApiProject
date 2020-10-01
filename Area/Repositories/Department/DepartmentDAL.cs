using System;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Department;
using HrApiProject.Area.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace HrApiProject.Area.Repositories.Department
{
    public class DepartmentDAL
    {
        private readonly ProjectContextDB _projectContextDB;
        private readonly ICommonLogic _commonLogic;

        public DepartmentDAL(ProjectContextDB projectContextDB , ICommonLogic commonLogic)
        {
            _projectContextDB= projectContextDB;
            _commonLogic = commonLogic;
        }

        public async Task<object> AddNewDepartment(Guid BusinessId , DepartmentModel departmentModel)
        {
            var theBusinessID  = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessId);
            var departmentName = new Npgsql.NpgsqlParameter("@thedepartmentname",departmentModel.DepartmentName);

           var returnedID= await Task.Run(()=>_projectContextDB.DepartmentModels.FromSqlRaw("select * from adddepartment(@thebusinessid,@thedepartmentname)as dept_id",
            theBusinessID,departmentName)
            .Select(e=>new DepartmentModel()
            {
                DepartmentID = e.DepartmentID
            }).FirstOrDefault());

            if(returnedID.DepartmentID !=new Guid())
            {
                return true;
            }
            return false;
            
        }

        public async Task<object> ShowAllDepartments(Guid BusinessID)
        {
            var theBusinessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            return await Task.Run(()=>_projectContextDB.departmentResponse.FromSqlRaw("select * from showalldepartments(@thebusinessid)",theBusinessID)
            .Select(e=> new DepartmentResponse()
            {
             DepartmentID= e.DepartmentID,
            DepartmentName = e.DepartmentName
            }).ToList());
            
        }
        public async Task<object> ShowDepartmentById(Guid BusinessID,Guid DepartmentID)
        {
            var theBusinessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var theDepartmentID = new Npgsql.NpgsqlParameter("@thedeptid",DepartmentID);

            return await Task.Run(()=>_projectContextDB.departmentResponse.FromSqlRaw("select * from showdepartmentsbyid(@thebusinessid,@thedeptid)",theBusinessID,theDepartmentID)
            .Select(e=> new DepartmentResponse()
            {
             DepartmentID= e.DepartmentID,
            DepartmentName = e.DepartmentName
            }).ToList());
            
        }

         public async Task<bool> UpdateDepartmentById(Guid BusinessID,Guid DepartmentID,DepartmentModel departmentModel )
        {
            var theBusinessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var theDepartmentID = new Npgsql.NpgsqlParameter("@thedeptid",DepartmentID);
            var theDepartmentName = new Npgsql.NpgsqlParameter("@thedeptname",departmentModel.DepartmentName);


            var getUpdatedId = await Task.Run(()=>_projectContextDB.DepartmentModels.FromSqlRaw("select * from updatedepartment(@thebusinessid,@thedeptid,@thedeptname) as dept_id",theBusinessID,theDepartmentID,theDepartmentName)
            .Select(e=> new DepartmentModel()
            {
             DepartmentID= e.DepartmentID
            }).FirstOrDefault());

            if(getUpdatedId.DepartmentID==new Guid())
            {
                return false;
            }
            return true;
            
        }

        
         public async Task<bool> InActivateDepartmentById(Guid BusinessID,Guid DepartmentID)
            {
            var theBusinessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var theDepartmentID = new Npgsql.NpgsqlParameter("@thedeptid",DepartmentID);

           var getId =  await Task.Run(()=>_projectContextDB.DepartmentModels.FromSqlRaw("select * from inactivatedepartment(@thebusinessid,@thedeptid) as dept_id",theBusinessID,theDepartmentID)
            .Select(e=> new DepartmentModel()
            {
             DepartmentID= e.DepartmentID
           
            }).FirstOrDefault());

              if(getId.DepartmentID==new Guid())
            {
                return false;
            }
            return true;
            
        }

        public async Task<bool> ActivateDepartmentById(Guid BusinessID,Guid DepartmentID)
        {
            var theBusinessID = new Npgsql.NpgsqlParameter("@thebusinessid",BusinessID);
            var theDepartmentID = new Npgsql.NpgsqlParameter("@thedeptid",DepartmentID);

           var getId =  await Task.Run(()=>_projectContextDB.DepartmentModels.FromSqlRaw("select * from activatedepartment(@thebusinessid,@thedeptid) as dept_id",theBusinessID,theDepartmentID)
            .Select(e=> new DepartmentModel()
            {
             DepartmentID= e.DepartmentID
           
            }).FirstOrDefault());

              if(getId.DepartmentID==new Guid())
            {
                return false;
            }
            return true;
            
        }



        public async Task<object> ExportAllDepartments(Guid businessID,string fileType)
        {
            try 
            {
            
                string downlaodUrl = null;
                string folder = FoldersNames.ExportedData;

                var businessId = new Npgsql.NpgsqlParameter("@thebusinessid",businessID);

                var listOfDepartmentsDataToBeExport = await Task.Run(()=>_projectContextDB.ExportDepartmentModel.
                FromSqlRaw("select * from exportalldepartments(@thebusinessid)",businessId)
                .Select(e=> new ExportDepartmentModel()
                {
                   DepartmentName = e.DepartmentName
                    
                }).ToList());


                if(fileType.ToLower()=="excel")
                {
                    downlaodUrl = _commonLogic.ExportToExcel(listOfDepartmentsDataToBeExport,folder);
                }                

                //create a datatable of this data
                var listOfDepartmentsInDataTable = _commonLogic.ToDataTable(listOfDepartmentsDataToBeExport);
                
                if(fileType.ToLower()=="csv")
                {
                    downlaodUrl = _commonLogic.ExportToCsv(listOfDepartmentsInDataTable,folder);
                }     

                if(fileType.ToLower()=="pdf")
                {
                    downlaodUrl = _commonLogic.ExportToPdf(listOfDepartmentsInDataTable,folder);
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