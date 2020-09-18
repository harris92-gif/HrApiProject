using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Deductions;

namespace HrApiProject.Area.Repositories.Deductions
{
    public interface IDeductionLogic
    {
        Task<Guid[]> AddDeduction(Guid businessID , DeductionModel deductionModel);
       Task<object> ShowAllDeduction(Guid businessID );

        Task<object> ShowDeductionById(Guid businessID ,Guid deductionID);



    }
}