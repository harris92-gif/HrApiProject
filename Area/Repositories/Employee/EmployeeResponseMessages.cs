using System;

namespace HrApiProject.Area.Repositories.Employee
{
    public class EmployeeResponseMessages
    {

        public class ErrorCodes
        {
            public int ResponseCode {get; set;}
            public string Message {get; set;}
        }

        public object EmployeeAddedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1001;
            ec.Message = "Employee Added SuccessFully";
            return ec;

        }
         public object EmployeeUpdatedSucces()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1002;
            ec.Message = "Employee Updated SuccessFully";
            return ec;

        }
        
         public object EmployeeDeactivatedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1003;
            ec.Message = "Employee Deactivated SuccessFully";
            return ec;

        }

        public object EmployeeActivatedSuccess() 
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1004;
            ec.Message = "Employee Activated SuccessFully";
            return ec;
        }

        public object EmployeeAddedFailed()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2001;
            ec.Message = "Employee Insertion Failed ";
            return ec;

        }

        public object DepartmentIdDoesNotExist(Guid DepartmentId)
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2002;
            ec.Message = "This Department id ( " + DepartmentId +" ) does not exists ";
            return ec;
        }
        public object EmployeeIdDoesNotExist(Guid empId)
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2003;
            ec.Message = "This Employee id ( " + empId +" ) does not exists ";
            return ec;
        }
        
        public object NoEmployeeFound()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2004;
            ec.Message = "No Employee Record Found ";
            return ec;
        }

        
         public object EmpNameNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2005;
            ec.Message = "plz Enter Employee Name";
            return ec;
        }
        
         public object InaValidEmpName()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2006;
            ec.Message = "Invalid Employee Name (enter characters and spaces only)";
            return ec;
        }
         public object EmpGenderNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2007;
            ec.Message = "plz Enter Employee Gender";
            return ec;
        }
        
         public object InaValidEmpGender()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2008;
            ec.Message = "Invalid Employee Gender (enter characters and spaces only)";
            return ec;
        }
        public object EmpSSNNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2009;
            ec.Message = "Enter Employee SSN";
            return ec;
        }
        
         public object InaValidEmpSSN()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2010;
            ec.Message = "Invalid Employee SSN  (enter characters,digits,hyphens and spaces only)";
            return ec;
        }

        public object EmpBPSNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2011;
            ec.Message = "Enter Employee BPS";
            return ec;
        }
        
         public object InaValidEmpBPS()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2012;
            ec.Message = "Invalid Employee BPS  (enter digits only )";
            return ec;
        }


        public object EmpDesignationNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2013;
            ec.Message = "Enter Employee Designation";
            return ec;
        }
        
        public object InaValidEmpDesignation()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2014;
            ec.Message = "Invalid Employee Designation  (enter characters spaces only) ";
            return ec;
        }
         public object EmpPACountryNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2015;
            ec.Message = "Enter Employee PACountry";
            return ec;
        }
        
        public object InaValidEmpPACountry()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2016;
            ec.Message = "Invalid Employee PACountry  (enter characters spaces only) ";
            return ec;
        }
          public object EmpPACityNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2017;
            ec.Message = "Enter Employee PACity";
            return ec;
        }
        
        public object InaValidEmpPACity()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2018;
            ec.Message = "Invalid Employee PACity  (enter characters spaces only) ";
            return ec;
        }
          public object EmpPAProvinceNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2019;
            ec.Message = "Enter Employee PAProvince";
            return ec;
        }
        
        public object InaValidEmpPAProvince()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2020;
            ec.Message = "Invalid Employee PAProvince  (enter characters spaces only) ";
            return ec;
        }
          public object EmpPAZipNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2021;
            ec.Message = "Enter Employee PAZip";
            return ec;
        }
        
        public object InaValidEmpPAZip()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2022;
            ec.Message = "Invalid Employee PAZip  (enter characters spaces only) ";
            return ec;
        }

         public object EmpMACountryNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2023;
            ec.Message = "Enter Employee PACountry";
            return ec;
        }

         public object InaValidEmpMACountry()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2024;
            ec.Message = "Invalid Employee MACountry  (enter characters spaces only) ";
            return ec;
        }
          public object EmpMACityNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2025;
            ec.Message = "Enter Employee MACity";
            return ec;
        }
        
        public object InaValidEmpMACity()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2026;
            ec.Message = "Invalid Employee MACity  (enter characters spaces only) ";
            return ec;
        }
          public object EmpMAProvinceNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2027;
            ec.Message = "Enter Employee MAProvince";
            return ec;
        }
        
        public object InaValidEmpMAProvince()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2028;
            ec.Message = "Invalid Employee MAProvince  (enter characters spaces only) ";
            return ec;
        }
          public object EmpMAZipNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2029;
            ec.Message = "Enter Employee MAZip";
            return ec;
        }
        
        public object InaValidEmpMAZip()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2030;
            ec.Message = "Invalid Employee MAZip  (enter characters spaces only) ";
            return ec;
        }

        public object EmpEmailNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2031;
            ec.Message = "Enter Employee Email";
            return ec;
        }
        
        public object InaValidEmpEmail()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2032;
            ec.Message = "Invalid Employee Email ";
            return ec;
        }

         public object EmpJoiningDateNotProvided()  
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2033;
            ec.Message = "Enter Employee Joining Date";
            return ec;
        }
        
        public object InValidEmpJoiningDate()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2034;
            ec.Message = "Invalid Employee Joining date ( format for date is YYYY-MM-DD) ";
            return ec;
        }
        public object EmpAppointmentDateNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2035;
            ec.Message = "Enter Employee Appointment Date ";
            return ec;
        }
        
        public object InValidEmpAppointmentDate()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2036;
            ec.Message = "Invalid Employee Appoinment date ( format for date is YYYY-MM-DD) ";
            return ec;
        }
         public object EmpPhotoNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2037;
            ec.Message = "Enter Employee Photo  ";
            return ec;
        }
        
        public object InValidEmpPhoto()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2038;
            ec.Message = "Invalid Employee photo (use characters , digits and dots only) ";
            return ec;
        }

        
         public object EmpSkypeUserNameNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2037;
            ec.Message = "Enter Employee Skype username  ";
            return ec;
        }
        
        public object InValidEmpSkypeUserName()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2038;
            ec.Message = "Invalid Employee skype username (use characters , digits only) ";
            return ec;
        }

         public object EmpOfficeNoNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2039;
            ec.Message = "Enter Employee Office Number  ";
            return ec;
        }
        
        public object InaValidEmpOfficeNo()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2040;
            ec.Message = "Invalid Employee Office Number(use  digits and hyphens  only) ";
            return ec;
        }
          public object EmpCellNoNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2041;
            ec.Message = "Enter Employee Cell Number  ";
            return ec;
        }
        
        public object InValidEmpCellNo()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2042;
            ec.Message = "Invalid Employee Cell Number(use  digits and hyphens  only) ";
            return ec;
        }
   

        
    }
}