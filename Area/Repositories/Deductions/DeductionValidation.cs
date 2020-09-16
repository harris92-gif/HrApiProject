using System.Collections.Generic;

namespace HrApiProject.Area.Repositories.Deductions
{
    public class DeductionValidation
    {
        private readonly DeductionResponseMessages _deductionResponseMessages;


        public DeductionValidation(DeductionResponseMessages deductionResponseMessages)
        {
            _deductionResponseMessages=deductionResponseMessages;
        }

        public string Success {get ;set; }
        public List<object> ResponseList {get; set;}


        public object DeductionAddedSuccess()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(_deductionResponseMessages.DeductionAddedSuccess());
            return this;
        }

         public object DeductionAdditionFailed()
        {
            ResponseList = new List<object>();
            Success = "OK";
            ResponseList.Add(_deductionResponseMessages.DeductionAdditionFailed());
            return this;
        }






    }
}