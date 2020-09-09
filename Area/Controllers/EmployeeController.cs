using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Employee;
using HrApiProject.Area.Repositories.Employee;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly EmployeeValidation _employeeValidation;

        public EmployeeController(IEmployeeLogic employeeLogic,EmployeeValidation employeeValidation)
        {
            _employeeLogic= employeeLogic;
            _employeeValidation = employeeValidation;
        }


        [HttpPost("AddEmployeeWithDetails")]
        public async  Task<object> AddEmployeeWithDetails(Guid theBusinessId ,[FromBody] EmployeeModel employeeModel)
        {
            var response = await _employeeLogic.AddEmployeeWithDetails(theBusinessId, employeeModel);

            if(response)
            {
                return _employeeValidation.EmployeeAddedSucces();
            }
            return _employeeValidation.EmployeeAddedFailed();
        }

        
    }
}