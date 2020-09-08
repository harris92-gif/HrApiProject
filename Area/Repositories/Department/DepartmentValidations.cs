using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HrApiProject.Area.Models.Department;

namespace HrApiProject.Area.Repositories.Department
{
    public class DepartmentValidations 
    {
        private readonly DepartmentResponseMessages _departmentResponseMessages;
        public DepartmentValidations(DepartmentResponseMessages departmentResponseMessages)
        {
            _departmentResponseMessages = departmentResponseMessages;
        }
        public string Success {get; set;}
        public List<object> ErrorsList{get; set;}
        public object ValidateDepartmentData(DepartmentModel departmentModel)
        {
            ErrorsList = new List<object>();

            if(string.IsNullOrEmpty(departmentModel.DepartmentName.Trim()))
            {
                Success = "Failed";
                ErrorsList.Add(_departmentResponseMessages.EnterDepartmentName());                
            }
            else
            {
                if(!Regex.IsMatch(departmentModel.DepartmentName,@"^[a-zA-z ]+$"))
                {
                    Success="Failed";
                    ErrorsList.Add(_departmentResponseMessages.InvalidDepartmentName());
                    
                }
            }
            if (Success!=null)
            {
                return this;
            }
            return null;
        }
       

        public object DepartmentAdded()
        {
            ErrorsList = new List<object>();
            Success = "OK";
            ErrorsList.Add(_departmentResponseMessages.DepartmentAdded()); 
            return this;
        }

        public object DepartmentInsertionFailed()
        {
            ErrorsList = new List<object>();
            Success = "Failed";
            ErrorsList.Add(_departmentResponseMessages.DepartmentInsertionFailed());
            return this;
        }

           public object DepartmentNameUpdated()
        {
            ErrorsList = new List<object>();
            Success = "OK";
            ErrorsList.Add(_departmentResponseMessages.DepartmentNameUpdated()); 
            return this;
        }

        
          public object IdDoesNotExists(Guid theDepartmentId)
        {
            ErrorsList = new List<object>();
            Success = "OK";
            ErrorsList.Add(_departmentResponseMessages.IdDoesNotExists(theDepartmentId)); 
            return this;
        }

        
            public object DepartmentInActivated()
        {
            ErrorsList = new List<object>();
            Success = "OK";
            ErrorsList.Add(_departmentResponseMessages.DepartmentInActivated()); 
            return this;
        }

        public object DepartmentActivated()
        {
            ErrorsList = new List<object>();
            Success = "OK";
            ErrorsList.Add(_departmentResponseMessages.DepartmentActivated()); 
            return this;
        }



        
    }
}