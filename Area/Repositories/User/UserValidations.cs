using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using HrApiProject.Area.Models.User;

namespace HrApiProject.Area.Repositories.User
{
    public class UserValidations
    {
        private readonly UserResponseMessages _userResponseMessages;

        public UserValidations(UserResponseMessages userResponseMessages)
        {
            _userResponseMessages=userResponseMessages;
        }

        public bool IsValidEmail(string emailAddress)
        {
            try 
            {
                MailAddress m  =  new MailAddress(emailAddress);
                return true;
            }
            catch(FormatException)
            {
                return false;
            }
        }

        

        public string Success {get; set;}
        public List<object> ErrorList {get; set;}

        public object ValidateUserData(UserModel userModel,string actionType)
        {
            ErrorList = new List<object>();
            if(string.IsNullOrEmpty(userModel.UserName.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_userResponseMessages.UserNameNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(userModel.UserName,@"^[a-zA-Z0-9._@#$% ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_userResponseMessages.InValidUserName());   
                }
            }
            if(actionType=="insertion")
           {
                if(string.IsNullOrEmpty(userModel.UserPassword.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_userResponseMessages.UserPasswordNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(userModel.UserPassword,@"^[a-zA-Z0-9._@#$% ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_userResponseMessages.InValidUserPassword());   
                }
            }
           }
            if(string.IsNullOrEmpty(userModel.UserFirstName.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_userResponseMessages.UserFirstNameNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(userModel.UserFirstName,@"^[a-zA-Z  ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_userResponseMessages.InValidUserFirstName());   
                }
            }
            if(string.IsNullOrEmpty(userModel.UserLastName.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_userResponseMessages.UserLastNameNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(userModel.UserLastName,@"^[a-zA-Z  ]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_userResponseMessages.InValidUserLastName());   
                }
            }

            if(string.IsNullOrEmpty(userModel.UserEmail.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_userResponseMessages.UserEmailNotProvided());                
            }

            else

            {
                if(!IsValidEmail(userModel.UserEmail))
                {
                    Success = "Failed";
                    ErrorList.Add(_userResponseMessages.InValidUserEmail());   
                }
            }
             if(string.IsNullOrEmpty(userModel.UserContact.Trim()))
            {
                Success = "Failed";
                ErrorList.Add(_userResponseMessages.UserContactNotProvided());                
            }

            else

            {
                if(!Regex.IsMatch(userModel.UserContact,@"^[0-9-]+$"))
                {
                    Success = "Failed";
                    ErrorList.Add(_userResponseMessages.InValidUserContact());   
                }
            }

            if(Success!=null)
            {
                return this;
            }
            return null;
        }

        public object UserAddedSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_userResponseMessages.UserAddedSuccess());
            return this;
        }
         public object UserAddedFailed()
        {
            ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_userResponseMessages.UserAddedFailed());
            return this;
        }
         public object UserUpdatedSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_userResponseMessages.UserUpdatedSuccess());
            return this;
        }
        public object UserDeactivatedSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_userResponseMessages.UserDeactivatedSuccess());
            return this;
        }

         public object UserActivatedSuccess()
        {
            ErrorList = new List<object>();
            Success = "OK";
            ErrorList.Add(_userResponseMessages.UserActivatedSuccess());
            return this;
        }

        public object UserIdNotFound(Guid userId)
        {
            ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_userResponseMessages.UserIdNotFound(userId));
            return this;
        }
        
        public object NoRecordFound()
        {
            ErrorList = new List<object>();
            Success = "Failed";
            ErrorList.Add(_userResponseMessages.NoRecordFound());
            return this;
        }
        
        
        
    }
}