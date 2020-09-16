using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApiProject.Area.Models.BusinessUsers
{
    public class BusinessUsersResponse
    {
        [Key]
        public Guid BusinessUserID {get; set;}
        public Guid BusinessID { get; set;}         
        public Guid UserID { get; set;}
        
    }
   
    public class AllBusinessUsersResponse
    {
        [Column("businessuserdetails")]
        public string AllBusinessUsersInOneJson {get; set;}

    }
}