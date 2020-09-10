using System;
using System.Collections.Generic;

namespace HrApiProject.Area.Repositories.Employee
{
    public class EmployeeValidation
    {
        private readonly EmployeeResponseMessages _employeeResponseMessages;
        public EmployeeValidation(EmployeeResponseMessages employeeResponseMessages)
        {
            _employeeResponseMessages= employeeResponseMessages;
        }

        public string Success {get; set;}
        public List<object> ErrorList {get; set;}


        public object EmployeeAddedSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_employeeResponseMessages.EmployeeAddedSuccess());
            return this;
        }

         public object EmployeeAddedFailed()
        {
            ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_employeeResponseMessages.EmployeeAddedFailed());
            return this;
        }

        public object DepartmentIdDoesNotExist(Guid DepartmentId)
        {
             ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_employeeResponseMessages.DepartmentIdDoesNotExist(DepartmentId));
            return this;
        }

         public object EmployeeUpdatedSucces()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_employeeResponseMessages.EmployeeUpdatedSucces());
            return this;
        }

        
         public object EmployeeDeactivatededSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_employeeResponseMessages.EmployeeDeactivatedSuccess());
            return this;
        }

          public object EmployeeActivatedSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_employeeResponseMessages.EmployeeActivatedSuccess());
            return this; 
        }


       
        public object EmployeeIdDoesNotExist(Guid empId)
        {
             ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_employeeResponseMessages.EmployeeIdDoesNotExist(empId));
            return this;
        }
        

        public object NoEmployeeFound()
        {
             ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_employeeResponseMessages.NoEmployeeFound());
            return this;
        }        


      
        
    }
}