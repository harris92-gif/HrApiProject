using System.Threading.Tasks;
using HrApiProject.Area.Models;
using HrApiProject.Area.Repositories.Business;

namespace HrApiProject.Area.Repositories.Business
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly BusinessDAL _businessDAL;

        public BusinessLogic(BusinessDAL businessDAL)
        {
            _businessDAL=businessDAL;
        }

        public Task<object> AddNewBusiness(BusinessModel businessModel)
        {
            return _businessDAL.AddNewBusiness(businessModel);
        }
    }
}