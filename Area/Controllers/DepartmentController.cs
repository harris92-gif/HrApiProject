using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Department;
using HrApiProject.Area.Repositories.Department;
using Microsoft.AspNetCore.Mvc;

namespace HrApiProject.Area.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DepartmentController : ControllerBase 
    {
        private readonly IDepartmentLogic _departmentLogic;
        private readonly DepartmentValidations _departmentValidations;
        public DepartmentController(IDepartmentLogic departmentLogic,DepartmentValidations departmentValidations)
        {
            _departmentLogic = departmentLogic;    
            _departmentValidations=departmentValidations;
        }

        [HttpPost("AddNewDepartment")]   
        public async  Task<object> AddNewDepartment([FromBody]  DepartmentModel departmentModel,Guid theBusinessId )  
        {
            var response1 =  _departmentValidations.ValidateDepartmentData(departmentModel); 
            if(response1!=null) 
            {
               return response1;
            }
            
            var response =await _departmentLogic.AddNewDepartment(theBusinessId,departmentModel);
            if(Convert.ToBoolean(response))
            {
               return _departmentValidations.DepartmentAdded();
            }
            return _departmentValidations.DepartmentInsertionFailed();
            
           
        }

        [HttpGet("ShowAllDepartments")]
        public async Task<object> ShowAllDepartments(Guid theBusinessId)
        {
            return await _departmentLogic.ShowAllDepartments(theBusinessId);
        }
        
        [HttpGet("ShowDepartmentByID")]
        public async Task<object> ShowDepartmentByID(Guid theBusinessId,Guid theDepartmentId) 
        {
            return await _departmentLogic.ShowDepartmentById(theBusinessId,theDepartmentId);
        }

        [HttpPut("UpdateDepartmentNameById")]
        public async Task<object> UpdateDepartmentById(Guid theBusinessId,Guid theDepartmentId,[FromBody] DepartmentModel departmentModel)
        {
            var response =  _departmentValidations.ValidateDepartmentData(departmentModel);
            if(response!=null)
            {
                return response;
            }
            
            var response1 = await _departmentLogic.UpdateDepartmentById(theBusinessId,theDepartmentId,departmentModel);
            if(response1)
            {
                return _departmentValidations.DepartmentNameUpdated();
            }

            return _departmentValidations.IdDoesNotExists(theDepartmentId);
        }

        [HttpPost("InactivateDepartmentById")]
        public async Task<object> InActivateDepartmentById(Guid theBusinessID,Guid theDepartmentId)
        {
            var response = await _departmentLogic.InActivateDepartmentById(theBusinessID,theDepartmentId);
            if(response)
            {
                return _departmentValidations.DepartmentInActivated();
            }

            return _departmentValidations.IdDoesNotExists(theDepartmentId);

        }

        [HttpPost("ActivateDepartmentById")]
        public async Task<object> ActivateDepartmentById(Guid theBusinessID,Guid theDepartmentId)
        {
            var response = await _departmentLogic.ActivateDepartmentById(theBusinessID,theDepartmentId);
            if(response)
            {
                return _departmentValidations.DepartmentActivated();
            }

            return _departmentValidations.IdDoesNotExists(theDepartmentId);

        }




    }
}