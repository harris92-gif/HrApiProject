using System.Threading.Tasks;
using HrApiProject.Area.Models;

namespace HrApiProject.Area.Repositories.Business
{
    public interface IBusinessLogic
    {
         Task<object> AddNewBusiness(BusinessModel businessModel);
    }
}