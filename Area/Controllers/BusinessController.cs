using HrApiProject.Area.Repositories.Business;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using HrApiProject.Area.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;

namespace HrApiProject.Area.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
         private readonly IBusinessLogic _businessLogic;
         private readonly BusinessValidations _businessValidations;
       public BusinessController(IBusinessLogic businessLogic,BusinessValidations businessValidations)
       {
           _businessLogic = businessLogic;
           _businessValidations=businessValidations;


       }

       [HttpPost("AddNewBusiness")]  
        public async Task<object> AddNewBusiness([FromBody] BusinessModel businessModel)
        {
            
            var response = await Task.Run(()=>_businessLogic.AddNewBusiness(businessModel));
            if(Convert.ToBoolean(response))
            {
                return _businessValidations.BusinessAdded();
            }

             return _businessValidations.BusinessInsertionFailed();
        }


        
    }
}







