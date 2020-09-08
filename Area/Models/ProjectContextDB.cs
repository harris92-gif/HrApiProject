using HrApiProject.Area.Models;
using HrApiProject.Area.Models.Department;
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

        

    }
}