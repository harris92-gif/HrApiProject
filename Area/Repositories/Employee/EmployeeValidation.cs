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


        public object EmployeeAddedSucces()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_employeeResponseMessages.EmployeeAddedSucces());
            return this;
        }

         public object EmployeeAddedFailed()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_employeeResponseMessages.EmployeeAddedFailed());
            return this;
        }
        
    }
}