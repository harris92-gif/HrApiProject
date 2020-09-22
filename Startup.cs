using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Repositories.Business;
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HrApiProject.Area.Repositories.Department;
using HrApiProject.Area.Repositories.Employee;
using HrApiProject.Area.Repositories.User;
using HrApiProject.Area.Repositories.Salary;
using HrApiProject.Area.Repositories.Common;
using HrApiProject.Area.Repositories.BusinessUsers;
using HrApiProject.Area.Repositories.Deductions;
using HrApiProject.Area.Repositories.Increments;

namespace HrApiProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectContextDB>(options=>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));



            services.AddControllers();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
        

           services.AddScoped<IBusinessLogic, BusinessLogic>();
           services.AddScoped<BusinessDAL>(); 
           services.AddScoped<BusinessResponseMessages>(); 
           services.AddScoped<BusinessValidations>(); 

           services.AddScoped<IDepartmentLogic, DepartmentLogic>();
           services.AddScoped<DepartmentDAL>();
           services.AddScoped<DepartmentResponseMessages>();
           services.AddScoped<DepartmentValidations>();

           services.AddScoped<IEmployeeLogic, EmployeeLogic>();
           services.AddScoped<EmployeeDAL>();
           services.AddScoped<EmployeeResponseMessages>();
           services.AddScoped<EmployeeValidation>();

            services.AddScoped<IUserLogic, UserLogic>();
           services.AddScoped<UserDAL>();
           services.AddScoped<UserResponseMessages>();
           services.AddScoped<UserValidations>();

           services.AddScoped<ISalaryLogic, SalaryLogic>();
           services.AddScoped<SalaryDAL>();
           services.AddScoped<SalaryResponseMessages>();
           services.AddScoped<SalaryValidation>();

            services.AddScoped<ICommonLogic, CommonLogic>();
           services.AddScoped<CommonDAL>();
           services.AddScoped<CommonResponseMessages>();
           services.AddScoped<CommonValidation>();

           services.AddScoped<IBusinessUsersLogic, BusinessUsersLogic>();
           services.AddScoped<BusinessUsersDAL>();
           services.AddScoped<BusinessUsersResponseMessages>();
           services.AddScoped<BusinessUsersValidation>();

           services.AddScoped<IDeductionLogic, DeductionLogic>();
           services.AddScoped<DeductionDAL>();
           services.AddScoped<DeductionResponseMessages>();
           services.AddScoped<DeductionValidation>();

           services.AddScoped<IIncrementsLogic, IncrementsLogic>();
           services.AddScoped<IncrementsDAL>();
           services.AddScoped<IncrementsResponseMessages>();
           services.AddScoped<IncrementsValidation>();



           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             

// Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
