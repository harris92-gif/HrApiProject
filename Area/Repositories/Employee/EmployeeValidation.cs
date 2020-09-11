using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using HrApiProject.Area.Models.Employee;

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

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

         public bool IsValidDateFormat(string date)
        {
            Regex regex = new Regex(@"(((19|20)\d\d))\-(0[1-9]|1[0-2])\-((0|1)[0-9]|2[0-9]|3[0-1])$");
            //Verify whether date entered in dd/MM/yyyy format.
            return regex.IsMatch(date.Trim());
        }


        public object ValidateEmployeeData(EmployeeModel employeeModel)
        {
            ErrorList = new List<object>();
            if(string.IsNullOrEmpty(employeeModel.EmployeeName.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpNameNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(employeeModel.EmployeeName,@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpName());   
                }
            }

            if(string.IsNullOrEmpty(employeeModel.EmployeeGender.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpGenderNotProvided());                
            }

            else
            {
                if(!Regex.IsMatch(employeeModel.EmployeeGender,@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpGender());   
                }
            }
            if(string.IsNullOrEmpty(employeeModel.EmployeeSSN.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpSSNNotProvided());                
            }

            else
            {
                if(!Regex.IsMatch(employeeModel.EmployeeSSN,@"^[a-zA-Z0-9- ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpSSN());   
                }
            }

            foreach(EmployeeDetails employeeDetails in employeeModel.EmployeeDetails)
            {
                if(employeeDetails.BPS==0)
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpBPSNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.BPS),@"^[0-9]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpBPS());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.EmpDesignation.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpDesignationNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.EmpDesignation),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpDesignation());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.PACountry.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpPACountryNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.PACountry),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpPACountry());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.PACity.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpPACityNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.PACity),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpPACity());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.PAProvince.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpPAProvinceNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.PAProvince),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpPAProvince());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.PAZip.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpPAZipNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.PAZip),@"^[0-9 ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpPAZip());   
                    }
                }

                 if(string.IsNullOrEmpty(employeeDetails.MACountry.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpMACountryNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.MACountry),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpMACountry());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.MACity.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpMACityNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.MACity),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpMACity());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.MAProvince.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpMAProvinceNotProvided());                
                }
                else   
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.MAProvince),@"^[a-zA-Z ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpMAProvince());   
                    }
                }   
                if(string.IsNullOrEmpty(employeeDetails.MAZip.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpMAZipNotProvided());                
                }
                else  
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.MAZip),@"^[0-9 ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpMAZip());   
                    }
                }
                
                if(string.IsNullOrEmpty(employeeDetails.EmpEmail.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpEmailNotProvided());                
                }
                else  
                {
                    if(!IsValidEmail(employeeDetails.EmpEmail))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpEmail());   
                    }
                }

                if(string.IsNullOrEmpty(employeeDetails.EmpJoiningDate.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpJoiningDateNotProvided());                
                }
                else  
                {
                    if(!IsValidDateFormat(employeeDetails.EmpJoiningDate))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InValidEmpJoiningDate());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.EmpAppointmentDate.Trim()))
                {
                    Success = "Failed"; 
                    ErrorList.Add(_employeeResponseMessages.EmpAppointmentDateNotProvided());                
                }
                else  
                {
                    if(!IsValidDateFormat(employeeDetails.EmpAppointmentDate))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InValidEmpAppointmentDate());   
                    }
                }

                 if(string.IsNullOrEmpty(employeeDetails.Photo.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpPhotoNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.Photo),@"^[a-zA-Z0-9. ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InValidEmpPhoto());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.SkypeUserName.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpSkypeUserNameNotProvided());                
                }
                else
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.SkypeUserName),@"^[a-zA-Z0-9 ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InValidEmpSkypeUserName());   
                    }
                }
                 if(string.IsNullOrEmpty(employeeDetails.EmpOfficeNo.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpOfficeNoNotProvided());                
                }
                else  
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.EmpOfficeNo),@"^[0-9- ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InaValidEmpOfficeNo());   
                    }
                }
                if(string.IsNullOrEmpty(employeeDetails.EmpCellNo.Trim()))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.EmpCellNoNotProvided());                
                }
                else  
                {
                    if(!Regex.IsMatch( Convert.ToString(employeeDetails.EmpCellNo),@"^[0-9- ]+$"))
                    {
                        Success = "Failed";
                        ErrorList.Add(_employeeResponseMessages.InValidEmpCellNo());   
                    }
                }
            }
            if(Success!=null)
            {
                return this;
            }
            return null;
        }

        public object ValidateUpdateEmployeeData(UpdateEmployeeModel updateEmployeeModel)
        {
            ErrorList = new List<object>();
            if(string.IsNullOrEmpty(updateEmployeeModel.EmployeeName.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpNameNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(updateEmployeeModel.EmployeeName,@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpName());   
                }
            }

            if(string.IsNullOrEmpty(updateEmployeeModel.EmployeeGender.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpGenderNotProvided());                
            }

            else
            {
                if(!Regex.IsMatch(updateEmployeeModel.EmployeeGender,@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpGender());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.EmployeeSSN.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpSSNNotProvided());                
            }

            else
            {
                if(!Regex.IsMatch(updateEmployeeModel.EmployeeSSN,@"^[a-zA-Z0-9- ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpSSN());   
                }
            }

        
            if(updateEmployeeModel.BPS==0)
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpBPSNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.BPS),@"^[0-9]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpBPS());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.EmpDesignation.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpDesignationNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.EmpDesignation),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpDesignation());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.PACountry.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpPACountryNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.PACountry),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpPACountry());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.PACity.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpPACityNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.PACity),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpPACity());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.PAProvince.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpPAProvinceNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.PAProvince),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpPAProvince());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.PAZip.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpPAZipNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.PAZip),@"^[0-9 ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpPAZip());   
                }
            }

                if(string.IsNullOrEmpty(updateEmployeeModel.MACountry.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpMACountryNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.MACountry),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpMACountry());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.MACity.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpMACityNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.MACity),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpMACity());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.MAProvince.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpMAProvinceNotProvided());                
            }
            else   
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.MAProvince),@"^[a-zA-Z ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpMAProvince());   
                }
            }   
            if(string.IsNullOrEmpty(updateEmployeeModel.MAZip.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpMAZipNotProvided());                
            }
            else  
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.MAZip),@"^[0-9 ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpMAZip());   
                }
            }
            
            if(string.IsNullOrEmpty(updateEmployeeModel.EmpEmail.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpEmailNotProvided());                
            }
            else  
            {
                if(!IsValidEmail(updateEmployeeModel.EmpEmail))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpEmail());   
                }
            }

            if(string.IsNullOrEmpty(updateEmployeeModel.EmpJoiningDate.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpJoiningDateNotProvided());                
            }
            else  
            {
                if(!IsValidDateFormat(updateEmployeeModel.EmpJoiningDate))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InValidEmpJoiningDate());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.EmpAppointmentDate.Trim()))
            {
                Success = "Failed"; 
                ErrorList.Add(_employeeResponseMessages.EmpAppointmentDateNotProvided());                
            }
            else  
            {
                if(!IsValidDateFormat(updateEmployeeModel.EmpAppointmentDate))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InValidEmpAppointmentDate());   
                }
            }

                if(string.IsNullOrEmpty(updateEmployeeModel.Photo.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpPhotoNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.Photo),@"^[a-zA-Z0-9. ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InValidEmpPhoto());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.SkypeUserName.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpSkypeUserNameNotProvided());                
            }
            else
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.SkypeUserName),@"^[a-zA-Z0-9 ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InValidEmpSkypeUserName());   
                }
            }
                if(string.IsNullOrEmpty(updateEmployeeModel.EmpOfficeNo.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpOfficeNoNotProvided());                
            }
            else  
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.EmpOfficeNo),@"^[0-9- ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InaValidEmpOfficeNo());   
                }
            }
            if(string.IsNullOrEmpty(updateEmployeeModel.EmpCellNo.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_employeeResponseMessages.EmpCellNoNotProvided());                
            }
            else  
            {
                if(!Regex.IsMatch( Convert.ToString(updateEmployeeModel.EmpCellNo),@"^[0-9- ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_employeeResponseMessages.InValidEmpCellNo());   
                }
            }
            
            if(Success!=null)
            {
                return this;
            }
            return null;
        }



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