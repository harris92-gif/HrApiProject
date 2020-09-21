using System.Collections.Generic;
using System.Text.RegularExpressions;
using HrApiProject.Area.Models.Increments;

namespace HrApiProject.Area.Repositories.Increments
{
    public class IncrementsValidation
    {
        private readonly IncrementsResponseMessages _incrementsResponseMessages;

        public IncrementsValidation(IncrementsResponseMessages incrementsResponseMessages)
        {
            _incrementsResponseMessages =incrementsResponseMessages;
        }

        public bool IsValidDateFormat(string date)
        {
            Regex regex = new Regex(@"(((19|20)\d\d))\-(0[1-9]|1[0-2])\-((0|1)[0-9]|2[0-9]|3[0-1])$");
            //Verify whether date entered in YYYY-MM-DD format.
            return regex.IsMatch(date.Trim());
        }

        public string Success {get; set;}
        public List<object> ResponseList {get; set;}


        public object ValidateIncrementsData(IncrementsModel incrementsModel)
        {
            
            ResponseList = new List<object>();
            foreach(IncrementsDetails incrementsDetails in incrementsModel.IncrementsDetails)
            {
                if(incrementsDetails.IncrementAmount<=0)
                {
                    Success = "Failed";
                    ResponseList.Add(_incrementsResponseMessages.InvalidAmount());
                   
                }
                if(string.IsNullOrEmpty(incrementsDetails.Description.Trim()))
                {
                    Success = "Failed";
                    ResponseList.Add(_incrementsResponseMessages.DescNotProvided());
                   
                }
                else
                {
                       if(incrementsDetails.Description.Length>100)
                       {
                           Success = "Failed";
                            ResponseList.Add(_incrementsResponseMessages.DescExceedsLimit());
                       } 
                }

                if(string.IsNullOrEmpty(incrementsDetails.IncrementDate.Trim()))
                {
                    Success = "Failed";
                    ResponseList.Add(_incrementsResponseMessages.DateNotProvided());
                   
                }
                else
                {
                       if(!IsValidDateFormat(incrementsDetails.IncrementDate))
                       {
                           Success = "Failed";
                            ResponseList.Add(_incrementsResponseMessages.InvalidDateFormat());
                       } 
                }
                
            }
            if(Success!=null)
            {
                return this;
            }
            return null;
        }

        public object ValidateUpdateIncrementData(IncrementsUpdateModel incrementsUpdateModel)
        {
            
            ResponseList = new List<object>();
           
                if(incrementsUpdateModel.IncrementAmount<=0)
                {
                    Success = "Failed";
                    ResponseList.Add(_incrementsResponseMessages.InvalidAmount());
                   
                }
                if(string.IsNullOrEmpty(incrementsUpdateModel.Description.Trim()))
                {
                    Success = "Failed";
                    ResponseList.Add(_incrementsResponseMessages.DescNotProvided());
                   
                }
                else
                {
                       if(incrementsUpdateModel.Description.Length>100)
                       {
                           Success = "Failed";
                            ResponseList.Add(_incrementsResponseMessages.DescExceedsLimit());
                       } 
                }
              
            
            if(Success!=null)
            {
                return this;
            }
            return null;
        }


        public object IncrementsAddedSuccess()
        {
            ResponseList  = new List<object>();
            Success = "OK";
            ResponseList.Add(_incrementsResponseMessages.IncrementsAddedSuccess());
            return this;
        }
        

        public object IncrementUpdatedSuccess()
        {
            ResponseList  = new List<object>();
            Success = "OK";
            ResponseList.Add(_incrementsResponseMessages.IncrementUpdatedSuccess());
            return this;
        }
    }
}