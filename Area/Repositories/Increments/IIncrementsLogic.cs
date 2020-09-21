using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Increments;

namespace HrApiProject.Area.Repositories.Increments
{
    public interface IIncrementsLogic
    {
        Task<Guid[]> AddIncrements (Guid businessID  , IncrementsModel incrementsModel) ;
        Task UpdateIncrementByID(Guid businessID ,Guid incrementID , IncrementsUpdateModel incrementsUpdateModel);

        Task<object> ShowAllIncrements(Guid businessID);

        Task<object> ShowIncrementById(Guid businessID,Guid incrementID);




    }
}