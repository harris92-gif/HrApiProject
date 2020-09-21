using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Deductions;

namespace HrApiProject.Area.Repositories.Deductions
{
    public class DeductionLogic : IDeductionLogic
    {
        private readonly DeductionDAL _deductionDAL;

        public DeductionLogic(DeductionDAL deductionDAL)
        {
            _deductionDAL=deductionDAL;
            
        }

        public Task<Guid[]> AddDeduction(Guid businessID, DeductionModel deductionModel)
        {
            return _deductionDAL.AddDeduction(businessID,deductionModel);
        }

        public Task<object> ShowAllDeduction(Guid businessID)
        {
            return _deductionDAL.ShowAllDeduction(businessID);
        }

        public Task<object> ShowDeductionById(Guid businessID, Guid deductionID)
        {
            return _deductionDAL.ShowDeductionById(businessID,deductionID);
        }

       

        public Task UpdateDeductionByID(Guid businessID, Guid deductionID, UpdateDeductionModel updateDeductionModel)
        {   
            return _deductionDAL.UpdateDeductionByID(businessID , deductionID , updateDeductionModel);
        }     

         public  Task<object> ShowDeductionsByEmployeeId(Guid businessID, Guid employeeID)
        {
            return _deductionDAL.ShowDeductionsByEmployeeId(businessID , employeeID);
        } 
    }
}