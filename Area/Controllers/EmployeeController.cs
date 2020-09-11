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
            var errors = _employeeValidation.ValidateEmployeeData(employeeModel);
            if(errors!=null)
            {
                return errors;
            }

            var response = await _employeeLogic.AddEmployeeWithDetails(theBusinessId, employeeModel);

            if(response)
            {
                return _employeeValidation.EmployeeAddedSuccess();
            }
            return _employeeValidation.DepartmentIdDoesNotExist(employeeModel.DepartmentID);
        }

        [HttpPut("UpdateEmployeeWithDetailsByID")]
        public async Task<object> UpdateEmployeeWithDetailsById(Guid theBusinessId ,Guid theEmployeeId,[FromBody] UpdateEmployeeModel updateEmployeeModel) 
        {
            var errors = _employeeValidation.ValidateUpdateEmployeeData(updateEmployeeModel);
            if(errors!=null)
            {
                return errors;
            }
            var response = await _employeeLogic.UpdateEmployeeWithDetailsById(theBusinessId,theEmployeeId,updateEmployeeModel);
            if(response)
            {
                return _employeeValidation.EmployeeUpdatedSucces();

            }
            return _employeeValidation.EmployeeIdDoesNotExist(theEmployeeId);
        }

        [HttpPost("DeactivateEmployeeById")]
        public  async Task<object> DeactivateEmployeeById(Guid theBusinessId ,Guid theEmployeeId)
        {
            bool response = await _employeeLogic.DeactivateEmployeeById(theBusinessId,theEmployeeId);
            if(response)
            {
                return _employeeValidation.EmployeeDeactivatededSuccess();
            }
            return _employeeValidation.EmployeeIdDoesNotExist(theEmployeeId);
        }


        [HttpPost("ActivateEmployeeById")]
        public  async Task<object> ActivateEmployeeById(Guid theBusinessId ,Guid theEmployeeId)
        {
            bool response = await _employeeLogic.ActivateEmployeeById(theBusinessId,theEmployeeId);
            if(response)
            {
                return _employeeValidation.EmployeeActivatedSuccess();
            }
            return _employeeValidation.EmployeeIdDoesNotExist(theEmployeeId);
        }    

        [HttpGet("ShowAllEmployeesWithDetails")]
         public async Task<object> ShowAllEmployeesWithDetails(Guid businessID)
         {
             var response = await _employeeLogic.ShowAllEmployeesWithDetails(businessID);
             if(response!=null)
             {
                 return response;
             }
             return _employeeValidation.NoEmployeeFound();
         }

        [HttpGet("ShowEmployeesWithDetailsById")]
         public async Task<object> ShowEmployeesWithDetailsById(Guid businessID,Guid employeeId)
         {
             var response = await _employeeLogic.ShowEmployeesWithDetailsByID(businessID,employeeId);
             if(response!=null)
             {
                 return response;
             }
             return _employeeValidation.NoEmployeeFound();
         }




    }
}