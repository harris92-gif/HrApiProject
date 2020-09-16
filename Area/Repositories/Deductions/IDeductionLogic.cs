using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Deductions;

namespace HrApiProject.Area.Repositories.Deductions
{
    public interface IDeductionLogic
    {
        Task<bool> AddDeduction(Guid businessID , DeductionModel deductionModel);

    }
}