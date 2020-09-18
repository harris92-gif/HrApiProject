using System.Collections.Generic;
using HrApiProject.Area.Models.Deductions;

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

        public object ValidateDeductionData(DeductionModel deductionModel)
        {
            
            ResponseList = new List<object>();
            foreach(DeductionDetails deductionDetails in deductionModel.DeductionDetails)
            {
                if(deductionDetails.Amount<=0)
                {
                    Success = "Failed";
                    ResponseList.Add(_deductionResponseMessages.InvalidAmount());
                   
                }
                 if(string.IsNullOrEmpty(deductionDetails.Description))
                {
                    Success = "Failed";
                    ResponseList.Add(_deductionResponseMessages.DescNotProvided());
                   
                }
                else
                {
                       if(deductionDetails.Description.Length>100)
                       {
                           Success = "Failed";
                            ResponseList.Add(_deductionResponseMessages.DescExceedsLimit());
                       } 
                }
                
            }
            if(Success!=null)
            {
                return this;
            }
            return null;
        }


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
            Success = "Failed";
            ResponseList.Add(_deductionResponseMessages.DeductionAdditionFailed());
            return this;
        }






    }
}