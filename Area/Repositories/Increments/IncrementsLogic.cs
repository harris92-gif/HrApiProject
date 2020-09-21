using System;
using System.Threading.Tasks;
using HrApiProject.Area.Models.Increments;

namespace HrApiProject.Area.Repositories.Increments
{
    public class IncrementsLogic : IIncrementsLogic
    {
        private readonly IncrementsDAL _incrementsDAL;

        public IncrementsLogic(IncrementsDAL incrementsDAL)
        {
            _incrementsDAL = incrementsDAL;
        }
        public Task<Guid[]> AddIncrements(Guid businessID, IncrementsModel incrementsModel)
        {
            return _incrementsDAL.AddIncrements(businessID , incrementsModel);
        }

        

        public Task UpdateIncrementByID(Guid businessID, Guid incrementID, IncrementsUpdateModel incrementsUpdateModel)
        {
            return _incrementsDAL.UpdateIncrementByID(businessID,incrementID,incrementsUpdateModel);
        }

        public Task<object> ShowAllIncrements(Guid businessID)
        {
            return _incrementsDAL.ShowAllIncrements(businessID);
        }

        public Task<object> ShowIncrementById(Guid businessID, Guid incrementID)
        {
            return _incrementsDAL.ShowIncrementById(businessID,incrementID);
        }
    }
}