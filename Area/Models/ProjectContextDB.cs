using HrApiProject.Area.Models;
using HrApiProject.Area.Models.CommonModels;
using HrApiProject.Area.Models.Department;
using HrApiProject.Area.Models.Employee;
using HrApiProject.Area.Models.Salary;
using HrApiProject.Area.Models.User;
using Microsoft.EntityFrameworkCore;
namespace HrApiProject.Area.Models
{
  
    public class ProjectContextDB :DbContext        
    {
          public string _schemaName;           
          public  ProjectContextDB(DbContextOptions<ProjectContextDB> options, string schemaName)
          :base(options)=>_schemaName=schemaName;

          public ProjectContextDB(DbContextOptions<ProjectContextDB> options):base(options)
          {
            
          }

        public DbSet<BusinessModel> BusinessModels {get; set;}

        public DbSet<DepartmentModel> DepartmentModels {get; set;}

        public DbSet<DepartmentResponse> departmentResponse {get; set;}
        public DbSet<EmployeeModel> EmployeeModel {get; set;}

        public DbSet<UpdateEmployeeModel> UpdateEmployeeModel {get; set;}
        public DbSet<CheckStatusModel> CheckStatusModel {get; set;}

        public DbSet<EmployeeResponse> EmployeeResponse {get; set;}
        public DbSet<UserModel> UserModel {get; set;}
        public DbSet<UserResponse> userResponse {get; set;}

        public DbSet<SalaryModel> SalaryModel {get; set;}

        public DbSet<SalaryResponse> salaryResponse {get; set;}

        public DbSet<SalaryWithEmployeeNameResponse> SalaryWithEmployeeNameResponse {get; set;}









          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              if(_schemaName!=null)
              {
                  modelBuilder.HasDefaultSchema(_schemaName);
              }
              
              modelBuilder.HasPostgresExtension("uuid-ossp");


              modelBuilder.Entity<EmployeeDetails>(entity=>
              {
                  entity.HasNoKey();
              });       

              modelBuilder.Entity<CheckStatusModel>(entity=>
              {
                  entity.HasNoKey();
              });

               modelBuilder.Entity<SalaryWithEmployeeNameResponse>(entity=>
              {
                  entity.HasNoKey();
              });        

            
          }




    }
}