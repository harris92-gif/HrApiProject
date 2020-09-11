using System;

namespace HrApiProject.Area.Repositories.User
{
    public class ErrorCodes
    {
        public int  ResponseCode {get; set;}
        public string Message {get; set;}
    }
    public class UserResponseMessages
    {
        public object UserAddedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1001;
            ec.Message = "User Added Successfully";
            return ec;
        }    
         public object UserUpdatedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1002;
            ec.Message = "User Updated Successfully";
            return ec;
        }      
          
         public object UserDeactivatedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1003;
            ec.Message = "User Deactivated Successfully";
            return ec;
        }     

         public object UserActivatedSuccess()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 1004;
            ec.Message = "User Activated Successfully";
            return ec;
        }    

        public object UserAddedFailed()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2001;
            ec.Message = "User Added  Failed";
            return ec;
        }

         public object UserNameNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2002;
            ec.Message = "plz Enter  username";
            return ec;
        }
        
         public object InValidUserName()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2003;
            ec.Message = "Invalid username (enter a-z A-Z 0-9 . _ @ # $ % and spaces only)";
            return ec;
        }
         public object UserPasswordNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2004;
            ec.Message = " Enter  Password";
            return ec;
        }
        
         public object InValidUserPassword()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2005;
            ec.Message = "Invalid Password (enter a-z A-Z 0-9 . _ @ # $ % and spaces only)";
            return ec;
        }

        
        public object UserFirstNameNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2006;
            ec.Message = " Enter  FirstName";
            return ec;
        }
        
         public object InValidUserFirstName()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2007;
            ec.Message = "Invalid FirstNamer (enter characters  and spaces only)";
            return ec;
        }
        public object UserLastNameNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2008;
            ec.Message = " Enter  LastName";
            return ec;
        }
        
         public object InValidUserLastName()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2009;
            ec.Message = "Invalid LastName (enter characters  and spaces only)";
            return ec;
        }
        public object UserEmailNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2010;
            ec.Message = " Enter  Email";
            return ec;
        }
        
         public object InValidUserEmail()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2011;
            ec.Message = "Invalid Email ( like abc@xyz.com)";
            return ec;
        }

         
        public object UserContactNotProvided()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2012;
            ec.Message = " Enter  User Contact Number";
            return ec;
        }
        public object InValidUserContact()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2013;
            ec.Message = "Invalid contact number (enter digits and hypens  only)";
            return ec;
        }

        
         public object UserIdNotFound(Guid uId)
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2014;
            ec.Message = "user having this ("+uId +") id not found ";
            return ec;
        }

        

        public object NoRecordFound()
        {
            ErrorCodes ec = new ErrorCodes();
            ec.ResponseCode = 2015;
            ec.Message = "No Record Found";
            return ec;
        }


        
    }
}