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

        public Task<bool> AddDeduction(Guid businessID, DeductionModel deductionModel)
        {
            return _deductionDAL.AddDeduction(businessID,deductionModel);
        }
    }
}